

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MWLite.Symbology.Classes;
using MWLite.Symbology.Controls;
using MapWinGIS;
using MWLite.Symbology.LegendControl;

namespace MWLite.Symbology.Forms.Symbology
{
    public partial class LinesForm : Form
    {
        #region Member variables

        // 图例控件引用
        internal LegendControl.Legend m_legend = null;

        // 被选中的图层
        internal Layer m_layer = null;
        
        // 绘制样式
        ShapeDrawingOptions _options = null;
        
        // 触发事件开关
        private bool _noEvents = false;

        // 指示状态
        private string _initState = "";

        // tab的索引
        internal static int _tabIndex = 0;

        // 指示行列
        private const int CMN_PICTURE = 0;
        private const int CMN_TYPE = 1;

        #endregion

        #region Initialization

        public LinesForm(LegendControl.Legend legend, Layer layer, ShapeDrawingOptions options, bool applyDisabled)
        {
            InitializeComponent();

            if (options == null || layer == null)
            {
                throw new Exception("unexpected null parameter");
            }
            else
            {
                _options = options;
                m_layer = layer;
            }

            m_legend = legend;
            btnApply.Visible = !applyDisabled;
            _initState = options.Serialize();
            

            icbLineType.ComboStyle = ImageComboStyle.LineStyle;
            icbLineWidth.ComboStyle = ImageComboStyle.LineWidth;

            groupMarker.Parent = tabLine;
            groupMarker.Top = groupLine.Top;
            groupMarker.Left = groupLine.Left;

            cboVerticesType.Items.Clear();
            cboVerticesType.Items.Add("方形");
            cboVerticesType.Items.Add("圆形");

            cboOrientation.Items.Clear();
            cboOrientation.Items.Add("水平方向");
            cboOrientation.Items.Add("平行于线");
            cboOrientation.Items.Add("垂直于线");

            cboLineType.Items.Clear();
            cboLineType.Items.Add("线类型");
            cboLineType.Items.Add("标记类型");

            cboLineType.SelectedIndexChanged += new EventHandler(cboLineType_SelectedIndexChanged);
            cboLineType.SelectedIndex = 0;

            // 订阅事件
            chkVerticesVisible.CheckedChanged += new EventHandler(GUI2Options);
            cboVerticesType.SelectedIndexChanged += new EventHandler(GUI2Options);
            clpVerticesColor.SelectedColorChanged += new EventHandler(GUI2Options);
            chkVerticesFillVisible.CheckedChanged += new EventHandler(GUI2Options);
            udVerticesSize.ValueChanged += new EventHandler(GUI2Options);

            InitLinePattern();

            Options2Grid();

            Options2GUI();

            linePatternControl1.LoadFromXML();

            _noEvents = true;
            tabControl1.SelectedIndex = _tabIndex;
            _noEvents = false;
        }

        /// <summary>
        /// 初始化线样式
        /// </summary>
        void InitLinePattern()
        {
            if (_options.LinePattern == null)
            {
                _options.LinePattern = new LinePattern();
            }
            if (_options.LinePattern.Count == 0)
            {
                _options.LinePattern.AddLine(_options.LineColor, _options.LineWidth, _options.LineStipple);
            }
        }

        /// <summary>
        /// 更新控件状态
        /// </summary>
        void RefreshControlState()
        {
            bool exists = (dgv.SelectedRows.Count > 0) && (dgv.Rows.Count > 1);
            btnRemove.Enabled = exists;
            if (exists)
            {
                int index = dgv.SelectedRows[0].Index;
                btnMoveUp.Enabled = index > 0;
                btnMoveDown.Enabled = index < dgv.Rows.Count - 1;
            }
            else
            {
                btnMoveDown.Enabled = false;
                btnMoveUp.Enabled = false;
            }

        }
        #endregion

