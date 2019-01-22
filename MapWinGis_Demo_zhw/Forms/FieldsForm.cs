using MapWinGIS;
using MapWinGis_Demo_zhw.Forms;
using MWLite.Symbology.LegendControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace MapWinGis.ShapeEditor.Forms
{
    public partial class AttributesForm : Form
    {

        public int FieldsCount
        {
            get => fieldsCount;
            set
            {
                if (fieldsCount != value)
                    whenCountChanged(this, RecordsCount, value);
                fieldsCount = value;
            }
        }
        public int RecordsCount
        {
            get => recordsCount;
            set
            {
                if (recordsCount != value)
                    whenCountChanged(this, value, FieldsCount);
                recordsCount = value;
            }
        }

        public int SelectColumnIndex { get => selectColumnIndex; set => selectColumnIndex = value; }


        // 图层句柄
        private readonly int _layerHandle=-1;


        private readonly AxMapWinGIS.AxMap _axMap;

        // 图例控件引用
        private readonly MWLite.Symbology.LegendControl.Legend _legend;

        // 图层管理，注意该图层是自定义的 不是mapwingis定义的layer
        private readonly Layer _layer = null;

        // shapefile对象
        private readonly Shapefile _shapefile = null;

        //记录有效字段数（前两列分别为索引列和类型列）
        private int fieldsCount = 2;

        //记录元素数
        private int recordsCount = 0;

        //数据表
        private DataTable dataTable;

        //初始化一个添加字段窗体对象
        AddFieldsForm addFieldsForm = new AddFieldsForm();

        //右键列名时的对应列名
        private int selectColumnIndex=-1;

        //初始化一个字段可见性窗体对象
        FieldsVisibleForm fieldsVisibleForm;

        //字段名集合
        List<string> fieldsNameList = new List<string>();



        public AttributesForm(AxMapWinGIS.AxMap axMap,MWLite.Symbology.LegendControl.Legend legend, int layerHandle)
        {
            InitializeComponent();
            _axMap = axMap;
            _legend = legend;//获取Legend控件对象
            _layerHandle = layerHandle;//获取选中的对应图层句柄
            _layer = _legend.GetLayer(_layerHandle);//根据句柄获取图层
            _shapefile = _layer.GetObject() as Shapefile;//获得图层对应shp对象

            attributeDGV.ReadOnly = true;

            OnCountChanged += afterCountChanged;

            

           

        }

        private delegate void action(Type type);

        //字段数改变委托
        private delegate void CountChanged(object sender,int newRecordsCount,int newFieldValue);

        //字段数改变委托事件
        private event CountChanged OnCountChanged;

        //字段数/记录数改变后发生的方法
        private void afterCountChanged(object sender, int newRecordsCount,int newFieldsCount)
        {
            label1.Text = Convert.ToString(newRecordsCount) + " Numbers in " + Convert.ToString(newFieldsCount) + " Fields";
        }

        //记录事件触发函数
        private void whenCountChanged(object sender,int newRecordCount,int newFieldsCount)
        {
            if (OnCountChanged != null)
                OnCountChanged(sender,newRecordCount,newFieldsCount);

        }
        

        /// <summary>
        /// 根据数据类型做一些事
        /// </summary>
        private void doSthByFieldType(FieldType fieldType,action action)
        {
            switch (fieldType)
            {
                case FieldType.BOOLEAN_FIELD:
                    action(typeof(Boolean));
                    break;
                case FieldType.DATE_FIELD:
                    action(typeof(DateTime));            
                    break;
                case FieldType.DOUBLE_FIELD:
                    action(typeof(Double));            
                    break;
                case FieldType.INTEGER_FIELD:
                    action(typeof(Int32));                  
                    break;
                case FieldType.STRING_FIELD:
                    action(typeof(String));                    
                    break;
            }
        }

      

        /// <summary>
        /// 加入新的一列数据列
        /// </summary>
        /// <param name="fieldType"></param>
        /// <param name="name"></param>
        private void addNewColumn(FieldType fieldType,string name)
        {
            doSthByFieldType(fieldType, (type) =>
            {
                dataTable.Columns.Add(new DataColumn(name, type));
            });//定义匿名方法,同时将该方法订阅给了Action,然后将该匿名方法作参数传入此doSthByFieldType方法
        }      //因为这里使用了匿名方法，或者该参数是对应委托里订阅有的方法名也可以



        private void AttributesForm_Load(object sender, EventArgs e)
        {
            attributeDGV.ReadOnly = true;//属性表只读开启

            dataTable = new DataTable();//新建数据表初始化

            dataTable.Columns.Add(new DataColumn("FID", typeof(Int32)));//新增第一列作为索引列
            dataTable.Columns.Add(new DataColumn("Shape*", typeof(String)));//新增第二列作为类型列

            for (int i = 0; i < _shapefile.Table.NumFields; i++)
            {
                addNewColumn(_shapefile.Table.Field[i].Type, _shapefile.Table.Field[i].Name);

                FieldsCount++;//逐列记录数
                
            }//添加字段(列)



            //后逐行插入
            for (int j = 0; j < _shapefile.Table.NumRows; j++)
            {
                DataRow dataRow = dataTable.NewRow();//生成数据表的新的一行

                dataRow[0] = j;//每行的第一列逐行插入FID

                switch (_shapefile.Shape[j].ShapeType)
                {
                    case ShpfileType.SHP_MULTIPATCH:
                        dataRow[1] = "MULTIPATCH";
                        break;
                    case ShpfileType.SHP_MULTIPOINT:
                        dataRow[1] = "MULTIPOINT";
                        break;
                    case ShpfileType.SHP_MULTIPOINTM:
                        dataRow[1] = "MULTIPOINTM";
                        break;
                    case ShpfileType.SHP_MULTIPOINTZ:
                        dataRow[1] = "MULTIPOINTZ";
                        break;
                    case ShpfileType.SHP_NULLSHAPE:
                        dataRow[1] = "NULLSHAPE";
                        break;
                    case ShpfileType.SHP_POINT:
                        dataRow[1] = "POINT";
                        break;
                    case ShpfileType.SHP_POINTM:
                        dataRow[1] = "POINTM";
                        break;
                    case ShpfileType.SHP_POINTZ:
                        dataRow[1] = "POINTZ";
                        break;
                    case ShpfileType.SHP_POLYGON:
                        dataRow[1] = "POLYGON";
                        break;
                    case ShpfileType.SHP_POLYGONM:
                        dataRow[1] = "POLYGONM";
                        break;
                    case ShpfileType.SHP_POLYGONZ:
                        dataRow[1] = "POLYGONZ";
                        break;
                    case ShpfileType.SHP_POLYLINE:
                        dataRow[1] = "POLYLINE";
                        break;
                    case ShpfileType.SHP_POLYLINEM:
                        dataRow[1] = "POLYLINEM";
                        break;
                    case ShpfileType.SHP_POLYLINEZ:
                        dataRow[1] = "POLYLINEZ";
                        break;  

                }//获取每个shape的类型作插入到第二列类型列

                for (int i = 0; i < _shapefile.Table.NumFields; i++)
                {

                    dataRow[i+2] = _shapefile.CellValue[i,j];//数据对应插入，i+1为除FID的字段列数，j为shp元素行数
                    
                }//先对行逐列插入

                RecordsCount++;//逐行记录数

                dataTable.Rows.Add(dataRow);
            }

            //显示记录数和字段数
            label1.Text = Convert.ToString(RecordsCount)+" Numbers in "+ Convert.ToString(FieldsCount) + " Fields";

            //该数据表作为数据源赋给属性表
            attributeDGV.DataSource = dataTable;

            for(int  i = 0; i < fieldsCount; i++)
            {
                fieldsNameList.Add(attributeDGV.Columns[i].Name);
            }

            for (int i = 0; i < attributeDGV.Columns.Count; i++)
                attributeDGV.Columns[i].HeaderCell.ContextMenuStrip = columnsContextMenuStrip1;


        }


        //双击行头缩放至所选形状范围
        private void attributeDGV_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _axMap.ZoomToShape(_layerHandle,e.RowIndex);

        }


        //开始编辑按钮
        private void startEditMenuItem_Click(object sender, EventArgs e)
        {
            attributeDGV.ReadOnly = false;

            _shapefile.Table.StartEditingTable(); 
        }


        //停止编辑按钮
        private void stopEditMenuItem_Click(object sender, EventArgs e)
        {
            attributeDGV.ReadOnly = true;

            _shapefile.Table.StopEditingTable();
        }


        //数据改变事件
        private void attributeDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
                //属性表显示新值
                var newValue = attributeDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                //改变对应shp文件中的值
                _shapefile.EditCellValue(e.ColumnIndex - 2, e.RowIndex, newValue);
            
        }
        

        //添加字段按钮
        private void addFieldMenuItem_Click(object sender, EventArgs e)
        {

            addFieldsForm.Show();
            addFieldsForm.FormClosed += (s, ee) =>
            {
                if (addFieldsForm.FieldName != null )
                {
                    addNewColumn(addFieldsForm.FieldType, addFieldsForm.FieldName);

                    FieldsCount++;

                    _shapefile.StartEditingTable();
                    _shapefile.EditAddField(addFieldsForm.FieldName,addFieldsForm.FieldType,addFieldsForm.Precision,addFieldsForm.Width);
                    _shapefile.StopEditingTable();
                }
            };
        }

        private void 更改列名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (SelectColumnIndex<0)
                MessageBox.Show("该字段为默认字段名无法修改", "提示", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            else
            {

                string newColumnsName = Interaction.InputBox("请输入新的字段名：", "新字段名输入框", "", -1, -1);

                try
                {
                    attributeDGV.Columns[SelectColumnIndex].Name = newColumnsName;

                    _shapefile.Field[SelectColumnIndex - 2].Name = newColumnsName;

                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("新字段名不可为空！");
                }
            }

                
            
        }

        
        private void 删除字段ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SelectColumnIndex > -1)
            {
                
            }
        }


        private void 可见性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fieldsCount > -1)
            {
                fieldsVisibleForm = new FieldsVisibleForm(fieldsNameList,fieldsCount);
                fieldsVisibleForm.Show();
                fieldsVisibleForm.eventVisibleChanged += new FieldsVisibleForm.delegateVisibleChanged(afterVisibleChanged);
            }
        }

        //可见性改变方法（在子窗体使用）
        private void afterVisibleChanged(int i,CheckState c)
        {
            bool b = true;
            if (c == CheckState.Checked)
                b = true;
            else if (c == CheckState.Unchecked)
                b = false;
            attributeDGV.Columns[i].Visible = b;
        }

        //编辑数据类型不一致
        private void attributeDGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("新数据类型不一致，请重新输入！");
        }


        private void attributeDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelectColumnIndex = e.ColumnIndex;
        }
    }
}
