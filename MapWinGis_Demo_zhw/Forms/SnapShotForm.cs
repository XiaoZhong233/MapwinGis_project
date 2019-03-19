using MapWinGIS;
using MapWinGis_Demo_zhw.Helper;
using MapWinGis_Demo_zhw.Manager;
using MapWinGis_Demo_zhw.Model;
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

namespace MapWinGis_Demo_zhw.Forms
{
    public partial class SnapShotForm : DockContent, PreviewMap
    {
        
        internal bool m_ShowLocatorBox=true;
        internal System.Drawing.Rectangle g_ExtentsRect;
        internal bool g_Dragging;

        private int oldX;
        private int oldY;
        private int m_startX;
        private int m_startY;
        private int m_DrawHandle = -1;
        private int m_Color =  Microsoft.VisualBasic.Information.RGB(0, 0, 0);
        //private int m_Color = Color.OrangeRed.ToArgb();
        private int m_FillColor = Color.OrangeRed.ToArgb();
        private bool isAsk = true;

        public SnapShotForm()
        {
            InitializeComponent();
            InitPreview();
            RegisterEvt();
        }

        private void RegisterEvt()
        {
            //throw new NotImplementedException();
            MapPreview.SizeChanged += MapPreview_SizeChanged;
            MapPreview.MouseDownEvent += MapPreview_MouseDownEvent;
            MapPreview.MouseUpEvent += MapPreview_MouseUpEvent;
            MapPreview.MouseMoveEvent += MapPreview_MouseMoveEvent;
        }

        private void MapPreview_MouseMoveEvent(object sender, AxMapWinGIS._DMapEvents_MouseMoveEvent e)
        {
            //移动红色矩形框
            if (e.button == 1)
            {
                if (g_Dragging == true)
                {
                    g_ExtentsRect.Offset(e.x - oldX, e.y - oldY);
                    DrawBox(g_ExtentsRect);
                    oldX = e.x;
                    oldY = e.y;
                }
                else
                {
                    if (InBox(g_ExtentsRect, e.x, e.y))
                    {
                        MapPreview.MapCursor = MapWinGIS.tkCursor.crsrSizeAll;
                    }
                    else
                    {
                        MapPreview.MapCursor = MapWinGIS.tkCursor.crsrArrow;
                    }
                }
            }
            else
            {
                g_Dragging = false;
            }
        }

        private void MapPreview_MouseUpEvent(object sender, AxMapWinGIS._DMapEvents_MouseUpEvent e)
        {
            //添加鼠标按键判断，不允许除左键以外的行为
            if (e.button == 1)
            {
                //停止拖拽
                MapWinGIS.Extents newExts = new MapWinGIS.Extents();
                double xMin = -1, xMax = -1, yMin = -1, yMax = -1;
                if (g_Dragging)
                {
                    //PixelToProj：转换像素坐标为项目地图的坐标
                    MapPreview.PixelToProj(g_ExtentsRect.Left, g_ExtentsRect.Top, ref xMin, ref yMax); //矩形左上角
                    MapPreview.PixelToProj(g_ExtentsRect.Right,g_ExtentsRect.Bottom, ref xMax, ref yMin);//矩形右上角
                    newExts.SetBounds(xMin, yMin, 0, xMax, yMax, 0);
                    //设置鼠标样式
                    MapPreview.MapCursor = MapWinGIS.tkCursor.crsrSizeAll;
                    //同步到MapMain中的地图
                    App.Map.Extents = newExts;
                    newExts = null;
                    App.Map.Focus();
                }
                else //不是拖拽
                {
                    //当点击的点超出红色矩形框的范围，则以改点为中点移动红色矩形框
                    int curCenterX, curCenterY; //当前范围框的中点
                    curCenterX = (g_ExtentsRect.Right + g_ExtentsRect.Left) / 2;
                    curCenterY = (g_ExtentsRect.Bottom + g_ExtentsRect.Top) / 2;
                    g_ExtentsRect.Offset(e.x - curCenterX, e.y - curCenterY);//设置矩形框的位置

                    MapPreview.PixelToProj(g_ExtentsRect.Left, g_ExtentsRect.Top, ref xMin, ref yMax);
                    MapPreview.PixelToProj(g_ExtentsRect.Right, g_ExtentsRect.Bottom, ref xMax, ref yMin);
                    newExts.SetBounds(xMin, yMin, 0, xMax, yMax, 0);
                    //设置鼠标样式
                    MapPreview.MapCursor = MapWinGIS.tkCursor.crsrSizeAll;
                    // 同步到MapMain中的地图
                    App.Map.Extents = newExts;
                    newExts = null;
                    App.Map.Focus();
                }

            }
            g_Dragging = false;
        }

