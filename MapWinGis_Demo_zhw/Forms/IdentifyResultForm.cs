using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MapWinGis_Demo_zhw.Forms
{
    /// <summary>
    /// 识别结果窗口
    /// 采用单例模式
    /// </summary>
    public partial class IdentifyResultForm : Form
    {
        private List<DockContent> dockContents = new List<DockContent>();
        public static IdentifyResultForm _identifyResultForm = null;



        public IdentifyResultForm IdentifyForm { get { return _identifyResultForm; } }


        
        public static IdentifyResultForm getInstance()
        {
            if (IdentifyResultForm._identifyResultForm == null)
            {
                IdentifyResultForm._identifyResultForm = new IdentifyResultForm();

            }
            return IdentifyResultForm._identifyResultForm;
        }


        private  IdentifyResultForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            _identifyResultForm = this;
            this.FormClosing += IdentifyResultForm_FormClosing;
        }

        /// <summary>
        /// 这个是为了避免该窗口被gc掉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IdentifyResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();//隐藏被关闭的窗体 
            e.Cancel = true;//撤销窗体关闭操作 
            closeAllContents();
        }

        /// <summary>
        /// 清空子窗口
        /// </summary>
        private void closeAllContents()
        {
            foreach(DockContent dc in dockContents)
            {
                dc.Close();
                dc.Dispose();
            }
        }


        public void addForm(DockContent form,DockState dockState)
        {
            if (this.IsDisposed)
            {
                _identifyResultForm = new IdentifyResultForm();
            }
            form.Show(dockPanel1, dockState);
            dockContents.Add(form);
            form.Activate();
        }


       
    }
}
