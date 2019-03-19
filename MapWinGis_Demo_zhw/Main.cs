using AxMapWinGIS;
using MapWinGis.ShapeEditor.Forms;
using MapWinGIS;
using MapWinGis_Demo_zhw.Forms;
using MapWinGis_Demo_zhw.Helper;
using MapWinGis_Demo_zhw.Manager;
using MWLite.Symbology.Forms;
using MWLite.Symbology.LegendControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using static MapWinGis_Demo_zhw.Enums;

namespace MapWinGis_Demo_zhw
{
    public partial class Main : Form
    {
        #region 变量
        //标题
        private const string WINDOW_TITLE = "MapWinGIS Demo";
        //private readonly AppDispatcher _dispatcher = new AppDispatcher();
        //地图组件
        private static MapDockForm _mapForm = null;
        //主窗口实例
        private static Main _form = null;
        //鹰眼地图
        private static SnapShotForm _snapForm = null;
        //图例组件
        private LegendDockForm _legendForm = null;
        //回调对象
        private MapCallback _callback = null;
        // 图层命令管理器，用于管理图层树
        private LegendDispatcher _dispatcher = null;
        //调试状态指示
        private Boolean debug = true;
        //点击识别属性标志
        private bool identifyFlag = false;
                //保存每个节点的信息
        private List<Node> LegendNodes = new List<Node>();
        //矢量图层比较器
        private Comparison<Shapefile> layerComparator = (x, y) =>
        {
            int xScore = 1;
            int yScore = 1;
            switch (x.ShapefileType)
            {
                case ShpfileType.SHP_POINT:
                    xScore = 1;
                    break;
                case ShpfileType.SHP_POLYLINE:
                    xScore = 2;
                    break;
                case ShpfileType.SHP_POLYGON:
                    xScore = 3;
                    break;
            }
            switch (y.ShapefileType)
            {
                case ShpfileType.SHP_POINT:
                    yScore = 1;
                    break;
                case ShpfileType.SHP_POLYLINE:
                    yScore = 2;
                    break;
                case ShpfileType.SHP_POLYGON:
                    yScore = 3;
                    break;
            }
            return yScore - xScore;
        };
        /// <summary>
        /// 下面三者是不同的含义的，
        /// 第一个是图层在axMap中的句柄，
        /// 第二个是图层在Layers（图层管理类）中的句柄，
        /// 第三个是图层在Groups（图层组管理类）中的句柄。
        /// </summary>
        //当前的图层句柄
        private int curLayerHandle = -1;
        //当前图层树的图层句柄
        private int curLegendLayerHandle = -1;
        //当前图层树的组句柄
        private int curLegendGroupHandle = -1;
        //图层树中Mouse事件的信息
        private ClickedElement clickedElement = new ClickedElement();
        //当前选中的图层
        private Layer curLayer = null;

        #endregion

        #region 属性

        //获取当前实例
        public static Main Instance
        {
            get { return Main._form; }
        }

        //预览地图
        public AxMap PreviewMap
        {
            get { return _snapForm.PreviewMap; }
        }
        
        public SnapShotForm SnapShotForm
        {
            get { return _snapForm; }
        }

        public WeifenLuo.WinFormsUI.Docking.DockPanel Panel
        {
            get { return dockPanel1; }
        }


        //获取当前图例控件
        public Legend Legend
        {
            get { return _legendForm.Legend; }
        }

        //获取当前地图控件
        public AxMap Map
        {
            get { return _mapForm.Map; }
        }

        //获取当前地图dock布局
        public MapDockForm mapDockForm
        {
            get { return _mapForm; }
        }
        #endregion

        public Main()
        {
            InitializeComponent();
            _callback = new MapCallback(statusStrip1, progressBar1, lblProgressMessage);
            _form = this;
            IdentifyResultForm.getInstance();
            Init();
            clearAllLayers();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            
            InitDockLayout();
            InitLegend();
            RegisterToolEvt();
            this.FormClosed += (s, e) =>
            {
                this.Tag = FormStates.Closing;
            };

            Legend.LayerPositionChanged += i =>
            {
                //MessageHelper.Info("new position :" + i);
                Node node = findNode(x => x.LayerHandle == i);
                
                
                int GroupIndex = -1;
                int LayerIndex = -1;

                Legend.FindLayerByHandle(node.LayerHandle,out GroupIndex,out LayerIndex);

                node.ParentGroupHandle = GroupIndex;
                //SortLayersByType();

                RefreshUI();


                Debug.Print("layerhandle "+node.LayerHandle+"\nnew position :" + i + "\n" + node.Path +"\n now groupIndex:" +GroupIndex +"\n new layerIndex "+LayerIndex);
            };

            Map.TileProvider = tkTileProvider.ProviderNone;

           //mnuTiles.DropDownItems.AddRange(tkTileProvider.ProviderNone, tkTileProvider.ProviderCustom);
        }