        private void MapPreview_MouseDownEvent(object sender, AxMapWinGIS._DMapEvents_MouseDownEvent e)
        {
            if (e.button == 2)//鼠标右键，在MapPreview上点击
            {
                //重复show可能是必须的，尤其当unlocked的时候,若右键出现问题放开下面语句试试
                //PreviewMapContextMenuStrip.Show(this, MapPreview.PointToClient(MousePosition));
                PreviewMapContextMenuStrip.Show(MapPreview, MapPreview.PointToClient(MousePosition));
            }
            else
            {
                //确定是否在拖动范围框
                if (InBox(g_ExtentsRect, e.x, e.y))
                {
                    g_Dragging = true;
                    oldX = e.x;
                    oldY = e.y;
                    m_startX = e.x;
                    m_startY = e.y;
                }
                else
                {
                    g_Dragging = false;
                }
            }

        }

        private void MapPreview_SizeChanged(object sender, EventArgs e)
        {
            UpdateLocatorBox();
        }

        public AxMapWinGIS.AxMap PreviewMap { get { return MapPreview; }  }

        public System.Drawing.Image Picture
        {
            get
            {
                try
                {
                    if (MapPreview.NumLayers > 0)
                    {
                        Helper.ImageUtils cvter = new Helper.ImageUtils();
                        //return cvter.IPictureDispToImage(MapPreview.SnapShot(MapPreview.Extents));
                        return cvter.IPictureDispToImage(((MapWinGIS.Image)(MapPreview.get_GetObject(MapPreview.get_LayerHandle(0)))).Picture);

                    }
                }
                catch(Exception ex)
                {
                    MessageHelper.Warn(ex.ToString());
                }
                return null;
            }

            set
            {
                try
                {
                    if (value != null)
                    {
                        m_ShowLocatorBox = false;
                        MapWinGIS.Image img = new MapWinGIS.Image();
                        Helper.ImageUtils cvter = new Helper.ImageUtils();
                        img.Picture = (stdole.IPictureDisp)(cvter.ImageToIPictureDisp(value));
                        PreviewMap.RemoveAllLayers();
                        MapPreview.AddLayer(img, true);
                        MapPreview.ZoomToMaxExtents();
                    }
                }
                catch(Exception ee)
                {
                    MessageHelper.Warn(ee.ToString());
                }
            }
        }
        public Color LocatorBoxColor
        {
            get
            {
                return Helper.ColorScheme.IntToColor(m_Color);
            }
            set
            {
                m_Color = Helper.ColorScheme.ColorToInt(value);
            }
        }

        private void InitPreview()
        {
            //初始化preview map设置，并强制重绘
            MapPreview.CursorMode = MapWinGIS.tkCursorMode.cmNone;
            MapPreview.MapCursor = MapWinGIS.tkCursor.crsrArrow;
            MapPreview.SendMouseDown = true;
            MapPreview.SendMouseMove = true;
            MapPreview.SendMouseUp = true;
            MapPreview.SendSelectBoxDrag = false;
            MapPreview.SendSelectBoxFinal = false;
            MapPreview.MouseWheelSpeed = 1.0;
            MapPreview.MapResizeBehavior = MapWinGIS.tkResizeBehavior.rbClassic;
            MapPreview.ScalebarVisible = false;
            MapPreview.ShowCoordinates = MapWinGIS.tkCoordinatesDisplay.cdmNone;

        }

        #region 接口实现
        internal void drawBox(System.Drawing.Rectangle rect)
        {
            uint color = Convert.ToUInt32(m_Color);

        }

        /// <summary>
        /// 按照传过来的地图重新显示地图
        /// </summary>
        public void GetPictureFromMap()
        {
            GetPictureFromMap(false);
        }




        /// <summary>
        /// 让PreviewMap重绘地图，根据主地图中当前范围传过来的数据 (current extents).
        /// </summary>
        public void Update()
        {
            GetPictureFromMap(false);
        }


        /// <summary>
        /// 更新自己的显示的地图.
        /// <param name="updateExtents">从当前范围还是从全图范围更新Preview的视图</param>
        /// </summary>
        public void Update(ePreviewUpdateExtents updateExtents)
        {
            GetPictureFromMap(updateExtents == ePreviewUpdateExtents.FullExtents ? true : false);
        }



        public void DockTo(DockStyle dockStyle)
        {
            throw new NotImplementedException();
        }

      

