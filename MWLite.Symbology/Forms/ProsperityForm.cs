using MapWinGIS;
using MWLite.Symbology.Classes;
using MWLite.Symbology.Controls;
using MWLite.Symbology.Forms.Utilities;
using MWLite.Symbology.LegendControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWLite.Symbology.Forms
{
    public partial class ProsperityForm : Form
    {

        #region 变量
        // 图例控件引用
        private readonly LegendControl.Legend _legend;

        // 图层句柄
        private readonly int _layerHandle = -1;

        // 图层管理，注意该图层是自定义的 不是mapwingis定义的layer
        private readonly Layer _layer = null;

        // 图层管理设置
        private readonly SymbologySettings _settings = null;

        // shapefile文件引用
        private readonly Shapefile _shapefile = null;

        // 当前的选项卡索引
        static int _tabIndex = 0;

        // 阻止控件在代码管理中触发事件
        private bool _noEvents = false;

        // 初始序列化状态，用于打印状态
        private string _initState = "";

        // 状态改变标志
        private bool _stateChanged = false;

        // 同步显示绘制Map
        private const bool _redrawModeIsChanging = false;


        #endregion

        public ProsperityForm(LegendControl.Legend legend, int layerHandle)
        {
            InitializeComponent();

            var gs = new GlobalSettings();
            gs.ForceHideLabels = true;
            //初始化form
            _legend = legend;
            _layerHandle = layerHandle;
            _layer = _legend.GetLayer(_layerHandle);
            _shapefile = _layer.GetObject() as Shapefile;
            _settings = Globals.get_LayerSettings(_layerHandle);
            this.Text = "图层属性: " + _layer.Name;

            //锁定图层
            LockLegendAndMap(true);
            _initState = SaveState();

            // 颜色框中的第一种颜色应该是shapefile的填充/线条颜色
            Globals.LayerColors.SetDefaultColorScheme(_shapefile);

            //选项卡初始化，禁止触发事件
            _noEvents = true;

            initGategoiresTab();

            //事件触发正常
            _noEvents = false;

        }



        #region 私有方法
        private string SaveState()
        {
            string state = "";
            var map = _legend.Map;
            if (map != null)
            {
             
                tkSavingMode mode1 = _shapefile.Labels.SavingMode;
                tkSavingMode mode2 = _shapefile.Charts.SavingMode;

                _shapefile.Labels.SavingMode = tkSavingMode.modeNone;
                _shapefile.Charts.SavingMode = tkSavingMode.modeNone;

                state = map.SerializeLayer(_layerHandle);

                _shapefile.Labels.SavingMode = mode1;
                _shapefile.Charts.SavingMode = mode2;
            }
            return state;
        }

        private void LockLegendAndMap(bool state)
        {
            if (state)
            {
                _legend.Lock();
                _legend.Map.LockWindow(tkLockMode.lmLock);
            }
            else
            {
                _legend.Unlock();
                _legend.Map.LockWindow(tkLockMode.lmUnlock);
            }
        }

        /// <summary>
        /// 关闭时解锁图层控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClose(object sender, FormClosedEventArgs e)
        {
            LockLegendAndMap(false);
        }





        #endregion


        #region tab的共用方法
        /// <summary>
        /// 重绘map
        /// </summary>
        private void RedrawMap()
        {
            //if (chkRedrawMap.Checked && !_noEvents)
            _legend.Map.Redraw();
            _legend.Refresh();
            
            if (!_noEvents && !_redrawModeIsChanging)
            {
                MarkStateChanged();
            }
        }


        /// <summary>
        /// 重绘
        /// </summary>
        private void RedrawLegend()
        {
            if (chkRedrawMap.Checked && !_noEvents)
            {
                _legend.Refresh();
            }
        }

        /// <summary>
        /// 图层状态改变
        /// </summary>
        private void MarkStateChanged()
        {
            _stateChanged = true;
            btnSaveChanges.Enabled = true;
        }

    }

    #endregion





}


namespace MWLite.Symbology.Forms
{
    //分级渲染tab
    public partial class ProsperityForm
    {
        #region  变量