        /// <summary>
        /// 初始化布局
        /// </summary>
        private void InitDockLayout()
        {

            _mapForm = new MapDockForm();
            _mapForm.Show(dockPanel1, DockState.Document);
            _mapForm.CloseButtonVisible = true;
            _mapForm.CloseButton = true;

            _legendForm = new LegendDockForm();
            _legendForm.Show(dockPanel1, DockState.DockLeft);

            //_legendForm.CloseButtonVisible = false;

            _snapForm = new SnapShotForm();
            //public void DockTo(DockPane paneTo, DockStyle dockStyle, int contentIndex);
            //public void Show(DockPane previousPane, DockAlignment alignment, double proportion);
            _snapForm.Show(_legendForm.Pane, DockAlignment.Bottom, .4d);
            //_mapForm2.DockTo(_legendForm.Pane, DockStyle.Bottom, 1);
            //_mapForm2.Show(dockPanel1, DockState.DockLeft);
            //_mapForm.SelectionChanged += (s, e) => RefreshUI();

            _legendForm.DockStateChanged += (s, e) =>
            {
                //MessageHelper.Info(_legendForm.DockState+" ");
                //因为关闭窗体前会触发，为了不引起不必要的异常
                if(this.Tag is FormStates)
                {
                    return;
                }
                RefreshUI();
            };

            _snapForm.DockStateChanged += (s, e) =>
            {
                if (this.Tag is FormStates)
                {
                    return;
                }
                RefreshUI();
            };

            //用户关闭控件只会隐藏，而不是真正地被gc掉了
            _legendForm.FormClosing += (s, e) =>
            {
                e.Cancel = true;//撤销窗体关闭操作 
                _legendForm.DockState = DockState.Hidden;
                
            };

            _snapForm.FormClosing += (s, e) =>
            {
                e.Cancel = true;//撤销窗体关闭操作 
                _snapForm.DockState = DockState.Hidden;
            };

            _mapForm.CloseButton = false;
            _mapForm.Activate();
        }


        /// <summary>
        /// 订阅工具栏事件
        /// </summary>
        private void RegisterToolEvt()
        {
            mnuOpen.Click += openVectorLayer_Click;
            mnuAddVector.Click += openVectorLayer_Click;
            //TODO:打开栅格文件,加载工程文件，保存工程文件...
            toolZoomIn.Click += zoomIn_btn_Click;
            toolZoomOut.Click += zoomOut_btn_Click;
            toolZoomMax.Click += recover_btn_Click;
            toolPan.Click += pan_btn_Click;

            toolIdentify.Click += identify_btn_Click;
            toolMeasure.Click += measure_Click;
            toolMeasureArea.Click += measureArea_Click;
            toolAddVector.Click += openVectorLayer_Click;

            toolRemoveLayer.Click += removeAll_btn_Click;
            //_mainToolStrip.Click += _mainToolStrip_Click;
            toolSelect.Click += ToolSelect_Click;
            toolClearSelection.Click += ToolClearSelection_Click;
        }







        #region 初始化图例控件
        /// <summary>
        /// 初始化图层树控件
        /// </summary>
        private void InitLegend()
        {
            _dispatcher = new LegendDispatcher(Legend);
            _dispatcher.InitMenu(ContextMenu.Items);


            Legend.Map = Map.GetOcx() as Map;
            Legend.AssignOrphanLayersToNewGroup("图层数据");
            Legend.LayerMouseUp += legend1_LayerMouseUp;
            Legend.LayerDoubleClick += legend1_LayerDoubleClick;
            Legend.LayerSelected += (handle) =>
            {
                RefreshUI();
            };
            Legend.LayerCheckboxClicked += Legend_LayerCheckboxClicked;
            Legend.GroupCheckboxClicked += Legend_GroupCheckboxClicked;
            //订阅该事件是为了跟踪每次加入的图层的图层句柄
            Legend.LayerAdded += handle => { curLayerHandle = Legend.Layers[handle].Handle; curLegendLayerHandle = handle; };
            //Legend.GroupAdded += handle => curLegendGroupHandle = handle;
            //Legend.GroupRemoved += handle => curLegendGroupHandle = handle;
            Legend.LayerAdded += handle =>
            {
                if (Map.NumLayers > 0)
                {
                    resetAllToolStripBtn(s => s.Enabled = true);
                    //recover_btn.Enabled = true;
                    toolRemoveLayer.Enabled = true;
                }
            };
            Legend.LayerLabelClicked += handle =>
            {
                MessageBox.Show("labelClick");
            };

            Legend.MouseDown += (s, e) =>
            {
                System.Drawing.Point pnt = new System.Drawing.Point(e.X, e.Y);
                curLayer = Legend.FindClickedLayer(pnt, ref clickedElement);
            };

            //Map.SelectBoxFinal += (s, e) =>
            //{
            //    MessageHelper.Info("selec");
            //};
        }


