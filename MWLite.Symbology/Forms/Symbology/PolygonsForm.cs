
using System;
using System.Drawing;
using System.Windows.Forms;
using MWLite.Symbology.Classes;
using MWLite.Symbology.Controls;
using MapWinGIS;
using MWLite.Symbology.LegendControl;
using ListControl = MWLite.Symbology.Controls.ListControls.ListControl;

namespace MWLite.Symbology.Forms.Symbology
{
    public partial class PolygonsForm : Form
    {
        // member variables
        private Layer m_layer = null;
        private ShapeDrawingOptions _options = null;
        private LegendControl.Legend m_legend = null;
        private bool _noEvents = false;
        private static int _tabPage = 0;
        private string _initState = "";

        #region Initialization
        public PolygonsForm(LegendControl.Legend legend, Layer layer, ShapeDrawingOptions options, bool applyDisabled)
        {
            InitializeComponent();

            if (options == null || layer == null)
            {
                throw new Exception("PolygonsForm: unexpected null parameter");
            }
            else
            {
                _options = options;
                m_layer = layer;
            }

            m_legend = legend;
            btnApply.Visible = !applyDisabled;

            _initState = options.Serialize();

            _noEvents = true;
            groupPicture.Parent = tabPage2;
            groupPicture.Top = groupGradient.Top;
            groupPicture.Left = groupGradient.Left;

            groupHatch.Parent = tabPage2;
            groupHatch.Top = groupGradient.Top;
            groupHatch.Left = groupGradient.Left;

            cboFillType.Items.Clear();
            cboFillType.Items.Add("实心");
            cboFillType.Items.Add("填充线");
            cboFillType.Items.Add("渐变");
            //cboFillType.Items.Add("Texture");

            cboGradientType.Items.Clear();
            cboGradientType.Items.Add("线性渐变");
            cboGradientType.Items.Add("矩形渐变");
            cboGradientType.Items.Add("圆形渐变");

            cboGradientBounds.Items.Clear();
            cboGradientBounds.Items.Add("整个图层");
            cboGradientBounds.Items.Add("每个形状");

            cboVerticesType.Items.Clear();
            cboVerticesType.Items.Add("方形");
            cboVerticesType.Items.Add("圆形");
            
            icbHatchStyle.ComboStyle = ImageComboStyle.HatchStyle;
            icbLineType.ComboStyle = ImageComboStyle.LineStyle;
            icbLineWidth.ComboStyle = ImageComboStyle.LineWidth;

            // loading icons
            string path = Globals.GetTexturesPath();
            if (System.IO.Directory.Exists(path))
            {
                iconControl1.FilePath = path;
                iconControl1.Textures = true;

                SymbologySettings settings = Globals.get_LayerSettings(layer.Handle);
                iconControl1.SelectedIndex = settings.IconIndex;
            }
            else
            {
                udScaleX.Enabled = false;
                udScaleY.Enabled = false;
            }

            _noEvents = false;

            cboFillType.SelectedIndexChanged += new EventHandler(cboFillType_SelectedIndexChanged);

            Options2GUI();

            // -----------------------------------------------------
            // 订阅事件
            // -----------------------------------------------------
            // fill
            chkFillVisible.CheckedChanged += new EventHandler(GUI2Options);
            clpFill.SelectedColorChanged += new EventHandler(GUI2Options);

            // hatch
            icbHatchStyle.SelectedIndexChanged += new EventHandler(GUI2Options);
            chkFillBgTransparent.CheckedChanged += new EventHandler(GUI2Options);
            clpHatchBack.SelectedColorChanged += new EventHandler(GUI2Options);

            // gradient
            clpGradient2.SelectedColorChanged += new EventHandler(GUI2Options);
            udGradientRotation.ValueChanged += new EventHandler(GUI2Options);
            cboGradientType.SelectedIndexChanged += new EventHandler(GUI2Options);
            cboGradientBounds.SelectedIndexChanged += new EventHandler(GUI2Options);

            // outline
            chkOutlineVisible.CheckedChanged += new EventHandler(GUI2Options);
            icbLineType.SelectedIndexChanged += new EventHandler(GUI2Options);
            icbLineWidth.SelectedIndexChanged += new EventHandler(GUI2Options);
            clpOutline.SelectedColorChanged += new EventHandler(GUI2Options);

            // vertices
            chkVerticesVisible.CheckedChanged += new EventHandler(GUI2Options);
            cboVerticesType.SelectedIndexChanged += new EventHandler(GUI2Options);
            clpVerticesColor.SelectedColorChanged += new EventHandler(GUI2Options);
            chkVerticesFillVisible.CheckedChanged += new EventHandler(GUI2Options);
            udVerticesSize.ValueChanged += new EventHandler(GUI2Options);

            udScaleX.ValueChanged += new EventHandler(GUI2Options);
            udScaleY.ValueChanged += new EventHandler(GUI2Options);

            iconControl1.SelectionChanged += new ListControl.SelectionChangedDel(iconControl1_SelectionChanged);

            DrawPreview();

            tabControl1.SelectedIndex = _tabPage;
        }
        #endregion