        //dataGrid列头
        private const int CMN_CATEGORYID = 0;
        private const int CMN_VISIBLE = 1;
        private const int CMN_STYLE = 2;
        private const int CMN_NAME = 3;
        private const int CMN_EXPRESSION = 4;
        private const int CMN_COUNT = 5;


        #endregion

        #region 初始化

        private void initGategoiresTab()
        {

            //默认为渐变
            icbCategories.ComboStyle = ImageComboStyle.ColorSchemeGraduated;
            //颜色资源获取
            icbCategories.ColorSchemes = Globals.LayerColors;
            if (icbCategories.Items.Count > 0)
            {
                icbCategories.SelectedIndex = 0;
            }


            // 从图层设置中读取图层信息，初始化控件
            chkSetGradient.Checked = _settings.CategoriesUseGradient;
            chkRandomColors.Checked = _settings.CategoriesRandomColors;
            udNumCategories.Value = _settings.CategoriesCount;
            chkUniqueValues.Checked = (_settings.CategoriesClassification == tkClassificationType.ctUniqueValues);
            chkUseVariableSize.Checked = _settings.CategoriesVariableSize;
            //读取字段信息
            FillFieldList(_settings.CategoriesFieldName);
            //设置可见性
            MapWinGIS.ShpfileType type = Globals.ShapefileType2D(_shapefile.ShapefileType);
            groupVariableSize.Visible = (type == ShpfileType.SHP_POINT || type == ShpfileType.SHP_POLYLINE);
            //设置分类最大最小值
            if (type == ShpfileType.SHP_POINT)
            {
                udMinSize.SetValue(_shapefile.DefaultDrawingOptions.PointSize);
            }
            else if (type == ShpfileType.SHP_POLYLINE)
            {
                udMinSize.SetValue(_shapefile.DefaultDrawingOptions.LineWidth);
            }
            udMaxSize.SetValue((double)udMinSize.Value + _settings.CategoriesSizeRange);



            RefreshCategoriesList();

            if (dgvCategories.Rows.Count > 0 && dgvCategories.Columns.Count > 0)
            {
                dgvCategories[0, 0].Selected = true;
            }

            //初始化事件
            initEvent();

        }


        private void initEvent()
        {
            btnCategoryGenerate.Click += btnCategoryGenerate_Click;
            chkUniqueValues.CheckedChanged += chkUniqueValues_CheckedChanged;
            chkRandomColors.CheckedChanged += chkRandomColors_CheckedChanged;
            btnCategoryRemove.Click += btnCategoryRemove_Click;
            btnCategoryAppearance.Click += btnCategoryAppearance_Click;
            btnCategoryClear.Click += btnCategoryClear_Click;
            btnChangeColorScheme.Click += btnChangeColorScheme_Click;
        }

        #endregion



        #region 私有方法
        
        private void btnCategoryGenerate_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(udNumCategories.Value);
            MapWinGIS.ShapefileCategories categories = _shapefile.Categories;

            if (lstFields1.SelectedItem == null) return;
            string name = lstFields1.SelectedItem.ToString().ToLower().Trim();