        /// <summary>
        /// 重置工具栏button
        /// </summary>
        private void resetAllToolStripBtn(Action<ToolStripButton> action)
        {
            action(toolZoomIn);
            action(toolZoomOut);
            action(toolZoomMax);
            action(toolZoomToLayer);
            action(toolPan);
            action(toolSetProjection);
            action(toolSearch);
            action(toolIdentify);
            action(toolMeasure);
            action(toolMeasureArea);
            //action(toolSelection);
            action(toolZoomToSelected);
            action(toolClearSelection);
        }

        /// <summary>
        /// 图层组勾选事件
        /// </summary>
        /// <param name="Handle">Handle代表的是位置,不代表图层句柄</param>
        /// <param name="State"></param>
        private void Legend_GroupCheckboxClicked(int Handle, VisibleStateEnum State)
        {

        }

        /// <summary>
        /// 图层勾选事件
        /// </summary>
        /// <param name="Handle"></param>
        /// <param name="NewState"></param>
        private void Legend_LayerCheckboxClicked(int Handle, bool NewState)
        {
            //Node node = findNode(x => Handle == x.LayerHandle);
        }

        /// <summary>
        /// 图层树点击事件,暂时只写了右键弹出菜单
        /// </summary>
        /// <param name="Handle"></param>
        /// <param name="button"></param>
        private void legend1_LayerMouseUp(int Handle, MouseButtons button)
        {
            if (button == MouseButtons.Right && Handle != -1)
            {
                Legend.SelectedLayer = Handle;
                var layer = Legend.Layers.ItemByHandle(Handle);
                if (layer != null)
                {
                    _dispatcher.LayerHandle = Handle;
                    ContextMenu.Show(Control.MousePosition);
                }
            }
        }

        /// <summary>
        /// 右键菜单移除项处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeItem_Click(object sender, EventArgs e)
        {
            int layerHandle = App.Legend.SelectedLayer;
            Node node = findNode(x => x.LegendHandle == layerHandle && x.NodeType == NodeType.layer);
            int parentGroupHandle = node.ParentGroupHandle;



            int GroupIndex = -1;
            int LayerIndex = -1;

            getLayerInLegendInfo(layerHandle,ref GroupIndex,ref LayerIndex);

            parentGroupHandle = GroupIndex;

            LayerHelper.RemoveLayer();

            LegendNodes.Remove(node);



            //如果该组没有图层了，就移除该组
            if (Legend.Groups[parentGroupHandle].LayerCount == 0)
            {
                Node groupNode = findNode(x => x.LegendHandle == parentGroupHandle && x.NodeType == NodeType.group);
                LegendNodes.Remove(groupNode);
                
                bool success=Legend.Groups.Remove(Legend.Groups[parentGroupHandle].Handle);
                if (success)
                {
                    Debug.Print("移除成功：" + parentGroupHandle);
                }
                else
                {
                    Debug.Print("移除失败：" + parentGroupHandle);
                }
            }
            RefreshUI();
        }

        /// <summary>
        /// 获得图层的在图层树中的位置信息
        /// </summary>
        /// <param name="layerhandle"></param>
        /// <param name="GroupIndex"></param>
        /// <param name="LayerIndex"></param>
        private void getLayerInLegendInfo(int layerhandle,ref int GroupIndex,ref int LayerIndex)
        {
            GroupIndex = -1;
            LayerIndex = -1;

            Legend.FindLayerByHandle(layerhandle, out GroupIndex, out LayerIndex);
        }

        /// <summary>
        /// 右键菜单符号项处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void symbolItem_Click(object sender, EventArgs e)
        {
            int handle = Legend.SelectedLayer;
            //如果等于-1 则说明点的是图例，否则点击的是图例列表中的某个图例
            if (curLayer != null && clickedElement.CategoryIndex != -1)
            {
                Legend.LegendEventHandler.m_legend_LayerCategoryClicked(curLayer.Handle, clickedElement.CategoryIndex);
            }
            else
            {
                Legend.LegendEventHandler.m_legend_LayerColorboxClicked(curLayer.Handle);
            }

        }


        /// <summary>
        /// 右键菜单标注项处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lableItem_Click(object sender, EventArgs e)
        {
            if (curLayer.Handle != -1)
                Legend.LegendEventHandler.m_legend_LayerLabelsClicked(curLayer.Handle);
        }


