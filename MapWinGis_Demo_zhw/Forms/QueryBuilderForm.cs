using MapWinGIS;
using MapWinGis_Demo_zhw.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapWinGis_Demo_zhw.Forms
{
    public partial class QueryBuilderForm : Form
    {

        
        private int layerHandle = -1;
        private Shapefile shapefile = null;
        private string sql = "";
        private string error = "";
        private object result = "";


        public delegate void QueryResultChange(object result);
        public event QueryResultChange onQueryResultChange = null;

        private void fireQueryResultChange(object result)
        {
            if (onQueryResultChange != null)
            {
                onQueryResultChange(result);
            }
        }


        public string Error { get => error; set => error = value; }
        public object Result {
            get
            {
                return result;
            }
            set
            {
                
                result = value;
                fireQueryResultChange(value);
    
               
            }
            }




        public QueryBuilderForm()
        {
            InitializeComponent();
            this.layerHandle = App.Legend.SelectedLayer;
            shapefile = App.Map.get_Shapefile(layerHandle);
            init();
        }

        public QueryBuilderForm(int layerHandle)
        {
            InitializeComponent();
            this.layerHandle = layerHandle;
            shapefile = App.Map.get_Shapefile(layerHandle);
            init();
        }

        private void init()
        {
            this.TopMost = true;
            initSQL();
            initFieldBox();
            initValueBox();
            initBtn();
            initSQLBox();
        }


        private void initSQL()
        {
            sql = "";
            string layerName = App.Map.get_LayerFilename(layerHandle);
            string filename = Path.GetFileNameWithoutExtension(layerName);
            SQL1.Text = "SELECT * FROM [" + filename + "] WHERE ";
            sql += SQL1.Text;
        }

        private void initFieldBox()
        {
            if (shapefile == null)
            {
                return;
            }
            for(int i = 0; i < shapefile.NumFields; i++)
            {
                fieldsBox.Items.Add(shapefile.Field[i].Name);
            }

            fieldsBox.SelectedIndexChanged += FieldsBox_SelectedIndexChanged;
            //fieldsBox.MouseDoubleClick += FieldsBox_DoubleClick;
        }

        //private void FieldsBox_DoubleClick(object sender, EventArgs e)
        //{
        //    ValueBox.Items.Clear();
        //    sqlBox.Text += " [" + fieldsBox.SelectedItem.ToString() + "] ";
        //}

        private void initValueBox()
        {
            ValueBox.SelectedIndexChanged += ValueBox_SelectedIndexChanged;
        }

        private void ValueBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ValueBox.SelectedItem is string)
            {
                string s = ValueBox.SelectedItem as string;
                sqlBox.Text += "\"" + s + "\"";
                return;
            }
            sqlBox.Text += " "+ValueBox.SelectedItem.ToString()+" ";
        }

        private void initBtn()
        {
            lessBtn.Click += onOperationBtnClick;
            lessequalBtn.Click += onOperationBtnClick;
            morethanBtn.Click += onOperationBtnClick;
            moreequalBtn.Click += onOperationBtnClick;
            equalBtn.Click += onOperationBtnClick;
            unequalBtn.Click += onOperationBtnClick;
            rightBracketBtn.Click += onOperationBtnClick;
            andBtn.Click += onOperationBtnClick;
            orBtn.Click += onOperationBtnClick;
            notBtn.Click += onOperationBtnClick;
            likeBtn.Click += onOperationBtnClick;
            asBtn.Click += onOperationBtnClick;
            _Btn.Click += onOperationBtnClick;
            getValueBtn.Click += (s, e) =>
            {
                ValueBox.Items.Clear();
                int index = fieldsBox.SelectedIndex;
                if (index != -1)
                {
                    for (int i = 0; i < shapefile.Table.NumRows; i++)
                    {
                        ValueBox.Items.Add(shapefile.Table.CellValue[index, i]);
                    }
                }
            };
            vetifyBtn.Click += (s, e) =>
            {
                error = "";
                result = "";
                bool success = query(ref result,ref error);
                Result = result;

                int[] shapes = result as int[];
                if (success)
                {
                    if (shapes != null)
                    {
                        MessageHelper.Info("有效表达式，查询到" + shapes.Length + "条记录");
                    }
                }
                else
                {
                    MessageHelper.Warn(error);
                }
            };

            testBtn.Click += (s, e) =>
            {
                queryToUI();
            };

            clearBtn.Click += (s, e) =>
            {
                sqlBox.Clear();
            };

            okBtn.Click += (s, e) =>
            {
                queryToUI();
                this.Close();
            };

            cancelBtn.Click += (s, e) =>
            {
                this.Close();
            };

        }

        private void initSQLBox()
        {
            sqlBox.TextChanged += SqlBox_TextChanged;
        }

        private void SqlBox_TextChanged(object sender, EventArgs e)
        {
            sql = "";
            sql += sqlBox.Text;
      
            query(ref result,ref error);
            Result = result;

        }


        private void queryToUI()
        {

            bool success = query(ref result, ref error);
            Result = result;
            if (success)
            {

                vetifyInfo.ForeColor = Color.Green;
                shapefile.SelectNone();
                int[] shapes = result as int[];
                if (shapes != null)
                {
                    for (int i = 0; i < shapes.Length; i++)
                    {
                        shapefile.set_ShapeSelected(shapes[i], true);
                    }
                }
                App.Map.ZoomToSelected(layerHandle);
                App.RefreshUI();
            }
            else
            {
                MessageHelper.Warn(error);
                vetifyInfo.ForeColor = Color.Red;
            }
        }

        private bool query(ref object result,ref string error)
        {

            //vetifyInfo.ForeColor = Color.Green;
            bool success = shapefile.Table.Query(sql,ref result,ref error);
            Result = result;
            vetifyInfo.Text = error;
            //MessageHelper.Info(sql +"\n"+ success);
            if (success)
            {
                vetifyInfo.ForeColor = Color.Green;
                vetifyInfo.Text = "valid";
            }
            else
            {
                vetifyInfo.ForeColor = Color.Red;
                if (error.ToLower().Equals("selection is empty"))
                {
                    vetifyInfo.ForeColor = Color.Blue;
                    vetifyInfo.Text = error;
                }

           
                
            }

            return success;
        }

        private void onOperationBtnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null)
                return;
            switch (btn.Text)
            {
                case "=":
                    concatSQLString("=");
                    break;
                case "<>":
                    concatSQLString("<>");
                    break;
                case "LIKE":
                    concatSQLString("LIKE");
                    break;
                case "<":
                    concatSQLString("<");
                    break;
                case "<=":
                    concatSQLString("<=");
                    break;
                case "AND":
                    concatSQLString("AND");
                    break;
                case ">":
                    concatSQLString(">");
                    break;
                case ">=":
                    concatSQLString(">=");
                    break;
                case "OR":
                    concatSQLString("OR");
                    break;
                case "(":
                    concatSQLString("(");
                    break;
                case ")":
                    concatSQLString(")");
                    break;
                case "NOT":
                    concatSQLString("NOT");
                    break;
                case "_":
                    concatSQLString("_");
                    break;
                default:
                    break;
            }
        }

        private void FieldsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueBox.Items.Clear();
            sqlBox.Text += " [" + fieldsBox.SelectedItem.ToString() + "] ";
            int index = fieldsBox.SelectedIndex;
            if(index != -1)
            {
                for(int i = 0; i < shapefile.Table.NumRows; i++)
                {
                    if(shapefile.Table.CellValue[index, i] == null)
                    {
                        continue;
                    }
                    ValueBox.Items.Add(shapefile.Table.CellValue[index, i]);
                }
            }
        }


        private void concatSQLString(string sql)
        {
            sqlBox.Text = String.Concat(sqlBox.Text, " ", sql);
        }


    }
}