        #region PropertyExchange
        /// <summary>
        /// 绘制选项回调
        /// </summary>
        private void GUI2Options(object sender, EventArgs e)
        {
            if (_noEvents)
                return;

            // vertices
            _options.VerticesVisible = chkVerticesVisible.Checked;
            _options.VerticesFillVisible = chkVerticesFillVisible.Checked;
            _options.VerticesSize = (int)udVerticesSize.Value;
            _options.VerticesColor = Colors.ColorToUInteger(clpVerticesColor.Color);
            _options.VerticesType = (tkVertexType)cboVerticesType.SelectedIndex;

            // transparency
            _options.LineTransparency = transparencyControl1.Value;
            if (_options.LinePattern != null)
            {
                _options.LinePattern.Transparency = (byte)_options.LineTransparency;
            }

            if (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                MapWinGIS.LineSegment line = _options.LinePattern.get_Line(index);
                if (line != null)
                {
                    line.LineType = cboLineType.SelectedIndex == 0 ? tkLineType.lltSimple : tkLineType.lltMarker;

                    // showing the options
                    if (cboLineType.SelectedIndex == 0)
                    {
                        line.LineStyle = (tkDashStyle)icbLineType.SelectedIndex;
                        line.LineWidth = icbLineWidth.SelectedIndex + 1;
                        line.Color = Colors.ColorToUInteger(clpOutline.Color);
                    }
                    else
                    {
                        line.Marker = (tkDefaultPointSymbol)pointSymbolControl1.SelectedIndex;
                        line.MarkerInterval = (float)udMarkerInterval.Value;
                        line.MarkerSize = (float)udMarkerSize.Value;
                        line.Color = Colors.ColorToUInteger(clpMarkerFill.Color);
                        line.MarkerOutlineColor = Colors.ColorToUInteger(clpMarkerOutline.Color);
                        line.MarkerOrientation = (tkLineLabelOrientation)cboOrientation.SelectedIndex;
                        line.MarkerOffset = (float)udMarkerOffset.Value;

                        if (pointSymbolControl1.ForeColor != clpMarkerFill.Color)
                        {
                            pointSymbolControl1.ForeColor = clpMarkerFill.Color;
                        }
                    }
                    dgv.Invalidate();
                }
            }

            btnApply.Enabled = true;
            DrawPreview();
        }
        
        /// <summary>
        /// 获取用户所选的值
        /// </summary>
        private void Options2GUI()
        {
            _noEvents = true;

            // vertices
            chkVerticesVisible.Checked = _options.VerticesVisible;
            chkVerticesFillVisible.Checked = _options.VerticesFillVisible;
            udVerticesSize.SetValue(_options.VerticesSize);
            clpVerticesColor.Color = Colors.UintToColor(_options.VerticesColor);
            cboVerticesType.SelectedIndex = (int)_options.VerticesType;

            // transparency
            if (_options.LinePattern != null)
            {
                transparencyControl1.Value = _options.LinePattern.Transparency;
            }

            if (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                MapWinGIS.LineSegment line = _options.LinePattern.get_Line(index);
                if (line != null)
                {
                    cboLineType.SelectedIndex = (int)line.LineType;

                    groupLine.Visible = false;
                    groupMarker.Visible = false;
                    if (cboLineType.SelectedIndex == 0)
                    {
                        groupLine.Visible = true;
                    }
                    else
                    {
                        groupMarker.Visible = true;
                    }

                    //设置过程中，不允许触发任何事件
                    if (line.LineType == tkLineType.lltSimple)
                    {
                        _noEvents = true;
                        icbLineType.SelectedIndex = (int)line.LineStyle;
                        icbLineWidth.SelectedIndex = (int)line.LineWidth - 1;
                        clpOutline.Color = Colors.UintToColor(line.Color);
                        _noEvents = false;
                    }
                    else
                    {
                        _noEvents = true;
                        pointSymbolControl1.SelectedIndex = (int)line.Marker;
                        udMarkerInterval.SetValue(line.MarkerInterval);
                        udMarkerSize.SetValue(line.MarkerSize);
                        clpMarkerFill.Color = Colors.UintToColor(line.Color);
                        clpMarkerOutline.Color = Colors.UintToColor(line.MarkerOutlineColor);
                        udMarkerOffset.SetValue(line.MarkerOffset);
                        cboOrientation.SelectedIndex = (int)line.MarkerOrientation;
                        if (pointSymbolControl1.ForeColor != clpMarkerFill.Color)
                        {
                            pointSymbolControl1.ForeColor = clpMarkerFill.Color;
                        }

                        _noEvents = false;
                    }
                    DrawPreview();
                }
            }
            _noEvents = false;
        }
        #endregion

        #region Drawing
        /// <summary>
        /// 基于用户所选绘制
        /// </summary>
        private void DrawPreview()
        {
            if (_noEvents)
                return;

            if (pctPreview.Image != null)
            {
                pctPreview.Image.Dispose();
            }

            Rectangle rect = pctPreview.ClientRectangle;
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            IntPtr ptr = g.GetHdc();

            uint backColor = Colors.ColorToUInteger(this.BackColor);
            _options.LinePattern.Draw(ptr, 20, 0, rect.Width - 40, rect.Height, backColor);

            g.ReleaseHdc();
            
            //bmp.MakeTransparent(Color.White);
            pctPreview.Image = bmp;
        }
        #endregion

        #region User input
        /// <summary>
        /// cboLineType回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cboLineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_noEvents)
                return;