        /// <summary>
        /// 右键属性项处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prosperityItem_Click(object sender, EventArgs e)
        {
            if (curLegendLayerHandle != -1)
            {
                Form form = new ProsperityForm(Legend, Legend.SelectedLayer);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();
            }

        }

        //TODO:待完善
        /// <summary>
        /// 右键表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void table_Click(object sender, EventArgs e)
        {
            if (Legend.SelectedLayer != -1)
            {

                AttributesForm attributesForm = new AttributesForm(Map, Legend, Legend.SelectedLayer);
                attributesForm.StartPosition = FormStartPosition.CenterScreen;
                //_snapForm.Show(_legendForm.Pane, DockAlignment.Bottom, .4d);
                //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                //attributesForm.FormBorderStyle = FormBorderStyle.Fixed3D;
                attributesForm.Show(mapDockForm.Pane, DockAlignment.Bottom, .4d);
                //attributesForm.Show(dockPanel1, DockState.DockBottom);


            }
        }

        /// <summary>
        /// 图层双击事件
        /// </summary>
        /// <param name="Handle"></param>
        private void legend1_LayerDoubleClick(int Handle)
        {
            //LayerHelper.ShowLayerProperties(Handle);
            Legend.SelectedLayer = Handle;
            LayerHelper.ZoomToLayer();
        }

        #endregion

        #region 窗体事件
        private void MainForm_Load(object sender, EventArgs e)
        {

            resetAllToolStripBtn(s => s.Enabled = false);
            //recover_btn.Enabled = false;
            //removeAll_btn.Enabled = false;
            toolRemoveLayer.Enabled = false;
        }
        #endregion


        #region 工具栏事件

        /// <summary>
        /// 清除选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolClearSelection_Click(object sender, EventArgs e)
        {
            int selectLayerHandle = App.Legend.SelectedLayer;
            Shapefile sf = Map.get_Shapefile(selectLayerHandle);
            sf.SelectNone();
            App.RefreshUI();
            Map.Redraw();
        }

        /// <summary>
        /// 按矩形选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolSelect_Click(object sender, EventArgs e)
        {
            Map.CursorMode = tkCursorMode.cmSelection;
            RefreshUI();
        }

        /// <summary>
        /// 每次点击工具栏都得刷新界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _mainToolStrip_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void measureArea_Click(object sender, EventArgs e)
        {
            Map.Measuring.MeasuringType = tkMeasuringType.MeasureArea;
            Map.CursorMode = tkCursorMode.cmMeasure;
            RefreshUI();

        }

        /// <summary>
        /// 测量距离
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void measure_Click(object sender, EventArgs e)
        {
            Map.Measuring.MeasuringType = tkMeasuringType.MeasureDistance;
            Map.CursorMode = tkCursorMode.cmMeasure;
            RefreshUI();
        }

