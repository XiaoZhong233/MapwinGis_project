using MapWinGis.ShapeEditor.Forms;
using MapWinGIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapWinGis_Demo_zhw.Forms
{
    public partial class AddFieldsForm : Form
    {

        //AddFieldsForm窗体变量：

        //选择的字段类型        1
        private FieldType fieldType;

        //字段名                2
        private string fieldName;

        //字段精度
        private int precision;

        //字段宽度
        private int width;

        


        public string FieldName { get => fieldName; set => fieldName = value; }
        public FieldType FieldType { get => fieldType; set => fieldType = value; }
        public int Precision { get => precision; set => precision = value; }
        public int Width { get => width; set => width = value; }

        public AddFieldsForm()
        {
            InitializeComponent();

            fieldType = FieldType.STRING_FIELD;//初始化所选下标

            fieldName = null;//初始化字段名

            precision = 6;//初始化精度

            width = 6;

            precisionTextBox.Text = null;
            widthTextBox.Text = null;

            //添加字段类型
            fieldTypeCmbox.Items.Add(FieldType.STRING_FIELD);
            fieldTypeCmbox.Items.Add(FieldType.INTEGER_FIELD);
            fieldTypeCmbox.Items.Add(FieldType.DOUBLE_FIELD);
            fieldTypeCmbox.Items.Add(FieldType.BOOLEAN_FIELD);
            fieldTypeCmbox.Items.Add(FieldType.DATE_FIELD);

            fieldTypeCmbox.SelectedIndex = 0;
            
  
        }

        

        private void okBtn_Click(object sender, EventArgs e)
        {

            if(fieldTypeCmbox.SelectedItem is FieldType&&fieldNameTextBox.Text!=null)
            {
                fieldType = (FieldType)fieldTypeCmbox.SelectedItem;
                fieldName = fieldNameTextBox.Text;
                if(Convert.ToInt32(precisionTextBox.Text)!=6)
                    precision = Convert.ToInt32(precisionTextBox.Text);
                if(Convert.ToInt32(widthTextBox.Text)!=6)
                    width = Convert.ToInt32(widthTextBox.Text);
            }

            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