        void iconControl1_SelectionChanged()
        {
            string filename = iconControl1.SelectedName;
            if (filename == string.Empty)
            {
                return;
            }
            
            Bitmap bmp = new Bitmap(filename);
            Color clrTransparent = Color.White;
            for (int i = 0; i < bmp.Width; i++)
            {
                int j;
                for (j = 0; j < bmp.Height; j++)
                {
                    Color clr = bmp.GetPixel(i, j);
                    if (clr.A == 0)
                    {
                        clrTransparent = clr;
                        break;
                    }
                }
                if (j != bmp.Width)
                {
                    break;
                }
            }

            MapWinGIS.Image img = new MapWinGIS.Image();
            if (img.Open(filename, ImageType.USE_FILE_EXTENSION, true, null))
            {
                img.LoadBuffer(50);

                img.TransparencyColor = Colors.ColorToUInteger(clrTransparent);
                img.TransparencyColor2 = Colors.ColorToUInteger(clrTransparent);
                img.UseTransparencyColor = true;

                _options.Picture = img;

                DrawPreview();
            }
            else
            {
                string errString = string.Empty;
                if (img.LastErrorCode != 0)
                {
                    errString = ": " + img.get_ErrorMsg(img.LastErrorCode);
                }
                Globals.MessageBoxError("Failed to open image: " + errString);
            }
        }

        #region OptionsExchange
        /// <summary>
        /// 设置绘制选项
        /// </summary>
        private void GUI2Options(object sender, EventArgs e)
        {
            if (_noEvents)
            {
                return;
            }

            // fill
            _options.FillVisible = chkFillVisible.Checked;
            _options.FillType = (tkFillType)cboFillType.SelectedIndex;
            _options.FillColor = Colors.ColorToUInteger(clpFill.Color);

            // hatch
            _options.FillHatchStyle = (tkGDIPlusHatchStyle)icbHatchStyle.SelectedIndex;
            _options.FillBgTransparent = chkFillBgTransparent.Checked;
            _options.FillBgColor = Colors.ColorToUInteger(clpHatchBack.Color);

            // gradient
            _options.FillGradientType = (tkGradientType)cboGradientType.SelectedIndex;
            _options.FillColor2 = Colors.ColorToUInteger(clpGradient2.Color);
            _options.FillRotation = (double)udGradientRotation.Value;
            _options.FillGradientBounds = (tkGradientBounds)cboGradientBounds.SelectedIndex;

            // texture
            _options.PictureScaleX = (double)udScaleX.Value;
            _options.PictureScaleY = (double)udScaleY.Value;

            // outline
            _options.LineStipple = (tkDashStyle)icbLineType.SelectedIndex;
            _options.LineWidth = (float)icbLineWidth.SelectedIndex + 1;
            _options.LineVisible = chkOutlineVisible.Checked;
            _options.LineColor = Colors.ColorToUInteger(clpOutline.Color);

            // vertices
            _options.VerticesVisible = chkVerticesVisible.Checked;
            _options.VerticesFillVisible = chkVerticesFillVisible.Checked;
            _options.VerticesSize = (int)udVerticesSize.Value;
            _options.VerticesColor = Colors.ColorToUInteger(clpVerticesColor.Color);
            _options.VerticesType = (tkVertexType)cboVerticesType.SelectedIndex;

            // transparency
            _options.LineTransparency = (float)transpOutline.Value;
            _options.FillTransparency = (float)transpFill.Value;

            //int val;
            //if (Int32.TryParse(cboLineTransparency.Text, out val))
            //{
            //    _options.LineTransparency = (int)((double)(val) * 2.55 + 0.5);
            //}
            //if (Int32.TryParse(cboFillTransparency.Text, out val))
            //{
            //    _options.FillTransparency = (int)((double)(val) * 2.55 + 0.5);
            //}

            btnApply.Enabled = true;

            DrawPreview();
        }

