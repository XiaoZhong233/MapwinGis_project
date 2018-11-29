using AxMapWinGIS;
using MapWinGIS;
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

namespace MapWinGis_Demo_zhw
{


    public partial class MainForm : Form
    {


        #region 变量
        /// <summary>
        /// 图层命令管理器，用于管理图层树
        /// </summary>
        private LegendDispatcher _dispatcher = null;
        /// <summary>
        /// 当前活动窗口的静态引用，目的是保存当前实例方便其他类操作
        /// </summary>
        private static MainForm mainform = null;

        private Boolean debug = true;

        //List<int> layerHandles = new List<int>();
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


        #region 公共属性
        /// <summary>
        /// 获取当前实例
        /// </summary>
        public static MainForm Instance
        {
            get { return mainform; }
        }

        /// <summary>
        /// 获取当前的图层树控件
        /// </summary>
        public Legend Legend
        {
            get { return legend1; }
        }


        /// <summary>
        /// 获取当前地图控件实例
        /// </summary>
        public AxMap Map
        {
            get { return axMap1; }
        }

        #endregion

        #region 初始化Map
        public void LoadMapState(string filename)
        {
            axMap1.LockWindow(tkLockMode.lmLock);
            try
            {
                axMap1.LoadMapState(filename, null);
                InitMap();
            }
            finally
            {
                axMap1.LockWindow(tkLockMode.lmUnlock);
            }
        }

        private void InitMap()
        {
            //axMap1.Tiles.SetProxy("127.0.0.1", 8888);
            //axMap1.Tiles.SetProxyAuthentication("temp", "1234", "");
            axMap1.GrabProjectionFromData = true;
            axMap1.CursorMode = tkCursorMode.cmZoomIn;
            axMap1.SendSelectBoxFinal = true;
            axMap1.SendMouseDown = true;
            axMap1.SendMouseUp = true;
            axMap1.InertiaOnPanning = tkCustomState.csAuto;
            axMap1.ShowRedrawTime = false;
            Map.Identifier.IdentifierMode = tkIdentifierMode.imSingleLayer;
            Map.Identifier.HotTracking = true;
            Map.ShapeEditor.HighlightVertices = tkLayerSelection.lsNoLayer;
            Map.ShapeEditor.SnapBehavior = tkLayerSelection.lsNoLayer;
            axMap1.Measuring.UndoButton = tkUndoShortcut.usCtrlZ;
        }

        private void RegisterEventHandlers()
        {
            //axMap1.ProjectionChanged += axMap1_ProjectionChanged;
            //axMap1.MouseMoveEvent += axMap1_MouseMoveEvent;
            //axMap1.PreviewKeyDown += axMap1_PreviewKeyDown;
            //axMap1.SelectionChanged += axMap1_SelectionChanged;
            //axMap1.ShapeIdentified += axMap1_ShapeIdentified;
            //axMap1.MouseUpEvent += axMap1_MouseUpEvent;
            //axMap1.ShapeHighlighted += axMap1_ShapeHighlighted;
            //axMap1.SelectBoxFinal += axMap1_SelectBoxFinal;
            //axMap1.LayerProjectionIsEmpty += axMap1_LayerProjectionIsEmpty;
            //axMap1.ProjectionMismatch += axMap1_ProjectionMismatch;
            //axMap1.LayerReprojected += axMap1_LayerReprojected;
            
            axMap1.LayerAdded += axMap1_LayerAdded;
            axMap1.GridOpened += axMap1_GridOpened;
            axMap1.LayerRemoved += axMap1_LayerRemoved;
            axMap1.BackgroundLoadingStarted += axMap1_BackgroundLoadingStarted;
            axMap1.BackgroundLoadingFinished += axMap1_BackgroundLoadingFinished;
        }
        void axMap1_GridOpened(object sender, _DMapEvents_GridOpenedEvent e)
        {
            Debug.Print("Grid is opened: " + e.gridFilename);
            Debug.Print("Using proxy: " + e.isUsingProxy);
            Debug.Print("BandIndex: " + e.bandIndex);
        }

        void axMap1_BackgroundLoadingFinished(object sender, _DMapEvents_BackgroundLoadingFinishedEvent e)
        {
            Debug.Print("Loading finished: {0}; TaskId: {1}; LayerHandle: {2} Features: {3}; Loaded: {4}",
            DateTime.Now.TimeOfDay.ToString(), e.taskId, e.layerHandle, e.numFeatures, e.numLoaded);
        }

        void axMap1_BackgroundLoadingStarted(object sender, _DMapEvents_BackgroundLoadingStartedEvent e)
        {
            Debug.Print("Loading started: {0}; TaskId: {1}; LayerHandle: {2}", DateTime.Now.TimeOfDay.ToString(), e.taskId, e.layerHandle);
        }

