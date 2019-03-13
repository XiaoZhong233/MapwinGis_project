using AxMapWinGIS;
using MapWinGIS;
using MapWinGis_Demo_zhw.Controls;
using MapWinGis_Demo_zhw.Manager;
using MapWinGis_Demo_zhw.Model;
using MWLite.Symbology.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MapWinGis_Demo_zhw.Forms
{
    public partial class MapDockForm : DockContent
    {
        //图层选择监听
        public event EventHandler<SelectionChangedArgs> SelectionChanged;
        private IdentifierContextMenu _identifierContextMenu = new IdentifierContextMenu();
        protected virtual void OnSelectionChanged(SelectionChangedArgs e)
        {
            EventHandler<SelectionChangedArgs> handler = SelectionChanged;
            if (handler != null) handler(this, e);
        }


        private bool ShowTooltip = true;

        internal AxMap Map
        {
            get { return axMap1; }
        }


        public MapDockForm()
        {
            InitializeComponent();
            RegisterEventHandlers();
        }

        private void InitMap()
        {
            axMap1.GrabProjectionFromData = true;
            axMap1.CursorMode = tkCursorMode.cmPan;
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

        private void RegisterEventHandlers()
        {

            //axMap1.MouseUpEvent += axMap_MouseDownEvent;
            axMap1.ProjectionChanged += axMap1_ProjectionChanged;
            axMap1.MouseMoveEvent += axMap1_MouseMoveEvent;
            axMap1.PreviewKeyDown += axMap1_PreviewKeyDown;
            axMap1.SelectionChanged += axMap1_SelectionChanged;
            axMap1.ShapeIdentified += axMap1_ShapeIdentified;
            axMap1.MouseUpEvent += axMap1_MouseUpEvent;
            axMap1.ShapeHighlighted += axMap1_ShapeHighlighted;
            axMap1.SelectBoxFinal += axMap1_SelectBoxFinal;
            axMap1.LayerProjectionIsEmpty += axMap1_LayerProjectionIsEmpty;
            axMap1.ProjectionMismatch += axMap1_ProjectionMismatch;
            axMap1.LayerReprojected += axMap1_LayerReprojected;
            axMap1.LayerAdded += axMap1_LayerAdded;
            axMap1.GridOpened += axMap1_GridOpened;
            axMap1.LayerRemoved += axMap1_LayerRemoved;
            axMap1.BackgroundLoadingStarted += axMap1_BackgroundLoadingStarted;
            axMap1.BackgroundLoadingFinished += axMap1_BackgroundLoadingFinished;
            axMap1.FileDropped += AxMap1FileDropped;

        }



        /// <summary>
        /// 点击测量选项时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuMeasuringOptions_Click(object sender, EventArgs e)
        {
            using (var form = new MeasuringForm(Map.Measuring))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    Map.Redraw2(tkRedrawType.RedrawSkipAllLayers);
                }
            }
        }

        /// <summary>
        /// 文件加载完成时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AxMap1FileDropped(object sender, _DMapEvents_FileDroppedEvent e)
        {
            LayerHelper.AddLayer(this.axMap1.FileManager.Open(e.filename));
        }

        /// <summary>
        /// 加载成功时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axMap1_BackgroundLoadingFinished(object sender, _DMapEvents_BackgroundLoadingFinishedEvent e)
        {
            Debug.Print("加载完成: {0}; TaskId: {1}; LayerHandle: {2} Features: {3}; Loaded: {4}",
            DateTime.Now.TimeOfDay.ToString(), e.taskId, e.layerHandle, e.numFeatures, e.numLoaded);
        }

        /// <summary>
        /// 底图加载开始时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axMap1_BackgroundLoadingStarted(object sender, _DMapEvents_BackgroundLoadingStartedEvent e)
        {
            Debug.Print("加载开始: {0}; TaskId: {1}; LayerHandle: {2}", DateTime.Now.TimeOfDay.ToString(), e.taskId, e.layerHandle);
        }

        /// <summary>
        /// 图层删除时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axMap1_LayerRemoved(object sender, _DMapEvents_LayerRemovedEvent e)
        {
            Debug.Print("Layer removed.");
        }

        /// <summary>
        /// 加入grid文件时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axMap1_GridOpened(object sender, _DMapEvents_GridOpenedEvent e)
        {
            Debug.Print("Grid is opened: " + e.gridFilename);
            Debug.Print("Using proxy: " + e.isUsingProxy);
            Debug.Print("BandIndex: " + e.bandIndex);
        }

        /// <summary>
        /// 加入图层时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axMap1_LayerAdded(object sender, _DMapEvents_LayerAddedEvent e)
        {
            Debug.Print("Layer added.");
        }

        /// <summary>
        /// 重投影时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axMap1_LayerReprojected(object sender, _DMapEvents_LayerReprojectedEvent e)
        {
            if (!e.success)
            {
                string filename = axMap1.get_LayerFilename(e.layerHandle);
                MessageHelper.Warn("失败: " + filename);
            }
            else
            {
                Debug.WriteLine("图层重投影:" + e.success);
            }
        }

        /// <summary>
        /// 当加入的要素如当前项目文件的投影不匹配时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axMap1_ProjectionMismatch(object sender, _DMapEvents_ProjectionMismatchEvent e)
        {
            var sf = axMap1.get_Shapefile(e.layerHandle);
            if (sf != null)
            {
                e.reproject = tkMwBoolean.blnTrue;
                e.cancelAdding = tkMwBoolean.blnFalse;
            }
            else
            {
                string filename = axMap1.get_LayerFilename(e.layerHandle);
                MessageHelper.Info("该图层与当前项目不匹配: " + filename);
            }
        }

        /// <summary>
        /// 当前项目为空时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axMap1_LayerProjectionIsEmpty(object sender, _DMapEvents_LayerProjectionIsEmptyEvent e)
        {
            Debug.Print("项目为空！");
        }

        /// <summary>
        /// 空间选择要素时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axMap1_SelectBoxFinal(object sender, _DMapEvents_SelectBoxFinalEvent e)
        {
            if (axMap1.CursorMode == tkCursorMode.cmSelection)
            {
                MessageHelper.Info("没有图层被选中！.");
            }
        }

        /// <summary>
        /// 当项目文档改变时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axMap1_ProjectionChanged(object sender, System.EventArgs e)
        {
            var gp = axMap1.GeoProjection;
            lblProjection.Text = gp.IsEmpty ? "No projection" : "Projection: " + gp.ExportToProj4();
        }

        /// <summary>
        /// 鼠标移动时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">map位置参数</param>
        private void axMap1_MouseMoveEvent(object sender, _DMapEvents_MouseMoveEvent e)
        {
            if (!axMap1.Focused)
                axMap1.Focus();
        }

        /// <summary>
        /// 鼠标按下前一刻触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axMap1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    e.IsInputKey = true;
                    return;
            }
        }

        /// <summary>
        /// 选中性发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axMap1_SelectionChanged(object sender, _DMapEvents_SelectionChangedEvent e)
        {
            //TODO:需要重写refresh（）
            App.RefreshUI();
        }

        /// <summary>
        /// 识别时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axMap1_ShapeIdentified(object sender, _DMapEvents_ShapeIdentifiedEvent e)
        {
            var sf = axMap1.get_Shapefile(e.layerHandle);
            if (sf != null)
            {
                //do something
                InformationForm informationForm = new InformationForm(Map, e);
                informationForm.Show();
            }
        }

        /// <summary>
        /// 鼠标抬起时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axMap1_MouseUpEvent(object sender, _DMapEvents_MouseUpEvent e)
        {
            if (e.button == 2)
            {
                if (axMap1.CursorMode == tkCursorMode.cmIdentify)
                {
                    _identifierContextMenu.Menu.Show(axMap1, e.x, e.y);
                }
                else if (axMap1.CursorMode == tkCursorMode.cmMeasure)
                {
                    contextMenuStrip1.Show(axMap1, e.x, e.y);
                }
            }
        }

        /// <summary>
        /// 高亮状态下触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void axMap1_ShapeHighlighted(object sender, _DMapEvents_ShapeHighlightedEvent e)
        {
            if (Map.CursorMode == tkCursorMode.cmIdentify && ShowTooltip)
            {
                //获取到选择的属性信息
                string s = Map.GetAttributes(e.layerHandle, e.shapeIndex);
                toolTip1.SetToolTip(Map, s);
                Application.DoEvents();
                
            }
        }


    }
}