            int index = -1;
            for (int i = 0; i < _shapefile.NumFields; i++)
            {
                if (_shapefile.get_Field(i).Name.ToLower() == name)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                return;

            MapWinGIS.tkClassificationType classification = chkUniqueValues.Checked ? tkClassificationType.ctUniqueValues : tkClassificationType.ctNaturalBreaks;

            bool showWaiting = false;
            if (classification == tkClassificationType.ctUniqueValues)
            {
                HashSet<object> set = new HashSet<object>();
                for (int i = 0; i < _shapefile.NumShapes; i++)
                {
                    object val = _shapefile.get_CellValue(index, i);
                    set.Add(val);
                }

                if (set.Count > 300)
                {
                    showWaiting = true;
                    string s = string.Format("字段 = {1}.\n唯一值数量 = {0}.\n" +
                                             "需要加载较长时间.\n是否继续?", set.Count, "[" + name.ToUpper() + "]");
                    if (MessageBox.Show(s, "MapWinGisDemo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                set.Clear();
            }

            if (showWaiting)
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
            }
            else
            {
                btnCategoryGenerate.Enabled = false;
            }

            // 生成目录
            categories.Generate(index, classification, count);
            categories.Caption = "Categories: " + _shapefile.get_Field(index).Name;
            ApplyColorScheme2Categories();

            if (chkUseVariableSize.Checked)
            {
                ApplyVariablePointSize();
            }

            _shapefile.Categories.ApplyExpressions();

        

            RefreshCategoriesList();
            RedrawMap();

            // 保存设置

            _settings.CategoriesClassification = classification;
            _settings.CategoriesFieldName = name;
            _settings.CategoriesSizeRange = (int)(udMaxSize.Value - udMinSize.Value);
            _settings.CategoriesCount = (int)udNumCategories.Value;
            _settings.CategoriesRandomColors = chkRandomColors.Checked;
            _settings.CategoriesUseGradient = chkSetGradient.Checked;
            _settings.CategoriesVariableSize = chkUseVariableSize.Checked;

            
            if (showWaiting)
            {
                this.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            else
            {
                btnCategoryGenerate.Enabled = true;
            }

            RefreshControlsState(null, null);
            MarkStateChanged();
        }


        /// <summary>
        /// 填充分级渲染属性到grid中
        /// </summary>
        private void RefreshCategoriesList()
        {
            dgvCategories.SuspendLayout();
            dgvCategories.Rows.Clear();

            int numCategories = _shapefile.Categories.Count;
            if (numCategories == 0)
            {
                dgvCategories.ColumnHeadersVisible = false;
                dgvCategories.ResumeLayout();
                RefreshControlsState(null, null);
                return;
            }
            else
            {
                dgvCategories.ColumnHeadersVisible = true;
            }

            dgvCategories.Rows.Add(numCategories);

            bool noEventsState = _noEvents;
            _noEvents = true;

            // 计算每个目录的数量
            Dictionary<int, int> values = new Dictionary<int, int>();  // 键为目录的id,值为数量
            int category;

            for (int i = 0; i < _shapefile.NumShapes; i++)
            {
                category = _shapefile.get_ShapeCategory(i);
                if (values.ContainsKey(category))
                {
                    values[category] += 1;
                }
                else
                {
                    values.Add(category, 1);
                }
            }

            for (int i = 0; i < numCategories; i++)
            {
                MapWinGIS.ShapefileCategory cat = _shapefile.Categories.get_Item(i);
                dgvCategories[CMN_CATEGORYID, i].Value = i;
                dgvCategories[CMN_VISIBLE, i].Value = cat.DrawingOptions.Visible;
                Bitmap bitmap = new Bitmap(dgvCategories.Columns[CMN_STYLE].Width - 20, dgvCategories.Rows[i].Height - 8);
                //Graphics g = Graphics.FromImage(bitmap);
                //bitmap = _legend.Snapshot();
                //pictureBox.Image = bitmap;
                dgvCategories[CMN_STYLE, i].Value = bitmap;
                //dgvCategories[CMN_STYLE, i].Value = new Bitmap(@"D:\MyDownloads\Download\earth.png");
                dgvCategories[CMN_NAME, i].Value = cat.Name;
                dgvCategories[CMN_EXPRESSION, i].Value = cat.Expression;

                if (values.ContainsKey(i))
                    dgvCategories[CMN_COUNT, i].Value = values[i];
                else
                    dgvCategories[CMN_COUNT, i].Value = 0;
            }
            dgvCategories.ResumeLayout();

        
            for (int i = 1; i < dgvCategories.Columns.Count; i++)
            {
                if (i != CMN_STYLE && i != CMN_COUNT)
                {
                    dgvCategories.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                    dgvCategories.Columns[i].Width += 10;
                }
            }
            RefreshControlsState(null, null);
            _noEvents = noEventsState;
        }

        /// <summary>
        /// 填充sf字段信息到Listbox
        /// </summary>
        private void FillFieldList(string name)
        {
            if (name == string.Empty)
            {
                // 保存已选中的字段
                if (lstFields1.SelectedItem != null)
                {
                    name = lstFields1.SelectedItem.ToString().Trim();
                }
                else
                {
                    name = string.Empty;
                }
            }

            lstFields1.Items.Clear();

            // 加入字段
            for (int i = 0; i < _shapefile.NumFields; i++)
            {
                //MessageBox.Show(_shapefile.get_Field(i).Name);
                //mapwingis如果filed里的字段为中文 就读不到
                if (!chkUniqueValues.Checked && _shapefile.get_Field(i).Type == FieldType.STRING_FIELD ||
                     chkUniqueValues.Checked && _shapefile.get_Field(i).Type != FieldType.STRING_FIELD)
                {
                    continue;
                }

                lstFields1.Items.Add("  " + _shapefile.get_Field(i).Name);
            }

            // 设置选中上面保存的字段类型
            if (name != string.Empty)
            {
                for (int i = 0; i < lstFields1.Items.Count; i++)
                {
                    if (lstFields1.Items[i].ToString().ToLower().Trim() == name.ToLower())
                    {
                        lstFields1.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (lstFields1.SelectedItem == null && lstFields1.Items.Count > 0)
            {
                lstFields1.SelectedIndex = 0;
            }
            RefreshControlsState(null, null);
        }

        private void RefreshControlsState(object sender, EventArgs e)
        {
            if (_noEvents)
                return;
            ShpfileType type = Globals.ShapefileType2D(_shapefile.ShapefileType);
            udNumCategories.Enabled = !chkUniqueValues.Checked;
            btnCategoryAppearance.Enabled = (dgvCategories.SelectedCells.Count > 0);
            btnCategoryRemove.Enabled = (dgvCategories.SelectedCells.Count > 0);
            btnCategoryClear.Enabled = (dgvCategories.Rows.Count > 0);
        }

        /// <summary>
        /// 应用所选的颜色方案
        /// </summary>
        private void ApplyColorScheme2Categories()
        {
            if (_shapefile.Categories.Count > 0)
            {
                MapWinGIS.ColorScheme scheme = null;
                if (icbCategories.SelectedIndex >= 0)
                {
                    ColorBlend blend = (ColorBlend)icbCategories.ColorSchemes.List[icbCategories.SelectedIndex];
                    scheme = ColorSchemes.ColorBlend2ColorScheme(blend);

                    // saving the settings
                    //MWLite.Symbology.Layer layer = Globals.Legend.Layers.ItemByHandle(_layerHandle);
                    //_settings.CategoriesColorScheme = blend;
                }
                else
                    return;

                if (chkRandomColors.Checked)
                {
                    _shapefile.Categories.ApplyColorScheme(MapWinGIS.tkColorSchemeType.ctSchemeRandom, scheme);
                }
                else
                {
                    _shapefile.Categories.ApplyColorScheme(MapWinGIS.tkColorSchemeType.ctSchemeGraduated, scheme);
                }

                MapWinGIS.ShapefileCategories categories = _shapefile.Categories;
                //绘制catagorise选项
                if (chkSetGradient.Checked)
                {
                    for (int i = 0; i < categories.Count; i++)
                    {
                        ShapeDrawingOptions options = categories.get_Item(i).DrawingOptions;
                        options.SetGradientFill(options.FillColor, 75);
                        options.FillType = tkFillType.ftGradient;
                    }
                }
                else
                {
                    for (int i = 0; i < categories.Count; i++)
                    {
                        ShapeDrawingOptions options = categories.get_Item(i).DrawingOptions;
                        options.FillColor2 = options.FillColor;
                        options.FillType = tkFillType.ftStandard;
                    }
                }
            }
        }


        /// <summary>
        /// 为点类别设置具有可变大小的符号 
        /// </summary>
        private void ApplyVariablePointSize()
        {
            if (chkUseVariableSize.Checked && (udMinSize.Value != udMaxSize.Value))
            {
                MapWinGIS.ShapefileCategories categories = _shapefile.Categories;
                if (_shapefile.ShapefileType == ShpfileType.SHP_POINT || _shapefile.ShapefileType == ShpfileType.SHP_MULTIPOINT)
                {
                    double step = (double)(udMaxSize.Value - udMinSize.Value) / ((double)categories.Count - 1);
                    for (int i = 0; i < categories.Count; i++)
                    {
                        categories.get_Item(i).DrawingOptions.PointSize = (int)udMinSize.Value + Convert.ToInt32(i * step);
                    }
                }
                else if (_shapefile.ShapefileType == ShpfileType.SHP_POLYLINE)
                {
                    double step = (double)(udMaxSize.Value + udMinSize.Value) / (double)categories.Count;
                    for (int i = 0; i < categories.Count; i++)
                    {
                        categories.get_Item(i).DrawingOptions.LineWidth = (int)udMinSize.Value + Convert.ToInt32(i * step);
                    }
                }
            }
        }


        /// <summary>
        /// 唯一值事件处理，数字字段只用自然分级法分级
        /// </summary>
        private void chkUniqueValues_CheckedChanged(object sender, EventArgs e)
        {
            FillFieldList(string.Empty);
        }

        /// <summary>
        /// 随机色事件处理
        /// </summary>
        private void chkRandomColors_CheckedChanged(object sender, EventArgs e)
        {
            int index = icbCategories.SelectedIndex;
            if (chkRandomColors.Checked)
            {
                icbCategories.ComboStyle = ImageComboStyle.ColorSchemeRandom;
            }
            else
            {
                icbCategories.ComboStyle = ImageComboStyle.ColorSchemeGraduated;
            }

            if (index >= 0 && index < icbCategories.Items.Count)
            {
                icbCategories.SelectedIndex = index;
            }
        }


        /// <summary>
        /// 清除事件处理
        /// </summary>
        private void btnCategoryRemove_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow != null)
            {
                try
                {
                    int cmn = dgvCategories.CurrentCell.ColumnIndex;
                    int index = dgvCategories.CurrentRow.Index;

                    int realIndex = (int)dgvCategories[CMN_CATEGORYID, dgvCategories.CurrentRow.Index].Value;
                    _shapefile.Categories.Remove(realIndex);
                    RefreshCategoriesList();

                    if (index >= 0 && index < dgvCategories.Rows.Count)
                    {
                        dgvCategories.CurrentCell = dgvCategories[cmn, index];
                    }
                    else if (dgvCategories.Rows.Count > 0)
                    {
                        dgvCategories.CurrentCell = dgvCategories[cmn, dgvCategories.Rows.Count];
                    }

                    // updating the map
                    _shapefile.Categories.ApplyExpressions();

                    RedrawMap();
                }
                catch (System.Exception)
                {
                }
            }
        }

        /// <summary>
        /// 外观按钮事件处理，弹出设置图例窗口
        /// </summary>
        private void btnCategoryAppearance_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow != null)
            {
                ChangeCategoryStyle(dgvCategories.CurrentRow.Index);
            }
        }

        private void ChangeCategoryStyle(int row)
        {
            ShapefileCategory cat = _shapefile.Categories.get_Item(row);
            if (cat == null) return;

            Form form = FormHelper.GetSymbologyForm(_legend, _layerHandle, _shapefile.ShapefileType, cat.DrawingOptions, true);
            form.Text = "Category drawing options";

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                dgvCategories.Invalidate();
                RedrawMap();
            }
            form.Dispose();
        }


        /// <summary>
        /// 移除列表
        /// </summary>
        private void btnCategoryClear_Click(object sender, EventArgs e)
        {
            _shapefile.Categories.Clear();
            RefreshCategoriesList();

            Layer layer = _legend.Layers.ItemByHandle(_layerHandle);
            _settings.CategoriesClassification = chkUniqueValues.Checked ? tkClassificationType.ctUniqueValues : tkClassificationType.ctNaturalBreaks;

            RedrawMap();
        }

        /// <summary>
        /// 双击目录图例事件处理
        /// </summary>
        private void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == CMN_STYLE)
            {
                btnCategoryAppearance_Click(null, null);
            }
        }


