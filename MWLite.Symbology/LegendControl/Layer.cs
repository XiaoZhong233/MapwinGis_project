

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using MapWinGIS;
using MWLite.Symbology.Classes;

namespace MWLite.Symbology.LegendControl
{

    //图层
    public class Layer
    {
        #region Declarations
        public object Tag = null;
        
        // 符号设置
        private SymbologySettings m_symbologySettings = new SymbologySettings();
        private Size textSize = new Size(0, 0);
        private bool m_Expanded;
        private Legend m_Legend;
        private int m_height;
        private object m_Icon;
        private eLayerType m_LayerType;
        private bool m_UseDynamicVisibility;
        internal List<LayerElement> Elements;  
        internal bool m_smallIconWasDrawn;

        public ShapefileBinding ShapefileBinding;

        /// <summary>
        /// 图层的颜色列表
        /// </summary>
        protected internal ArrayList ColorLegend;

        /// <summary>
        /// 图层最高位
        /// </summary>
        protected internal int Top;

        /// <summary>
        /// 强制展开
        /// </summary>
        public bool ExpansionBoxForceAllowed = false;

        /// <summary>
        /// 描绘一个展开得到层的区域，并且必须设置ExpansionBoxCustomHeightFunction
        /// </summary>
        public ExpansionBoxCustomRenderer ExpansionBoxCustomRenderFunction = null;

        /// <summary>
        /// 告诉legend你的自定义描绘Legend的高度，以便设置子条目的的尺寸
        /// </summary>
        public ExpansionBoxCustomHeight ExpansionBoxCustomHeightFunction = null;

        /// <summary>
        /// 这个层的句柄（handle），在MapWinGIS.Map中获取的
        /// </summary>
        protected internal int m_Handle;//handle of the associate layer from the Map Object

        /// <summary>
        /// 存贮layer中附加的信息
        /// </summary>
        public Hashtable m_CustomObjects = null;

        /// <summary>
        /// 获取附加的信息
        /// </summary>
        public object GetCustomObject(string key)
        {
            return m_CustomObjects[key];
        }

        /// <summary>
        /// 设置附加信息
        /// </summary>
        public void SetCustomObject(object obj, string key)
        {
            m_CustomObjects[key] = obj;
        }

       
        protected internal bool HasTransparency;

        /// <summary>
        /// 指示在绘制图例时是否隐藏该层。
        /// </summary>
        private bool m_HideFromLegend;

        /// <summary>
        /// 指示用于显示地图工具提示的字段索引。
        /// </summary>
        public int MapTooltipFieldIndex = -1;

        /// <summary>
        /// 指示是否为该层显示地图工具提示。
        /// </summary>
        public bool MapTooltipsEnabled = false;

        /// <summary>
        /// (Doesn't apply to line shapefiles)
        /// 指示顶点是否显示
        /// </summary>
        public bool VerticesVisible = false;

    
        public string StippleSchemeFieldCaption = "";


        public string ColorSchemeFieldCaption = "";

        public string PointImageFieldCaption = "";

        #endregion "Member Variables"

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Layer(Legend leg)
        {
            //The next line MUST GO FIRST in the constructor
            m_Legend = leg;
            //The previous line MUST GO FIRST in the constructor

            Expanded = true; //(m_Legend.m_Map.ShapeDrawingMethod == MapWinGIS.tkShapeDrawingMethod.dmNewSymbology);
            //Expanded = false;

            ColorLegend = new ArrayList();
            m_Handle = -1;
            m_Icon = null;
            m_LayerType = eLayerType.Invalid;
            m_UseDynamicVisibility = false;
            HasTransparency = false;

            Elements = new List<LayerElement>();
            ShapefileBinding = new ShapefileBinding();

            //_symbologySettings = new SymbologySettings();
            m_CustomObjects = new Hashtable();
            m_smallIconWasDrawn = false;
            //m_height = 0;
        }
        #endregion

        #region Properties

        public OgrLayer OgrLayer
        {
            get { return m_Legend.Map.OgrLayer[Handle]; }
        }

        /// <summary>
        /// Gets a snapshot (bitmap) of the layer
        /// </summary>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        public System.Drawing.Bitmap Snapshot()
        {
            return m_Legend.LayerSnapshot(this.Handle);
        }

        /// <summary>
        /// Gets a snapshot (bitmap) of the layer
        /// </summary>
        /// <param name="imgWidth">Desired width in pixels of the snapshot</param>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        public System.Drawing.Bitmap Snapshot(int imgWidth)
        {
            return m_Legend.LayerSnapshot(this.Handle, imgWidth);
        }