        void axMap1_LayerRemoved(object sender, _DMapEvents_LayerRemovedEvent e)
        {
            //如果清空了图层 禁用按钮
            if (axMap1.NumLayers == 0)
            {
                resetAllToolStripBtn(s => s.Enabled = false);
                recover_btn.Enabled = false;
                removeAll_btn.Enabled = false;
            }
            
            Debug.Print("Layer removed.");
        }

        void axMap1_LayerAdded(object sender, _DMapEvents_LayerAddedEvent e)
        {
            Debug.Print("Layer added.");
            if (axMap1.NumLayers > 0)
            {
                resetAllToolStripBtn(s => s.Enabled = true);
                recover_btn.Enabled = true;
                removeAll_btn.Enabled = true;
            }
        }




        #endregion

        #region 构造函数
        public MainForm()
        {
            InitializeComponent();
            mainform = this;
            InitMap();
            init();
        }
        #endregion

        #region 初始化图层树
        /// <summary>
        /// 初始化
        /// </summary>
        private void init()
        {
            _dispatcher = new LegendDispatcher(legend1);
            _dispatcher.InitMenu(ContextMenu.Items);
            initLegend();
        }

        /// <summary>
        /// 初始化图层树事件
        /// </summary>
        private void initLegend()
        {
            Legend.LayerMouseUp += legend1_LayerMouseUp;
            Legend.LayerDoubleClick += legend1_LayerDoubleClick;
            Legend.Map = Map.GetOcx() as Map;
            Legend.AssignOrphanLayersToNewGroup("图层数据");
            Legend.LayerSelected += (handle) =>
            {
                RefreshUI();
            };
            Legend.LayerCheckboxClicked += Legend_LayerCheckboxClicked;
            Legend.GroupCheckboxClicked += Legend_GroupCheckboxClicked;
            //订阅该事件是为了跟踪每次加入的图层的图层句柄
            Legend.LayerAdded += handle => { curLayerHandle = Legend.Layers[handle].Handle;curLegendLayerHandle = handle; };
            Legend.GroupAdded += handle => curLegendGroupHandle = handle;
            Legend.LayerAdded += handle =>
            {
                if (axMap1.NumLayers > 0)
                {
                    resetAllToolStripBtn(s => s.Enabled = true);
                    recover_btn.Enabled = true;
                    removeAll_btn.Enabled = true;
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
        }

        #endregion

        #region 图层树事件处理
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
            Node node = findNode(x => Handle == x.LayerHandle);
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
                legend1.SelectedLayer = Handle;
                var layer = legend1.Layers.ItemByHandle(Handle);
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
            LayerHelper.RemoveLayer();
            LegendNodes.Remove(node);
            //如果该组没有图层了，就移除该组
            if (Legend.Groups[parentGroupHandle].LayerCount == 0)
            {
                Node groupNode = findNode(x => x.LegendHandle == parentGroupHandle && x.NodeType == NodeType.group);
                LegendNodes.Remove(groupNode);
                Legend.Groups.Remove(parentGroupHandle);
            }
            RefreshUI();
        }

        /// <summary>
        /// 右键菜单符号项处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void symbolItem_Click(object sender,EventArgs e)
        {
            int handle = Legend.SelectedLayer;
            //如果等于-1 则说明点的是图例，否则点击的是图例列表中的某个图例
            if(curLayer!=null && clickedElement.CategoryIndex != -1)
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
        private void lableItem_Click(object sender,EventArgs e)
        {
            if(curLayer.Handle!=-1)
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
                Form form = new ProsperityForm(Legend,Legend.SelectedLayer);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();
            }

        }

        /// <summary>
        /// 图层双击事件
        /// </summary>
        /// <param name="Handle"></param>
        private void legend1_LayerDoubleClick(int Handle)
        {
            //LayerHelper.ShowLayerProperties(Handle);
            legend1.SelectedLayer = Handle;
            LayerHelper.ZoomToLayer();
        }

        #endregion 

        #region 窗体事件
        private void MainForm_Load(object sender, EventArgs e)
        {

            resetAllToolStripBtn(s => s.Enabled = false);
            recover_btn.Enabled = false;
            removeAll_btn.Enabled = false;
        }


        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
   
        }
        #endregion