        /// <summary>
        /// 绘制单元格
        /// </summary>
        private void dgvCategories_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != CMN_STYLE) return;
            if (e.RowIndex >= 0 && e.RowIndex < _shapefile.Categories.Count)
            {
                System.Drawing.Image img = e.Value as System.Drawing.Image;
                if (img == null) return;

                ShapefileCategory cat = _shapefile.Categories.get_Item(e.RowIndex);
                if (cat == null) return;
                ShapeDrawingOptions sdo = cat.DrawingOptions;

                Graphics g = Graphics.FromImage(img);
                g.Clear(Color.White);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;

                if (_shapefile.ShapefileType == ShpfileType.SHP_POLYGON)
                {
                    sdo.DrawRectangle(g.GetHdc(), 0, 0, img.Width - 1, img.Height - 1, true, img.Width, img.Height, Colors.ColorToUInteger(dgvCategories.BackgroundColor));
                }
                else if (_shapefile.ShapefileType == ShpfileType.SHP_POLYLINE)
                {
                    sdo.DrawLine(g.GetHdc(), 0, 0, img.Width - 1, img.Height - 1, true, img.Width, img.Height, Colors.ColorToUInteger(dgvCategories.BackgroundColor));
                }
                else if (_shapefile.ShapefileType == ShpfileType.SHP_POINT)
                {
                    sdo.DrawPoint(g.GetHdc(), 0.0f, 0.0f, img.Width, img.Height, Colors.ColorToUInteger(dgvCategories.BackgroundColor));
                }

                g.ReleaseHdc();
                g.Dispose();
            }
        }


        /// <summary>
        /// 绘制当前聚焦状态的单元格
        /// </summary>
        private void dgvCategories_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (this.dgvCategories.CurrentCell == null) return;
            if (e.ColumnIndex == this.dgvCategories.CurrentCell.ColumnIndex && e.RowIndex == this.dgvCategories.CurrentCell.RowIndex)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                using (Pen p = new Pen(Color.Black, 4))
                {
                    Rectangle rect = e.CellBounds;
                    rect.Width -= 1;
                    rect.Height -= 1;
                    ControlPaint.DrawFocusRectangle(e.Graphics, rect);
                }
                e.Handled = true;
            }
        }

        /// <summary>
        /// 勾选框事件处理，可见性处理
        /// </summary>
        private void dgvCategories_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            if (_noEvents)
                return;

            if (e.ColumnIndex == CMN_VISIBLE)
            {
                int index = (int)dgvCategories[CMN_CATEGORYID, e.RowIndex].Value;
                _shapefile.Categories.get_Item(index).DrawingOptions.Visible = (bool)dgvCategories[e.ColumnIndex, e.RowIndex].Value;

                // toggle labels in case they are present
                MapWinGIS.LabelCategory cat = _shapefile.Labels.get_Category(index);
                if (cat != null && cat.Enabled)
                {
                    cat.Visible = (bool)dgvCategories[e.ColumnIndex, e.RowIndex].Value;
                }
                RedrawMap();
            }
        }

        /// <summary>
        /// 当复选框勾选时，立刻刷新状态，否则不会触发cellValueChange事件
        /// </summary>
        private void dgvCategories_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentCell.ColumnIndex == CMN_VISIBLE)
            {
                if (dgvCategories.IsCurrentCellDirty)
                {
                    dgvCategories.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }


        private void dgvCategories_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == CMN_COUNT)
                e.Cancel = true;
        }


        private void dgvCategories_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == CMN_NAME)
            {
                _shapefile.Categories.get_Item(e.RowIndex).Name = dgvCategories[CMN_NAME, e.RowIndex].Value.ToString();
                RedrawLegend();
            }
        }

        /// <summary>
        /// 改变颜色方案事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeColorScheme_Click(object sender, EventArgs e)
        {
            frmColorSchemes form = new frmColorSchemes(ref Globals.LayerColors);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                icbCategories.ColorSchemes = Globals.LayerColors;
            }
            form.Dispose();
        }



        /// <summary>
        /// 应用按钮事件处理
        /// </summary>
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (_stateChanged)
            {
                //GUI2Settings(null, null);

                // triggering redraw
                if (!chkRedrawMap.Checked)
                {
                    Map map = _legend.Map;

                    LockLegendAndMap(false);

                    _legend.Map.Redraw();
                    _legend.Refresh();
                    Application.DoEvents();

                    LockLegendAndMap(true);
                }

                
                _initState = SaveState();

                _stateChanged = false;
                btnSaveChanges.Enabled = false;

                //m_mapWin.Project.Modified = true;
            }
        }

        /// <summary>
        /// 确定按钮事件处理
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_initState != SaveState())
            {
                //m_mapWin.Project.Modified = true;
            }

            LockLegendAndMap(false);
            
            Globals.SaveLayerOptions(_layerHandle);
        }

        #endregion
    }
}