        /// <summary>
        /// 打开矢量图层回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openVectorLayer_Click(object sender, EventArgs e)
        {
            String[] files = openShapefileDialog();
            if (files != null)
            {
                //原图层排序，优点是能在legend中表示顺序
                //缺点打开速度慢
                //files = sortLayerWithCurLayer(files);
                //clearAllLayers();

                try
                {

                    //设置底图
                    //Map.TileProvider = tkTileProvider.ProviderNone;
                    //依次加入图层
                    foreach (string file in files)
                    {
                        if (file.ToLower().Trim().EndsWith(".shp"))
                        {


                            Shapefile sf = new Shapefile();

                            if (sf.Open(file, null))
                            {

                                Map.CursorMode = MapWinGIS.tkCursorMode.cmPan;

                                //layerHandle = axMap1.AddLayer(sf, true);    //加入sf图层

                                if (true)
                                {
                                    string directoryName = Path.GetDirectoryName(file);//目录名
                                    string fileName = Path.GetFileNameWithoutExtension(file);//文件名
                                    
                                    
                                    Node target = findNode(x => {
                                        if (x.Path != "")
                                            return x.NodeType == NodeType.group && Path.GetDirectoryName(x.Path) == directoryName;
                                        return false;
                                    });
                                    //当前目录是存在的 因此是子节点,不需要新增数据框
                                    if (target != null)
                                    {
                                        //把图层加载组中的最顶端
                                        addLayer(sf, target.LegendHandle);
                                        Node node = new Node(curLegendLayerHandle, target.LegendHandle, curLayerHandle, file);


                                        int GroupIndex = -1;
                                        int LayerIndex = -1;
                                        getLayerInLegendInfo(curLegendLayerHandle, ref GroupIndex, ref LayerIndex);


                                        //将对应的层赋值
                                        node.ParentGroupHandle = GroupIndex;
                                        LegendNodes.Add(node);
                                        if (debug)
                                        {
                                            Debug.Print("加入旧层\n");
                                            Debug.Print("组数：" + Legend.Groups.Count() + "\n" +
                                                            "图层树的图层数：" + Legend.Layers.Count() + "\n" +
                                                            "对应的group handle"+ node.ParentGroupHandle +"\n"+
                                                            "实际图层数：" + Map.NumLayers);
                                        }

                                    }
                                    //当前目录为新目录，需要重新创建根节点
                                    else
                                    {
                                        addGroup(directoryName);
                                        addLayer(sf, curLegendGroupHandle);


                                        int GroupIndex = -1;
                                        int LayerIndex = -1;
                                        getLayerInLegendInfo(curLegendLayerHandle, ref GroupIndex, ref LayerIndex);

                                        Node groupNode = new Node(GroupIndex, curLayerHandle, file);
                                        Node layerNode = new Node(curLegendLayerHandle, GroupIndex, curLayerHandle, file);
                                        layerNode.ParentGroupHandle = groupNode.LegendHandle;
                                        LegendNodes.Add(groupNode);
                                        LegendNodes.Add(layerNode);
                                        if (debug)
                                        {
                                            Debug.Print("加入新层\n");
                                            Debug.Print("组数：" + Legend.Groups.Count() + "\n" +
                                                            "图层树的图层数：" + Legend.Layers.Count() + "\n" +
                                                            "对应的group handle" + layerNode.ParentGroupHandle + "\n" +
                                                            "实际图层数：" + Map.NumLayers);
                                        }

                                    }
                                    //输出加载信息
                                    App.LoadMapState(file);
                                    //默认图例
                                    Map.set_ShapeLayerLineColor(curLayerHandle, ParseRGB(Color.Black));//线颜色
                                    //axMap1.set_ShapeLayerLineStipple(curLayerHandle, tkLineStipple.lsCustom);//点样式
                                    Map.set_ShapeLayerLineWidth(curLayerHandle, 1.5f);//线宽度
                                    //缩放至第一个图层
                                    Map.ZoomToLayer(Legend.Layers.First().Handle);


                    
                                }


                            }
                            else if (file == null)
                            {
                                MessageBox.Show("路径为空");

                            }
                            else
                            {
                                MessageBox.Show(sf.ErrorMsg[sf.LastErrorCode]);
                                MessageBox.Show("错误");
                            }

                        }

                        if (curLayerHandle != -1)
                        {
                            Map.set_LayerName(curLayerHandle, Path.GetFileName(file));
                        }


                    }
                }
                finally
                {
                    SortLayersByType();
                    
                    Map.LockWindow(tkLockMode.lmUnlock);
                    Debug.Print("Layers added to the map: " + Map.NumLayers);
                    RefreshUI();
                }
            }



        }

        /// <summary>
        /// 移除所有图层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeAll_btn_Click(object sender, EventArgs e)
        {
            clearAllLayers();
            if (debug)
            {
                MessageBox.Show("清空操作 \n" +
                    "组数：" + Legend.Groups.Count() + "\n" +
                                "图层树的图层数：" + Legend.Layers.Count() + "\n" +
                                "实际图层数：" + Map.NumLayers);
            }
            RefreshUI();
        }

        /// <summary>
        /// 漫游
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pan_btn_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if (btn != null)
            {
                resetAllToolStripBtn(s => s.Checked = false);
                btn.Checked = true;
            }
            Map.CursorMode = MapWinGIS.tkCursorMode.cmPan;
            RefreshUI();
        }