            if (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                MapWinGIS.LineSegment line = _options.LinePattern.get_Line(index);
                line.LineType = (tkLineType)cboLineType.SelectedIndex;
                dgv[CMN_TYPE, index].Value = line.LineType == tkLineType.lltSimple ? "line" : "marker";
                Options2GUI();
                dgv.Invalidate();
                btnApply.Enabled = true;
                
            }
        }
        #endregion

        #region Grid
        
        /// <summary>
        /// 绘制cbo中的style
        /// </summary>
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_options.LinePattern == null)
            {
                return;
            }

            if (e.RowIndex >= 0 && e.RowIndex < _options.LinePattern.Count)
            {
                if (e.ColumnIndex == CMN_PICTURE)
                {
                    System.Drawing.Image img = e.Value as System.Drawing.Image;
                    if (img != null)
                    {
                        MapWinGIS.LineSegment line = _options.LinePattern.get_Line(e.RowIndex);
                        if (line != null)
                        {
                            Graphics g = Graphics.FromImage(img);
                            g.Clear(Color.White);
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = SmoothingMode.HighQuality;
                            
                            IntPtr ptr = g.GetHdc();
                            uint backColor = Colors.ColorToUInteger(this.BackColor);
                            line.Draw(ptr, 0, 0, img.Width, img.Height, backColor);
                            g.ReleaseHdc();
                            g.Dispose();

                            ((Bitmap)img).MakeTransparent(this.BackColor);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 样式选择监听
        /// </summary>
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            Options2GUI();
            RefreshControlState();
        }
        #endregion

        #region Managing lines
        /// <summary>
        /// 加入一段线段
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_options.LinePattern == null)
            {
                _options.LinePattern = new LinePattern();
            }

            if (cboLineType.SelectedIndex == (int)tkLineType.lltSimple)
            {
                _options.LinePattern.AddLine(Colors.ColorToUInteger(Color.Black), 1.0f, tkDashStyle.dsSolid);
            }
            else
            {
                LineSegment segment = _options.LinePattern.AddMarker(tkDefaultPointSymbol.dpsCircle);
            }
            Options2Grid();
            //GUI2Options(null, null);
            DrawPreview();

            // selecting the added line
            _noEvents = true;
            dgv.ClearSelection();
            _noEvents = false;
            int index = dgv.Rows.Count - 1;
            dgv.Rows[index].Selected = true;
            btnApply.Enabled = true;

            RefreshControlState();
        }
        /// <summary>
        ///移除当前组合的线段，最后一条除外
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0 && dgv.Rows.Count > 1)
            {
                int index = dgv.SelectedRows[0].Index;
                _options.LinePattern.RemoveItem(index);
                Options2Grid();
                //GUI2Options(null, null);
                DrawPreview();

                // restoring selection
                _noEvents = true;
                dgv.ClearSelection();
                _noEvents = false;
                if (index >= dgv.Rows.Count )
                    index--;
                dgv.Rows[index].Selected = true;

                btnApply.Enabled = true;
                RefreshControlState();
            }
        }

        /// <summary>
        /// 上移所选线段
        /// </summary>
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                if (index > 0)
                {
                    MapWinGIS.LineSegment segm = _options.LinePattern.get_Line(index);
                    MapWinGIS.LineSegment segmBefore = _options.LinePattern.get_Line(index - 1);
                    _options.LinePattern.set_Line(index - 1, segm);
                    _options.LinePattern.set_Line(index, segmBefore);

                    Options2Grid();
                    DrawPreview();

                    _noEvents = true;
                    dgv.ClearSelection();
                    _noEvents = false;
                    dgv.Rows[index - 1].Selected = true;

                    btnApply.Enabled = true;
                    RefreshControlState();
                }
            }
        }

        /// <summary>
        /// 下移所选线段
        /// </summary>
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                if (index < dgv.Rows.Count - 1)
                {
                    MapWinGIS.LineSegment segm = _options.LinePattern.get_Line(index);
                    MapWinGIS.LineSegment segmAfter = _options.LinePattern.get_Line(index + 1);
                    _options.LinePattern.set_Line(index + 1, segm);
                    _options.LinePattern.set_Line(index, segmAfter);

                    Options2Grid();
                    DrawPreview();

                    _noEvents = true;
                    dgv.ClearSelection();
                    _noEvents = false;
                    dgv.Rows[index + 1].Selected = true;

                    btnApply.Enabled = true;
                    RefreshControlState();
                }
            }
        }

        /// <summary>
        /// 变为标记类型
        /// </summary>
        private void pointSymbolControl1_SelectionChanged()
        {
            GUI2Options(null, null);
        }

        #endregion

        /// <summary>
        /// okButton监听
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            ApplyPattern();
            if (_initState != _options.Serialize())
            {
                m_legend.FireLayerPropertiesChanged(m_layer.Handle);
                m_legend.RedrawLegendAndMap();
            }
            _tabIndex = tabControl1.SelectedIndex;
            

            linePatternControl1.SaveToXML();
        }

        private void transparencyControl1_ValueChanged(object sender, byte value)
        {
            GUI2Options(null, null);
        }

        /// <summary>
        /// apply回调
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyPattern();
            if (m_legend != null)
            {
                m_legend.RedrawLegendAndMap();
                m_legend.FireLayerPropertiesChanged(m_layer.Handle);
            }
            _initState = _options.Serialize();
            btnApply.Enabled = false;
        }

        /// <summary>
        /// 已应用的情况下，取消则恢复
        /// </summary>
        private void frmLines_FormClosing(object sender, FormClosingEventArgs e)
        {
            _tabIndex = tabControl1.SelectedIndex;
            if (this.DialogResult == DialogResult.Cancel)
            {
                _options.Deserialize(_initState);
            }
        }
        #region Synchronization
 
        private bool CanUseLinePattern()
        {
            if (_options.LinePattern != null)
            {
                if (_options.LinePattern.Count > 0)
                {
                    return _options.LinePattern.Count > 1 || (_options.LinePattern.Count == 1 &&
                           _options.LinePattern.get_Line(0).LineType == tkLineType.lltMarker);
                }
            }
            return false;
        }

        /// <summary>
        /// 绘制
        /// </summary>
        private void Options2Grid()
        {
            dgv.Rows.Clear();
            if (CanUseLinePattern())
            {
                dgv.Rows.Add(_options.LinePattern.Count);
                for (int i = 0; i < _options.LinePattern.Count; i++)
                {
                    dgv[CMN_TYPE, i].Value = _options.LinePattern.get_Line(i).LineType == tkLineType.lltSimple ? "line" : "marker";
                    Bitmap bmp = new Bitmap(60, 14);
                    dgv[CMN_PICTURE, i].Value = bmp;
                }
                _options.UseLinePattern = true;
            }
            else
            {
                dgv.Rows.Add(1);
                dgv[CMN_TYPE, 0].Value = "line";
                Bitmap bmp = new Bitmap(60, 14);
                dgv[CMN_PICTURE, 0].Value = bmp;
                _options.UseLinePattern = false;
            }
        }
        #endregion

        /// <summary>
        /// 应用组合的样式
        /// </summary>
        void ApplyPattern()
        {
            if (_options.LinePattern == null)
            {
                
                _options.UseLinePattern = false;
            }
            else if (_options.LinePattern.Count == 1 && _options.LinePattern.get_Line(0).LineType == tkLineType.lltSimple)
            {
                
                ILineSegment line = _options.LinePattern.get_Line(0);
                if (line != null)
                {
                    _options.LineStipple = line.LineStyle;
                    _options.LineWidth = line.LineWidth;
                    _options.LineColor = line.Color;
                }
                _options.UseLinePattern = false;
            }
            else
            {
                _options.UseLinePattern = true;
            }
        }

        #region Line pattern styles
        /// <summary>
        /// 样式改变监听
        /// </summary>
        private void linePatternControl1_SelectionChanged()
        {
            if (_noEvents)
                return;

            MapWinGIS.LinePattern pattern = linePatternControl1.SelectedPattern;
            if (pattern != null)
            {
                string s = pattern.Serialize();

                _options.LinePattern = new LinePattern();
                _options.LinePattern.Deserialize(s);
                this.ApplyPattern();

                Options2Grid();
                Options2GUI();
                
                btnApply.Enabled = true;
            }
        }

        /// <summary>
        /// 加入样式
        /// </summary>
        private void btnAddStyle_Click(object sender, EventArgs e)
        {
            MapWinGIS.LinePattern pattern = new LinePattern();
            this.ApplyPattern();

            if (_options.UseLinePattern && _options.LinePattern != null)
            {
                string s = _options.LinePattern.Serialize();
                pattern.Deserialize(s);
            }
            else
            {
             
                pattern.AddLine(_options.LineColor, _options.LineWidth, _options.LineStipple);
            }
            linePatternControl1.AddPattern(pattern);
        }
        
        /// <summary>
        /// 移除所选样式
        /// </summary>
        private void btnRemoveStyle_Click(object sender, EventArgs e)
        {
            linePatternControl1.RemovePattern(linePatternControl1.SelectedIndex);
        }
        

        private void btnSaveStyles_Click(object sender, EventArgs e)
        {
            linePatternControl1.SaveToXML();
        }
        
        private void btnLoadStyles_Click(object sender, EventArgs e)
        {
            linePatternControl1.LoadFromXML();
        }
        #endregion
    }
}
