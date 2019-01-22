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
    public partial class FieldsVisibleForm : Form
    {
        //字段数
        private readonly int fieldsCount;
        //字段名集合
        private readonly List<string> fieldsNameList;

        //状态改变的字段下标
        private static int currentFieldIndex;

        private static CheckState isFieldVisible;

        public int FieldsCount { get => fieldsCount; }

        public List<string> FieldsNameList => fieldsNameList;

        public static int ChangeIndex{ get => currentFieldIndex; set => currentFieldIndex = value; }
        public static CheckState IsFieldVisible { get => isFieldVisible; set => isFieldVisible = value; }

        public FieldsVisibleForm(List<string> fnl,int fc)
        {
            InitializeComponent();

            fieldsNameList= fnl;

            fieldsCount = fc;

            currentFieldIndex = -1;

            IsFieldVisible = CheckState.Checked;

        

            for (int i = 0; i < FieldsCount; i++)
            {
                
                visibleFieldsCLB.Items.Add(FieldsNameList[i]);
             
            }
           

        }

        public delegate void delegateVisibleChanged(int i, CheckState v);

        public event delegateVisibleChanged eventVisibleChanged;

        //勾选状态改变时
        private void visibleFieldsCLB_SelectedValueChanged(object sender, EventArgs e)
        {
          

            currentFieldIndex = visibleFieldsCLB.SelectedIndex;


            
        }

        private void visibleFieldsCLB_ItemCheck(object sender, ItemCheckEventArgs e)
        {

                currentFieldIndex = e.Index;
            IsFieldVisible = e.CurrentValue;
            if (eventVisibleChanged != null) { eventVisibleChanged(e.Index,e.CurrentValue); }

        }
    }
}