        #region 菜单项事件
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String[] files = openShapefileDialog();
            if (files != null)
            {

                files = sortLayerWithCurLayer(files);
                clearAllLayers();

                try
                {
                    
                    //设置底图
                    axMap1.TileProvider = tkTileProvider.ProviderNone;
                    //依次加入图层
                    foreach (string file in files)
                    {
                        if (file.ToLower().Trim().EndsWith(".shp"))
                        {
                         

                            Shapefile sf = new Shapefile();

                            if (sf.Open(file, null))
                            {
                                
                                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmPan;

                                //layerHandle = axMap1.AddLayer(sf, true);    //加入sf图层
                                
                                if (true)
                                {
                                    string directoryName = Path.GetDirectoryName(file);//目录名
                                    string fileName = Path.GetFileNameWithoutExtension(file);//文件名
                                    
                                    
                                    Node target = findNode(x => {
                                        if (x.Path != "")
                                            return  x.NodeType == NodeType.group && Path.GetDirectoryName(x.Path) == directoryName;
                                        return false;
                                        });
                                    //当前目录是存在的 因此是子节点,不需要新增数据框
                                    if (target != null)
                                    {
                                        //把图层加载组中的最顶端
                                        addLayer(sf, target.LegendHandle);
                                        LegendNodes.Add(new Node(curLegendLayerHandle, target.LegendHandle, curLayerHandle, file));
                                        if (debug)
                                        {
                                            Debug.Print("组数：" + Legend.Groups.Count() + "\n" +
                                                            "图层树的图层数：" + Legend.Layers.Count() + "\n" +
                                                            "实际图层数：" + axMap1.NumLayers);
                                        }

                                    }
                                    //当前目录为新目录，需要重新创建根节点
                                    else
                                    {
                                        addGroup(directoryName);
                                        addLayer(sf, curLegendGroupHandle);
                                        LegendNodes.Add(new Node(curLegendGroupHandle, curLayerHandle, file));
                                        LegendNodes.Add(new Node(curLegendLayerHandle, curLegendGroupHandle, curLayerHandle, file));
                                        if (debug)
                                        {
                                            Debug.Print("组数：" + Legend.Groups.Count() + "\n" +
                                                            "图层树的图层数：" + Legend.Layers.Count() + "\n" +
                                                            "实际图层数：" + axMap1.NumLayers);
                                        }

                                    }

                                    //缩放至第一个图层
                                    axMap1.ZoomToLayer(Legend.Layers.First().Handle);
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
                            axMap1.set_LayerName(curLayerHandle, Path.GetFileName(file));
                        }
                            
                            
                    }
                }
                finally
                {
                    axMap1.LockWindow(tkLockMode.lmUnlock);
                    Debug.Print("Layers added to the map: " + axMap1.NumLayers);
                    
                }
            }
            


            }


        private void removeAll_btn_Click(object sender, EventArgs e)
        {
            clearAllLayers();
            if (debug)
            {
                MessageBox.Show("清空操作 \n" +
                    "组数：" + Legend.Groups.Count() + "\n" +
                                "图层树的图层数：" + Legend.Layers.Count() + "\n" +
                                "实际图层数：" + axMap1.NumLayers);
            }

        }

        private void pan_btn_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if (btn != null)
            {
                resetAllToolStripBtn(s => s.Checked = false);
                btn.Checked = true;
            }
            axMap1.CursorMode = MapWinGIS.tkCursorMode.cmPan;

        }

        private void zoomIn_btn_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if (btn != null)
            {
                resetAllToolStripBtn(s=>s.Checked=false);
                btn.Checked = true;
            }
            axMap1.CursorMode = MapWinGIS.tkCursorMode.cmZoomIn;
        }

        private void zoomOut_btn_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if (btn != null)
            {
                resetAllToolStripBtn(s => s.Checked = false);
                btn.Checked = true;
            }
            axMap1.CursorMode = MapWinGIS.tkCursorMode.cmZoomOut;
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            if (btn != null)
            {
                resetAllToolStripBtn(s => s.Checked = false);
                btn.Checked = true;
            }
            axMap1.CursorMode = MapWinGIS.tkCursorMode.cmSelection;
        }

        private void recover_btn_Click(object sender, EventArgs e)
        {
            LayerHelper.ZoomToLayer();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 重置工具栏button
        /// </summary>
        private void resetAllToolStripBtn(Action<ToolStripButton> action)
        {
            action(pan_btn);
            action(zoomIn_btn);
            action(zoomOut_btn);
            action(select_btn);
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
            MapWinGIS.ICallback call = null;
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
        private void addLayer(object layer,int targetGroup,int afterLayerHandle)
        {
            LayerHelper.AddLayer(layer, targetGroup, afterLayerHandle);
        }

        /// <summary>
        /// 寻找图层树中的节点
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        private Node findNode(Predicate<Node> predicate)
        {
            foreach(Node node in LegendNodes)
            {
                if (predicate(node))
                    return node;
            }
            return null;
        }

        //更新界面
        public void RefreshUI()
        {
           //每当触发了某些改变地图的事件，你也可以在这里做些什么
            if (axMap1.NumLayers == 0)
            {
                //禁用工具按钮
                resetAllToolStripBtn(s => s.Enabled = false);
                recover_btn.Enabled = false;
                removeAll_btn.Enabled = false;
            }

            Map.Focus();
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

     
    }
}