        /// <summary>
        /// 放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoomIn_btn_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if (btn != null)
            {
                resetAllToolStripBtn(s => s.Checked = false);
                btn.Checked = true;
            }
            Map.CursorMode = MapWinGIS.tkCursorMode.cmZoomIn;
            RefreshUI();
        }

        /// <summary>
        /// 缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoomOut_btn_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if (btn != null)
            {
                resetAllToolStripBtn(s => s.Checked = false);
                btn.Checked = true;
            }
            Map.CursorMode = MapWinGIS.tkCursorMode.cmZoomOut;
            RefreshUI();
        }

        /// <summary>
        /// 选择识别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void identify_btn_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if (btn != null)
            {
                resetAllToolStripBtn(s => s.Checked = false);
                btn.Checked = true;
            }
            Map.CursorMode = MapWinGIS.tkCursorMode.cmIdentify;
            //待完善：可用shapfile.selectbox进行范围内多个shape属性信息的读取
            RefreshUI();
        }

        /// <summary>
        /// 复位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recover_btn_Click(object sender, EventArgs e)
        {
            LayerHelper.ZoomToLayer();
            RefreshUI();
        }


        /// <summary>
        /// 按多边形选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSelectByPolygon_Click(object sender, EventArgs e)
        {
            //TODOS:实现多边形选择
            Map.CursorMode = tkCursorMode.cmSelectByPolygon;
            RefreshUI();

        }

        /// <summary>
        /// 缩放至所选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolZoomToSelected_Click(object sender, EventArgs e)
        {
            Map.ZoomToSelected(App.Legend.SelectedLayer);
            //Map.ZoomToWorld();
        }

        #endregion

        #region 私有方法


        /// <summary>
        /// 刷新界面
        /// </summary>
        public void RefreshUI()
        {
            //每当触发了某些改变地图的事件，你也可以在这里做些什么
            if (Map.NumLayers == 0)
            {
                //禁用工具按钮
                resetAllToolStripBtn(s => s.Enabled = false);
                toolRemoveLayer.Enabled = false;
            }

            toolSetProjection.Enabled = App.Map.NumLayers == 0;
            toolSetProjection.Text = App.Map.NumLayers == 0
                ? "设置坐标系统和投影"
                : "无可用图层";

            toolSearch.Enabled = true;
            toolSearch.Text = "查找位置信息";
            if (App.Map.NumLayers > 0 && !App.Map.Measuring.IsUsingEllipsoid)
            {
                toolSearch.Enabled = false;
                toolSearch.Text = "Unsupported projection. Search isn't allowed.";
            }


            toolZoomIn.Checked = Map.CursorMode == tkCursorMode.cmZoomIn;
            toolZoomOut.Checked = Map.CursorMode == tkCursorMode.cmZoomOut;
            toolPan.Checked = Map.CursorMode == tkCursorMode.cmPan;
            toolSelect.Checked = Map.CursorMode == tkCursorMode.cmSelection;
            toolSelectByPolygon.Checked = Map.CursorMode == tkCursorMode.cmSelectByPolygon;
            toolIdentify.Checked = Map.CursorMode == tkCursorMode.cmIdentify;
            toolLegendButton.Enabled = _legendForm.DockState == DockState.Hidden || _legendForm.DockState == DockState.Unknown;
            toolPreviewButton.Enabled = _snapForm.DockState == DockState.Hidden || _snapForm.DockState == DockState.Unknown;
           
            无ToolStripMenuItem.Checked = Map.TileProvider == tkTileProvider.ProviderNone;
            openStreetMapToolStripMenuItem.Checked = Map.TileProvider == tkTileProvider.OpenStreetMap;
            openCycleMapToolStripMenuItem.Checked = Map.TileProvider == tkTileProvider.OpenCycleMap;
            openTransportMapToolStripMenuItem.Checked = Map.TileProvider == tkTileProvider.OpenTransportMap;
            bingMapsToolStripMenuItem.Checked = Map.TileProvider == tkTileProvider.BingMaps;
            bingSatelliteToolStripMenuItem.Checked= Map.TileProvider == tkTileProvider.BingSatellite;
            bingHybridToolStripMenuItem.Checked = Map.TileProvider == tkTileProvider.BingHybrid;
            googleMapsToolStripMenuItem.Checked = Map.TileProvider == tkTileProvider.GoogleMaps;
            googleSatelliteToolStripMenuItem.Checked = Map.TileProvider == tkTileProvider.GoogleSatellite;
            googleHybridToolStripMenuItem.Checked = Map.TileProvider == tkTileProvider.GoogleHybrid;
            googleTerrainToolStripMenuItem.Checked = Map.TileProvider == tkTileProvider.GoogleTerrain;
            rosreestrToolStripMenuItem.Checked = Map.TileProvider == tkTileProvider.Rosreestr;
            openHumanitarianMapToolStripMenuItem.Checked = Map.TileProvider == tkTileProvider.OpenHumanitarianMap;
            mapQuestAerialToolStripMenuItem.Checked = Map.TileProvider == tkTileProvider.MapQuestAerial;
            providerCustomToolStripMenuItem.Checked = Map.TileProvider == tkTileProvider.ProviderCustom;


            bool distance = Map.Measuring.MeasuringType == tkMeasuringType.MeasureDistance;
            toolMeasure.Checked = Map.CursorMode == tkCursorMode.cmMeasure && distance;
            toolMeasureArea.Checked = Map.CursorMode == tkCursorMode.cmMeasure && !distance;

            if (Map.CursorMode != tkCursorMode.cmIdentify)
            {
                //MapDockForm.HideTooltip();
            }

            //当前有图层
            bool hasShapefile = false;
            int layerHandle = App.Legend.SelectedLayer;
            bool hasLayer = layerHandle != -1;
            if (hasLayer)
            {
                var sf = App.Map.get_Shapefile(layerHandle);
                if (sf != null)
                {
                    //MessageHelper.Info("cur mode" + Map.CursorMode.ToString());
                    statusSelectedCount.Text = string.Format("Shapes: {0}; selected: {1}", sf.NumShapes, sf.NumSelected);
                    toolClearSelection.Enabled = sf.NumSelected > 0;
                    toolZoomToSelected.Enabled = sf.NumSelected > 0;
                    hasShapefile = true;
                }
            }

            if (!hasShapefile)
            {
                statusSelectedCount.Text = "";
                toolClearSelection.Enabled = false;
                toolZoomToSelected.Enabled = false;
            }

            toolRemoveLayer.Enabled = hasLayer || Legend.Groups.Count>0;

            //App.RefreshUI();

            Map.Focus();
            Map.Redraw();
        }

        /// <summary>
        /// 寻找图层树中的节点
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        private Node findNode(Predicate<Node> predicate)
        {
            foreach (Node node in LegendNodes)
            {
                if (predicate(node))
                    return node;
            }
            return null;
        }

        /// <summary>
        /// 颜色转RGB
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private uint ParseRGB(Color color)
        {
            return (uint)(((uint)color.B << 16) | (ushort)(((ushort)color.G << 8) | color.R));
        }

        /// <summary>
        /// 打开shapefile对话框
        /// </summary>
        /// <returns></returns>
        private string[] openShapefileDialog()
        {
            DialogResult result;
            String[] files;
            //Shapefile shapefile = new Shapefile();

            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Multiselect = true;
                openDialog.InitialDirectory = @"c:/";
                openDialog.Filter = "ShapeFile文件|*.shp";//定义文件筛选器,只显示扩展名为.shp的文件；
                openDialog.Title = "请打开ShapeFile文件";
                result = openDialog.ShowDialog();//返回用户选择
                openDialog.RestoreDirectory = true;//关闭前对话框恢复当前目录
                files = openDialog.FileNames;//保存选中文件路径

            }

            return files;

        }

        /// <summary>
        /// 移除所以图层，包括图层树
        /// </summary>
        private void clearAllLayers()
        {

            Legend.Groups.Clear();
            Legend.Layers.Clear();
            Legend.Refresh();
            LegendNodes.Clear();
            RefreshUI();
        }

        /// <summary>
        /// 图层树加入一组新的数据组
        /// </summary>
        /// <param name="name"></param>
        private void addGroup(string name)
        {
            LayerHelper.AddGroup(name);
        }

        /// <summary>
        /// 在最顶端的组中的最顶端加入新图层
        /// </summary>
        /// <param name="layer"></param>
        private void addLayer(object layer)
        {
            LayerHelper.AddLayer(layer);
        }

        /// <summary>
        /// 在某个组的最顶端加入新的图层
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="targetGroup"></param>
        private void addLayer(object layer, int targetGroup)
        {
            LayerHelper.AddLayer(layer, targetGroup);
        }


        /// <summary>
        /// 在某个组的某个图层之前的位置加入新的图层
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="targetGroup"></param>
        /// <param name="afterLayerHandle"></param>
        private void addLayer(object layer, int targetGroup, int afterLayerHandle)
        {
            LayerHelper.AddLayer(layer, targetGroup, afterLayerHandle);
        }


        /// <summary>
        /// 现有图层和新图层一起排序
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        private string[] sortLayerWithCurLayer(string[] files)
        {
            List<string> result = new List<string>();
            List<string> prefiles = new List<string>();
            foreach (Node n in LegendNodes)
            {
                if (n.NodeType == NodeType.layer)
                {
                    prefiles.Add(n.Path);
                }
            }
            //旧图层排序
            result.AddRange(sortLayer(prefiles.ToArray()).ToArray());
            //新图层排序
            result.AddRange(sortLayer(files).ToArray());
            //再次排序，防止新旧图层不在同一个"块"
            return sortLayer(result.ToArray());
        }


        /// <summary>
        /// 图层排序
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        private string[] sortLayer(string[] files)
        {
            //图层顺序控制处理，使传进来的图层按照点，线，面由上至下叠置
            List<Shapefile> shapefiles = new List<Shapefile>();
            foreach (string file in files)
            {
                Shapefile sf = new Shapefile();
                sf.Open(file);
                shapefiles.Add(sf);
            }
            //新图层排序
            shapefiles.Sort(layerComparator);
            string[] result = new string[shapefiles.Count];
            for (int i = 0; i < shapefiles.Count; i++)
            {
                result[i] = shapefiles[i].Filename;
            }
            return result;
        }


        #endregion

        /// <summary>
        /// 帮助点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.mapwindow.org/documentation/mapwingis4.9/index.html");
        }

        /// <summary>
        /// github点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/XiaoZhong233/MapwinGis_project");
        }

        /// <summary>
        /// 加入栅格文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAddRaster_Click(object sender, EventArgs e)
        {
            //Map.AddLayerFromFilename("D:/MyDownloads/Download/GDPGrid_China2010.tif", tkFileOpenStrategy.fosDirectGrid, true);
        }


        /// <summary>
        /// 图层排序,在当前的组中
        /// </summary>
        public void SortLayersByType()
        {
            for (int j = 0; j < 3; j++)
            {
                List<int> handles = new List<int>();
                for (int i = 0; i < Map.NumLayers; i++)
                {
                    int layerHandle = Map.get_LayerHandle(i);
                    Shapefile sf = Map.get_Shapefile(layerHandle);
                    if (sf != null)
                    {
                        if (j == 0 && sf.ShapefileType == ShpfileType.SHP_POINT)
                            handles.Add(layerHandle);
                        if (j == 1 && sf.ShapefileType == ShpfileType.SHP_POLYLINE)
                            handles.Add(layerHandle);
                        if (j == 2 && sf.ShapefileType == ShpfileType.SHP_POLYGON)
                            handles.Add(layerHandle);
                    }
                }
                Map.LockWindow(tkLockMode.lmLock);
                try
                {
                    foreach (int handle in handles)
                    {
                        int position = Map.get_LayerPosition(handle);
                        Map.MoveLayerBottom(position);
                        //拿到当前图层所属的组
                        Node node = findNode(x => x.LayerHandle == handle && x.NodeType == NodeType.layer);
                        //Legend.Layers.MoveLayerWithinGroup(handle, position);
                        Legend.Layers.MoveLayer(handle, Legend.Groups[node.ParentGroupHandle].Handle, position);
                        
                    }
                }
                finally
                {
                    Map.LockWindow(tkLockMode.lmUnlock);
                }
            }
        }


        private void toolPreviewButton_Click(object sender, EventArgs e)
        {
            //如果图例控件在隐藏状态的话，鸟瞰图需要变为浮动状态
            if(_legendForm.DockState != DockState.Hidden)
            {
                _snapForm.DockState = DockState.DockLeft;
            }
            else
            {
                //_snapForm.DockState = DockState.DockLeft;
                //_snapForm.Show(_legendForm.Pane, DockAlignment.Bottom, .4d);
                _snapForm.DockState = DockState.Float;
            }
        }

        private void toolLegendButton_Click(object sender, EventArgs e)
        {
            _legendForm.DockState = DockState.DockLeft;
        }

        private void mnuSnapshot_Click(object sender, EventArgs e)
        {


            MapWinGIS.Image img = App.Map.SnapShot(App.Map.MaxExtents);
            ImageUtils cvter = new ImageUtils();
            System.Drawing.Image tmpImg = ImageUtils.ObjectToImage(img.Picture, System.Convert.ToInt32(img.Width ), System.Convert.ToInt32(img.Height));

        }

        private void 无ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.TileProvider = tkTileProvider.ProviderNone;
            RefreshUI();
        }

        private void openStreetMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.TileProvider = tkTileProvider.OpenStreetMap;
            RefreshUI();
        }

        private void openCycleMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.TileProvider = tkTileProvider.OpenCycleMap;
            RefreshUI();
        }

        private void openTransportMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.TileProvider = tkTileProvider.OpenTransportMap;
            RefreshUI();
        }

        private void bingMapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.TileProvider = tkTileProvider.BingMaps;
            RefreshUI();
        }

        private void bingSatelliteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.TileProvider = tkTileProvider.BingSatellite;
            RefreshUI();
        }

        private void bingHybridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.TileProvider = tkTileProvider.BingHybrid;
            RefreshUI();
        }

        private void googleMapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.TileProvider = tkTileProvider.GoogleMaps;
            RefreshUI();
        }

        private void googleSatelliteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.TileProvider = tkTileProvider.GoogleSatellite;
            RefreshUI();
        }

        private void googleHybridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.TileProvider = tkTileProvider.GoogleHybrid;
            RefreshUI();
        }

        private void googleTerrainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.TileProvider = tkTileProvider.GoogleTerrain;
            RefreshUI();
        }

        private void rosreestrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.TileProvider = tkTileProvider.Rosreestr;
            RefreshUI();
        }

        private void openHumanitarianMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.TileProvider = tkTileProvider.OpenHumanitarianMap;
            RefreshUI();
        }

        private void mapQuestAerialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.TileProvider = tkTileProvider.MapQuestAerial;
            RefreshUI();
        }

        private void providerCustomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.TileProvider = tkTileProvider.ProviderCustom;
            RefreshUI();
        }
    }
}