        /// <summary>
        /// 从指定的目录加载一张图片到PreviewMap中
        /// </summary>
        /// <param name="filename">图片的路径</param>
        /// <returns>true 加载成功，false，失败</returns>
        public bool GetPictureFromFile(string filename)
        {
            MapWinGIS.Image img = new MapWinGIS.Image();
            string extentName = MiscUtils.GetExtensionName(filename);
            if ((img.CdlgFilter.ToLower()).IndexOf(extentName.ToLower()) > 0)
            {
                if (img.Open(filename, MapWinGIS.ImageType.USE_FILE_EXTENSION, false) == false)
                {
                    MessageHelper.Info("打开文件并加载到Preview Map上失败") ;
                    return false;
                }
                else //文件打开
                {
                    string cutExtentName = filename.Substring(0, filename.Length - extentName.Length - 1);
                    string tStr = Path.GetDirectoryName(cutExtentName + ".*");
                    if (tStr != "")
                    {
                        switch (MiscUtils.GetExtensionName(tStr).ToLower())
                        {
                            case "bpw": //world类型的图片文件
                            case "gfw":
                                m_ShowLocatorBox = true;
                                break;
                            default: // 不是一个world类型的文件
                                m_ShowLocatorBox = false;
                                break;
                        }
                    }
                    MapPreview.AddLayer(img, true);
                }
            }
            else
            {
                MessageHelper.Info("不支持的图片格式");
                return false;
            }
            return true;
        }


        #endregion


        /// <summary>
        /// 更新PreviewMap的地图显示
        /// </summary>
        /// <param name="fullExtents">指示是否使用全图显示地图</param>
        public void GetPictureFromMap(bool fullExtents)
        {
            if (this.DockState == WeifenLuo.WinFormsUI.Docking.DockState.Hidden || this.DockState == DockState.DockLeftAutoHide)
                return;
            DateTime beforDT = System.DateTime.Now;
            beforDT = System.DateTime.Now;
            try
            {
                
                MapWinGIS.Extents exts;
                MapWinGIS.Image img = new MapWinGIS.Image();
                double ratio = 0;
                MapWinGIS.Extents oldExts = (MapWinGIS.Extents)App.Map.Extents;

                //锁定地图
                MapPreview.LockWindow(MapWinGIS.tkLockMode.lmLock);
                App.Map.LockWindow(MapWinGIS.tkLockMode.lmLock);

                if (fullExtents) //更新为全图显示，主地图也更新为全图显示
                {
                    //exts = MapExt.MaxVisibleExtents(App.Map);
                    if (MapPreview.Width < MapPreview.Height) //宽小于高
                    {
                        ratio = System.Convert.ToDouble(MapPreview.Width / App.Map.Width);
                    }
                    else //宽大于高
                    {
                        ratio = System.Convert.ToDouble(MapPreview.Height / App.Map.Height);
                    }
                    ratio *= 1.5; //缩放比例

                    //App.Map.Extents = exts;
                    //exts = (MapWinGIS.Extents)App.Map.Extents;

                    //int handle = App.Legend.SelectedLayer;
                    //Extents sf_et = App.Map.get_layerExtents(handle);
                    exts = (MapWinGIS.Extents)App.Map.MaxExtents;
                }
                else
                {
                    exts = (MapWinGIS.Extents)App.Map.Extents;
                }

                img = (MapWinGIS.Image)(App.Map.SnapShot(exts));

                ImageUtils cvter = new ImageUtils();
                System.Drawing.Image tmpImg = ImageUtils.ObjectToImage(img.Picture, System.Convert.ToInt32(img.Width * ratio), System.Convert.ToInt32(img.Height * ratio));

                //不建议更改透明度  渲染速度明显变慢
                //tmpImg = ImageUtils.img_alpha((Bitmap)tmpImg,255);
              
                img.Picture = (stdole.IPictureDisp)(cvter.ImageToIPictureDisp(tmpImg));
                img.dX = (exts.xMax - exts.xMin) / img.Width;
                img.dY = (exts.yMax - exts.yMin) / img.Height;
                img.XllCenter = exts.xMin + 0.5 * img.dX;
                img.YllCenter = exts.yMin + 0.5 * img.dX;
                img.DownsamplingMode = MapWinGIS.tkInterpolationMode.imHighQualityBicubic;
                img.UpsamplingMode = MapWinGIS.tkInterpolationMode.imHighQualityBicubic;

                MapPreview.RemoveAllLayers();
                MapPreview.AddLayer(img, true);
                MapPreview.ExtentPad = 0;
                MapPreview.ZoomToMaxExtents();
                m_ShowLocatorBox = true;
                UpdateLocatorBox();

                //Program.frmMain.mnuZoomPreviewMap.Enabled = Program.frmMain.MapMain.NumLayers > 0 && Program.frmMain.PreviewMapExtentsValid();
                //if (Program.frmMain.m_Menu["mnuZoomToPreviewExtents"] != null)
                //{
                //    Program.frmMain.m_Menu["mnuZoomToPreviewExtents"].Enabled = Program.frmMain.MapMain.NumLayers > 0 && Program.frmMain.PreviewMapExtentsValid();
                //}

            }
            catch (Exception ex)
            {
                //MessageHelper.Warn(ex.ToString());
            }
            finally
            {
                //解锁地图
               MapPreview.LockWindow(MapWinGIS.tkLockMode.lmUnlock);
               App.Map.LockWindow(MapWinGIS.tkLockMode.lmUnlock);
            }

            DateTime afterDT = System.DateTime.Now;
            TimeSpan ts = afterDT.Subtract(beforDT);
            //MessageBox.Show("DateTime总共花费"+ ts.TotalMilliseconds + "ms.");
            Debug.Print("DateTime总共花费{0}ms.", ts.TotalMilliseconds);
            if (ts.TotalMilliseconds > 300 && isAsk)
            {
                if (MessageHelper.Ask("当前图层数据量过大，由于鸟瞰图会不断截\n取影像快照造成渲染速度降低。\n为了加快渲染速度，是否关闭鸟瞰图？")== DialogResult.Yes)
                {
                    //this.Close();
                    this.DockState = WeifenLuo.WinFormsUI.Docking.DockState.Hidden;
                    
                }
                else
                {
                    isAsk = false;
                }
            }
            

        }