        /// <summary>
        /// Returns the underlying object, either image or shapefile
        /// </summary>
        public object GetObject()
        {
            return this.m_Legend.Map.get_GetObject(this.Handle);
        }

        /// <summary>
        /// Settings of the symbology dialogs for the layer
        /// </summary>
        internal SymbologySettings SymbologySettings
        {
            get { return m_symbologySettings; }
            set { m_symbologySettings = value; }
        }

        /// <summary>
        /// Returns filename of the layer source
        /// </summary>
        public string FileName
        {
            get { return this.m_Legend.Map.get_LayerFilename(this.Handle); }
        }

        /// <summary>
        /// Returns the name of the layer
        /// </summary>
        public string Name
        {
            get
            {
                return this.m_Legend.Map.get_LayerName(this.Handle); 
            }
            set
            {
                this.m_Legend.Map.set_LayerName(this.Handle, value);
            }
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        public SizeF MeasureCaption(Graphics g, Font font, int maxWidth)
        {
            return g.MeasureString(this.Name, font, maxWidth);
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        public SizeF MeasureCaption(Graphics g, Font font, int maxWidth, string otherName, StringFormat format)
        {
            return g.MeasureString(otherName, font, maxWidth, format);
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        public SizeF MeasureCaption(Graphics g, Font font)
        {
            return g.MeasureString(this.Name, font);
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        public SizeF MeasureCaption(Graphics g, Font font, string otherName)
        {
            return g.MeasureString(otherName, font);
        }

        /// <summary>
        /// Gets the Handle for this layer
        /// </summary>
        public int Handle { get { return m_Handle; } }

        /// <summary>
        /// Gets or sets the data type of the layer.
        /// Note:  This property should only be set when specifying a
        /// grid layer.  Shapefile layers and image layers are automatically
        /// set to the correct value
        /// </summary>
        public eLayerType Type
        {
            get { return m_LayerType; }
            set { m_LayerType = value; }
        }

        /// <summary>
        /// Specifies whether or not the layer should be using dynamic visibility.  The legend will draw the check box grey if the layer is using dynamic visibility.
        /// </summary>
        public bool UseDynamicVisibility
        {
            get
            {
                return m_Legend.m_Map.get_LayerDynamicVisibility(this.Handle);
            }
            set
            {
                m_Legend.m_Map.set_LayerDynamicVisibility(this.Handle, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum scale at which the layer is still visible when dynamic visibility is used
        /// </summary>
        public double MaxVisibleScale
        {
            get { return m_Legend.m_Map.get_LayerMaxVisibleScale(this.m_Handle); }
            set { m_Legend.m_Map.set_LayerMaxVisibleScale(this.m_Handle, value); }
        }

        /// <summary>
        /// Gets or sets the maximum zoom at which the layer is still visible when dynamic visibility is used
        /// </summary>
        public int MaxVisibleZoom
        {
            get { return m_Legend.m_Map.get_LayerMaxVisibleZoom(this.m_Handle); }
            set { m_Legend.m_Map.set_LayerMaxVisibleZoom(this.m_Handle, value); }
        }

        /// <summary>
        /// Gets or sets the minimum scale at which the layer is still visible when dynamic visibility is used
        /// </summary>
        public double MinVisibleScale
        {
            get { return m_Legend.m_Map.get_LayerMinVisibleScale(this.m_Handle); }
            set { m_Legend.m_Map.set_LayerMinVisibleScale(this.m_Handle, value); }
        }

        /// <summary>
        /// Gets or sets the minimum zoom at which the layer is still visible when dynamic visibility is used
        /// </summary>
        public int MinVisibleZoom
        {
            get { return m_Legend.m_Map.get_LayerMinVisibleZoom(this.m_Handle); }
            set { m_Legend.m_Map.set_LayerMinVisibleZoom(this.m_Handle, value); }
        }

        /// <summary>
        /// Gets or sets key of a layer
        /// </summary>
        public string GuidKey
        {
            get { return m_Legend.m_Map.get_LayerKey(this.m_Handle); }
            set { m_Legend.m_Map.set_LayerKey(this.m_Handle, value); }
        }
        #endregion

        /// <summary>
        /// 刷新UI
        /// </summary>
        public void Refresh()
        {
            //NewColorLegend = m_Legend.m_Map.GetColorScheme(this.Handle);
            m_Legend.Redraw();
        }

        
        public object Icon
        {
            get
            {
                return m_Icon;
            }
            set
            {
                if (globals.IsSupportedPicture(value))
                {
                    m_Icon = value;
                }
                else
                {
                    throw new System.Exception("Legend Error: Invalid Group Icon type");
                }
            }
        }

        
        protected internal int CalcHeight(bool UseExpandedHeight)
        {
            // to affect drawing of the expansion box externally
            if (m_Expanded && ExpansionBoxCustomHeightFunction != null)
            {
                int ht = Constants.ITEM_HEIGHT;
                bool Handled = false;
                ExpansionBoxCustomHeightFunction(m_Handle, m_Legend.Width, ref ht, ref Handled);
                if (Handled)
                    return ht + Constants.ITEM_HEIGHT + Constants.EXPAND_BOX_TOP_PAD * 2;
                else
                    return Constants.ITEM_HEIGHT;
            }

            int ret = 0;

            if (this.Type == eLayerType.Grid || this.Type == eLayerType.Image)
            {
                
                if (UseExpandedHeight == false && (m_Expanded == false || ColorLegend.Count == 0)) //|| (this.Type == eLayerType.Image))
                    ret = Constants.ITEM_HEIGHT;
                else
                    ret = Constants.ITEM_HEIGHT + (ColorLegend.Count * Constants.CS_ITEM_HEIGHT) + 2;

                
                if (UseExpandedHeight || m_Expanded)
                    ret += (ColorSchemeFieldCaption.Trim() != "" ? Constants.CS_ITEM_HEIGHT : 0) + (StippleSchemeFieldCaption.Trim() != "" ? Constants.CS_ITEM_HEIGHT : 0);
            }
            else
            {
                var sf = m_Legend.m_Map.get_Shapefile(this.Handle);

                if ((UseExpandedHeight || m_Expanded) && sf != null)
                {
                    ret = Constants.ITEM_HEIGHT + 2;                            // 图层名

                   
                    int val1, val2;
                    val1 = (GetCategoryHeight(sf.DefaultDrawingOptions) + 2);  // 默认图例

                    if (sf.Labels.Count == 0 || sf.Labels.Visible == false || true) 
                    {
                        ret += val1;
                    }
                    else
                    {
                        
                        LabelStyle style = new LabelStyle(sf.Labels.Options);
                        System.Drawing.Bitmap img = new System.Drawing.Bitmap(500, 200);
                        Graphics g = Graphics.FromImage(img);
                        Size size = style.MeasureString(g, "String", 30);
                        val2 = size.Height + 2;
                        ret += val1 > val2 ? val1 : val2;
                    }

                    if (sf.Categories.Count > 0)
                    {
                        ret += Constants.CS_ITEM_HEIGHT + 2;   // 标题

                        MapWinGIS.ShapefileCategories categories = sf.Categories;
                        if (this.Type == eLayerType.LineShapefile || this.Type == eLayerType.PolygonShapefile)
                        {
                            ret += sf.Categories.Count * (Constants.CS_ITEM_HEIGHT + 2);
                        }
                        else
                        {
                            for (int i = 0; i < sf.Categories.Count; i++)
                            {
                                ret += GetCategoryHeight(categories.get_Item(i).DrawingOptions);
                            }
                        }
                        ret += 2;
                    }

                    if (sf.Charts.Count > 0 && sf.Charts.NumFields > 0 && sf.Charts.Visible)
                    {
                        ret += (Constants.CS_ITEM_HEIGHT + 2);   // 标题
                        ret += sf.Charts.IconHeight;
                        ret += 2;

                        ret += (sf.Charts.NumFields * (Constants.CS_ITEM_HEIGHT + 2));
                    }
                }
                else
                    ret = Constants.ITEM_HEIGHT;

                // TODO: 标题宽度
                //if (UseExpandedHeight || m_Expanded)
                //    ret += (ColorSchemeFieldCaption.Trim() != "" ? Constants.CS_ITEM_HEIGHT : 0) + (StippleSchemeFieldCaption.Trim() != "" ? Constants.CS_ITEM_HEIGHT : 0);
            }

            m_height = ret;  

            return ret;
        }


        public int GetCategoryHeight(MapWinGIS.ShapeDrawingOptions options)
        {
            if (this.Type == eLayerType.PolygonShapefile || this.Type == eLayerType.LineShapefile)
            {
                return Constants.CS_ITEM_HEIGHT + 2;
            }
            
            if (this.Type == eLayerType.PointShapefile)
            {
                if (options.PointType == tkPointSymbolType.ptSymbolPicture && options.Picture != null)
                {
                    return options.Picture.Height * options.PictureScaleY + 2 <= Constants.CS_ITEM_HEIGHT || options.Picture == null ? Constants.CS_ITEM_HEIGHT + 2 : (int)(options.Picture.Height * options.PictureScaleY + 2);
                }
                
                switch(options.PointType)
                {
                    case tkPointSymbolType.ptSymbolFontCharacter:
                        double ratio = options.FrameVisible ? 1.4 : 0.9;
                        return (options.PointSize * ratio) + 2 <= Constants.CS_ITEM_HEIGHT ? Constants.CS_ITEM_HEIGHT : (int)(options.PointSize * ratio);
                    default:
                        return options.PointSize + 2 <= Constants.CS_ITEM_HEIGHT ? Constants.CS_ITEM_HEIGHT + 2: (int)options.PointSize + 2;
                }
            }

            return 0;
        }


        public int GetCategoryWidth(ShapeDrawingOptions options)
        {
            const int maxWidth = 100;
            if (this.Type == eLayerType.PolygonShapefile || this.Type == eLayerType.LineShapefile)
            {
                return Constants.ICON_WIDTH;
            }
            else if (this.Type == eLayerType.PointShapefile)
            {
                int width = 0;

                if (options.PointType == tkPointSymbolType.ptSymbolPicture && options.Picture != null)
                {
                    width = (options.Picture.Width * options.PictureScaleX <= Constants.ICON_WIDTH) ? Constants.ICON_WIDTH : (int)(options.Picture.Width * options.PictureScaleX);
                }
                
                switch (options.PointType)
                {
                    case tkPointSymbolType.ptSymbolFontCharacter:
                        double ratio = options.FrameVisible ? 1.4 : 1.0;
                        width = options.PointSize * ratio <= Constants.ICON_WIDTH ? Constants.ICON_WIDTH : (int)(options.PointSize * ratio);
                        break;
                    default:
                        width = options.PointSize <= Constants.ICON_WIDTH ? Constants.ICON_WIDTH : (int) options.PointSize;
                        break;

                }
                return width <= maxWidth ? width : maxWidth;
            }
            else
                return 0;
        }


        public int get_MaxIconWidth(MapWinGIS.Shapefile sf)
        {
            if (sf == null)
                return 0;
            int maxWidth = GetCategoryWidth(sf.DefaultDrawingOptions);
            for (int i = 0; i < sf.Categories.Count; i++)
            {
                int width = GetCategoryWidth(sf.Categories.get_Item(i).DrawingOptions);
                if (width > maxWidth)
                    maxWidth = width;
            }
            return maxWidth;
        }


        protected internal int CalcHeight()
        {
            return CalcHeight(this.Expanded);
        }

        public int Height
        {
            get
            {
                return CalcHeight();
            }
        }

        /// <summary>
        /// 指示是否展开
        /// </summary>
        public bool Expanded
        {
            get
            {
                return m_Expanded;
            }
            set
            {
                m_Expanded = value;
                m_Legend.Redraw();
            }
        }

        /// <summary>
        /// 指示可见性
        /// </summary>
        public bool Visible
        {
            get
            {
                return m_Legend.m_Map.get_LayerVisible(m_Handle);
            }
            set
            {
                bool oldVal = m_Legend.m_Map.get_LayerVisible(m_Handle);
                if (oldVal != value)
                {
                    m_Legend.m_Map.set_LayerVisible(m_Handle, value);
                    m_Legend.Redraw();
                }
            }
        }

        /// <summary>
        /// 当保存项目时，指示是否跳过该层
        /// </summary>
        public bool SkipOverDuringSave
        {
            get
            {
                return m_Legend.m_Map.get_LayerSkipOnSaving(this.Handle);
                //return m_SkipDuringSave;
            }
            set
            {
                m_Legend.m_Map.set_LayerSkipOnSaving(this.Handle, value);
                //m_SkipDuringSave = value;
            }
        }

        /// <summary>
        /// 指示是否隐藏
        /// </summary>
        public bool HideFromLegend
        {
            get
            {
                return m_HideFromLegend;
            }
            set
            {
                m_HideFromLegend = value;
            }
        }
    }
}