        /// <summary>
        /// 加载图例的属性
        /// </summary>
        private void Options2GUI()
        {
            _noEvents = true;

            // options
            icbLineType.SelectedIndex = (int)_options.LineStipple;
            icbLineWidth.SelectedIndex = (int)_options.LineWidth - 1;
            cboFillType.SelectedIndex = (int)_options.FillType;
            chkOutlineVisible.Checked = _options.LineVisible;
            clpOutline.Color = Colors.UintToColor(_options.LineColor);
            chkFillVisible.Checked = _options.FillVisible;

            // hatch
            icbHatchStyle.SelectedIndex = (int)_options.FillHatchStyle;
            chkFillBgTransparent.Checked = _options.FillBgTransparent;
            clpHatchBack.Color = Colors.UintToColor(_options.FillBgColor);

            // gradient
            cboGradientType.SelectedIndex = (int)_options.FillGradientType;
            clpGradient2.Color = Colors.UintToColor(_options.FillColor2);
            udGradientRotation.Value = (decimal)_options.FillRotation;

            clpFill.Color = Colors.UintToColor(_options.FillColor);
            cboGradientBounds.SelectedIndex = (int)_options.FillGradientBounds;
            chkOutlineVisible.Checked = _options.LineVisible;

            // texture
            udScaleX.SetValue(_options.PictureScaleX);
            udScaleY.SetValue(_options.PictureScaleY);

            // vertices
            chkVerticesVisible.Checked = _options.VerticesVisible;
            chkVerticesFillVisible.Checked = _options.VerticesFillVisible;
            udVerticesSize.SetValue(_options.VerticesSize);
            clpVerticesColor.Color = Colors.UintToColor(_options.VerticesColor);
            cboVerticesType.SelectedIndex = (int)_options.VerticesType;

            // transparency
            //cboFillTransparency.Text = ((int)((double)(_options.FillTransparency) / 2.55 + 0.5)).ToString();
            //cboLineTransparency.Text = ((int)((double)(_options.LineTransparency) / 2.55 + 0.5)).ToString();
            transpFill.Value = (byte)_options.FillTransparency;
            transpOutline.Value = (byte)_options.LineTransparency;

            _noEvents = false;
        }
        #endregion

        #region ChangingFill
        /// <summary>
        /// 填充选项改变
        /// </summary>
        void cboFillType_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupHatch.Visible = false;
            groupPicture.Visible = false;
            groupGradient.Visible = false;
            pnlFillPicture.Visible = false;
            clpFill.Visible = true;
            label6.Visible = true;
            
            if (cboFillType.SelectedIndex == (int)tkFillType.ftHatch)
            {
                groupHatch.Visible = true;
            }
            else if (cboFillType.SelectedIndex == (int)tkFillType.ftGradient)
            {
                groupGradient.Visible = true;
            }
            else if (cboFillType.SelectedIndex == (int)tkFillType.ftPicture)
            {
                groupPicture.Visible = true;
                pnlFillPicture.Visible = true;
                clpFill.Visible = false;
                label6.Visible = false;
            }
            
            if (cboFillType.SelectedIndex >= 0)
            {
                _options.FillType = (tkFillType)cboFillType.SelectedIndex;
            }

            if (!_noEvents)
                btnApply.Enabled = true;
            DrawPreview();
        }
        #endregion

        #region Drawing
        /// <summary>
        /// 绘制预览图
        /// </summary>
        private void DrawPreview()
        {
            if (_noEvents)
            {
                return;
            }

            if (pctPreview.Image != null)
            {
                pctPreview.Image.Dispose();
            }

            Rectangle rect = pctPreview.ClientRectangle;
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            IntPtr ptr = g.GetHdc();
            
            _options.DrawRectangle(ptr, 40.0f, 40.0f, rect.Width - 80, rect.Height - 80, true, rect.Width, rect.Height, Colors.ColorToUInteger(this.BackColor));

            g.ReleaseHdc();
            pctPreview.Image = bmp;
        }
        #endregion


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_options.Serialize() != _initState)
            {
                m_legend.FireLayerPropertiesChanged(m_layer.Handle);
                m_legend.RedrawLegendAndMap();
            }

            m_layer.SymbologySettings.IconIndex = iconControl1.SelectedIndex;
            _tabPage = tabControl1.SelectedIndex;
        }


        private void transpOutline_ValueChanged(object sender, byte value)
        {
            GUI2Options(sender, null);
        }


        private void btnApply_Click(object sender, EventArgs e)
        {
            m_legend.Map.Redraw();
            m_legend.Redraw();
            m_legend.FireLayerPropertiesChanged(m_layer.Handle);
            _initState = _options.Serialize();
            btnApply.Enabled = false;
        }


        private void frmPolygons_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                _tabPage = tabControl1.SelectedIndex;
                _options.Deserialize(_initState);
            }
        }


        private void iconControl1_SelectionChanged_1()
        {
            if (_noEvents)
                return;
            btnApply.Enabled = true;
        }
    }
}