        /// <summary>
        /// 更新当前的红色矩形盒
        /// </summary>
        internal void UpdateLocatorBox()
        {
            try
            {
                MapPreview.ZoomToMaxExtents();
            }
            catch
            {

            }
            
            MapWinGIS.Extents exts = App.Map.Extents;
            double newLeft = 0; ;
            double newRight = 0;
            double newTop = 0;
            double newBottom = 0;

            if (m_ShowLocatorBox == false) //不显示红色方框盒子，则清空返回
            {
                MapPreview.ClearDrawings();
                return;
            }

            //获取盒子线条宽度
            MapPreview.ProjToPixel(exts.xMin, exts.yMax, ref newLeft, ref newTop);
            MapPreview.ProjToPixel(exts.xMax, exts.yMin, ref newRight, ref newBottom);

            try
            {
                g_ExtentsRect = new System.Drawing.Rectangle((int)newLeft, (int)newTop, System.Convert.ToInt32(newRight - newLeft), System.Convert.ToInt32(newBottom - newTop));

                DrawBox(g_ExtentsRect);//绘制
            }
            catch
            {
                //忽略这个异常，因为可能范围溢出
            }
            
        }


        /// <summary>
        /// 绘制一个(红色)方框盒子
        /// </summary>
        internal void DrawBox(System.Drawing.Rectangle rect)
        {
            uint color = Convert.ToUInt32(m_Color);
            //ColorConverter wcc = new ColorConverter();
            //Color c = (Color)wcc.ConvertFromString("#A6003000");
            //uint color = (uint)c.ToArgb();
            //uint color = #1e000000;
            if (m_DrawHandle >= 0)
            {
                MapPreview.ClearDrawing(m_DrawHandle);
            }
            m_DrawHandle = MapPreview.NewDrawing(MapWinGIS.tkDrawReferenceList.dlScreenReferencedList);

            MapPreview.DrawLine(rect.Left, rect.Top, rect.Right, rect.Top, 2, color);
            MapPreview.DrawLine(rect.Right, rect.Top, rect.Right, rect.Bottom, 2, color);
            MapPreview.DrawLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom, 2, color);
            MapPreview.DrawLine(rect.Left, rect.Bottom, rect.Left, rect.Top, 2, color);
            //double[] xPoint = { rect.Left,rect.Left, rect.Right, rect.Right };
            //double[] yPoint = { rect.Top, rect.Bottom, rect.Bottom, rect.Top };
            //object x = xPoint;
            //object y = yPoint;
            //MapPreview.DrawPolygon(ref x,ref y, 4, color, true);
        }

        /// <summary>
        /// 计算给点的x,y坐标是否在矩形框内
        /// </summary>
        private bool InBox(Rectangle rect, double x, double y)
        {
            if (x >= rect.Left && x <= rect.Right && y <= rect.Bottom && y >= rect.Top)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新preview map的视图
        /// </summary>
        /// <param name="FullExtents">是更新全图true，还是更新当前视图false</param>
        private void DoUpdatePreview(bool FullExtents = false)//更新Preview Map
        {
            GetPictureFromMap(FullExtents);
            //SetModified(true);
        }

        /// <summary>
        /// 右击全图事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 全局视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoUpdatePreview(true);
        }



        private void 当前视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoUpdatePreview();
        }

        private void 清除预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoClearPreview();
        }

        private void DoClearPreview()
        {
            MapPreview.ClearDrawings();
            MapPreview.RemoveAllLayers();
        }
    }


}
