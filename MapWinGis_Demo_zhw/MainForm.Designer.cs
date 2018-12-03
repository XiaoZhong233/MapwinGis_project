namespace MapWinGis_Demo_zhw
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.symbolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prosperityItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axMap1 = new AxMapWinGIS.AxMap();
            this.legend1 = new MWLite.Symbology.LegendControl.Legend();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.open_btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeAll_btn = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.recover_btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pan_btn = new System.Windows.Forms.ToolStripButton();
            this.zoomIn_btn = new System.Windows.Forms.ToolStripButton();
            this.zoomOut_btn = new System.Windows.Forms.ToolStripButton();
            this.select_btn = new System.Windows.Forms.ToolStripButton();
            this.table = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMap1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContextMenu
            // 
            this.ContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeItem,
            this.symbolItem,
            this.labelItem,
            this.prosperityItem,
            this.table});
            this.ContextMenu.Name = "contextMenuStrip1";
            this.ContextMenu.Size = new System.Drawing.Size(211, 152);
            this.ContextMenu.Text = "符号设置";
            // 
            // removeItem
            // 
            this.removeItem.Name = "removeItem";
            this.removeItem.Size = new System.Drawing.Size(210, 24);
            this.removeItem.Text = "移除";
            this.removeItem.Click += new System.EventHandler(this.removeItem_Click);
            // 
            // symbolItem
            // 
            this.symbolItem.Name = "symbolItem";
            this.symbolItem.Size = new System.Drawing.Size(210, 24);
            this.symbolItem.Text = "符号设置";
            this.symbolItem.Click += new System.EventHandler(this.symbolItem_Click);
            // 
            // labelItem
            // 
            this.labelItem.Name = "labelItem";
            this.labelItem.Size = new System.Drawing.Size(210, 24);
            this.labelItem.Text = "标注设置";
            this.labelItem.Click += new System.EventHandler(this.lableItem_Click);
            // 
            // prosperityItem
            // 
            this.prosperityItem.Name = "prosperityItem";
            this.prosperityItem.Size = new System.Drawing.Size(210, 24);
            this.prosperityItem.Text = "属性";
            this.prosperityItem.Click += new System.EventHandler(this.prosperityItem_Click);
            // 
            // axMap1
            // 
            this.axMap1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axMap1.Enabled = true;
            this.axMap1.Location = new System.Drawing.Point(285, 165);
            this.axMap1.Name = "axMap1";
            this.axMap1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMap1.OcxState")));
            this.axMap1.Size = new System.Drawing.Size(1234, 622);
            this.axMap1.TabIndex = 0;
            // 
            // legend1
            // 
            this.legend1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.legend1.BackColor = System.Drawing.Color.White;
            this.legend1.Location = new System.Drawing.Point(12, 165);
            this.legend1.Map = null;
            this.legend1.Name = "legend1";
            this.legend1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.legend1.SelectedLayer = -1;
            this.legend1.ShowGroupFolders = true;
            this.legend1.ShowLabels = false;
            this.legend1.Size = new System.Drawing.Size(255, 622);
            this.legend1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1531, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.fileToolStripMenuItem.Text = "文件";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.openToolStripMenuItem.Text = "打开";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open_btn,
            this.toolStripSeparator1,
            this.removeAll_btn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1531, 67);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // open_btn
            // 
            this.open_btn.Image = global::MapWinGis_Demo_zhw.Properties.Resources.open;
            this.open_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.open_btn.Name = "open_btn";
            this.open_btn.Padding = new System.Windows.Forms.Padding(10);
            this.open_btn.Size = new System.Drawing.Size(63, 64);
            this.open_btn.Text = "打开";
            this.open_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.open_btn.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 67);
            // 
            // removeAll_btn
            // 
            this.removeAll_btn.Image = global::MapWinGis_Demo_zhw.Properties.Resources.remove_all_layers;
            this.removeAll_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeAll_btn.Name = "removeAll_btn";
            this.removeAll_btn.Padding = new System.Windows.Forms.Padding(10);
            this.removeAll_btn.Size = new System.Drawing.Size(93, 64);
            this.removeAll_btn.Text = "清空图层";
            this.removeAll_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.removeAll_btn.Click += new System.EventHandler(this.removeAll_btn_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recover_btn,
            this.toolStripSeparator2,
            this.pan_btn,
            this.zoomIn_btn,
            this.zoomOut_btn,
            this.select_btn});
            this.toolStrip2.Location = new System.Drawing.Point(0, 95);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1531, 67);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // recover_btn
            // 
            this.recover_btn.Image = global::MapWinGis_Demo_zhw.Properties.Resources.zoom_layerNew;
            this.recover_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.recover_btn.Name = "recover_btn";
            this.recover_btn.Padding = new System.Windows.Forms.Padding(10);
            this.recover_btn.Size = new System.Drawing.Size(63, 64);
            this.recover_btn.Text = "复位";
            this.recover_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.recover_btn.Click += new System.EventHandler(this.recover_btn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 67);
            // 
            // pan_btn
            // 
            this.pan_btn.Image = global::MapWinGis_Demo_zhw.Properties.Resources.pan;
            this.pan_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pan_btn.Name = "pan_btn";
            this.pan_btn.Padding = new System.Windows.Forms.Padding(10);
            this.pan_btn.Size = new System.Drawing.Size(63, 64);
            this.pan_btn.Text = "漫游";
            this.pan_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.pan_btn.Click += new System.EventHandler(this.pan_btn_Click);
            // 
            // zoomIn_btn
            // 
            this.zoomIn_btn.Image = global::MapWinGis_Demo_zhw.Properties.Resources.zoom_out;
            this.zoomIn_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomIn_btn.Name = "zoomIn_btn";
            this.zoomIn_btn.Padding = new System.Windows.Forms.Padding(10);
            this.zoomIn_btn.Size = new System.Drawing.Size(63, 64);
            this.zoomIn_btn.Text = "放大";
            this.zoomIn_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.zoomIn_btn.Click += new System.EventHandler(this.zoomIn_btn_Click);
            // 
            // zoomOut_btn
            // 
            this.zoomOut_btn.Image = global::MapWinGis_Demo_zhw.Properties.Resources.zoom_in;
            this.zoomOut_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOut_btn.Name = "zoomOut_btn";
            this.zoomOut_btn.Padding = new System.Windows.Forms.Padding(10);
            this.zoomOut_btn.Size = new System.Drawing.Size(63, 64);
            this.zoomOut_btn.Text = "缩小";
            this.zoomOut_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.zoomOut_btn.Click += new System.EventHandler(this.zoomOut_btn_Click);
            // 
            // select_btn
            // 
            this.select_btn.Image = global::MapWinGis_Demo_zhw.Properties.Resources.select;
            this.select_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.select_btn.Name = "select_btn";
            this.select_btn.Padding = new System.Windows.Forms.Padding(10);
            this.select_btn.Size = new System.Drawing.Size(63, 64);
            this.select_btn.Text = "选择";
            this.select_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
            // 
            // table
            // 
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(210, 24);
            this.table.Text = "表";
            this.table.Click += new System.EventHandler(this.table_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1531, 799);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.legend1);
            this.Controls.Add(this.axMap1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.ContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMap1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxMapWinGIS.AxMap axMap1;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem removeItem;
        private MWLite.Symbology.LegendControl.Legend legend1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton open_btn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton removeAll_btn;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton recover_btn;
        private System.Windows.Forms.ToolStripButton pan_btn;
        private System.Windows.Forms.ToolStripButton zoomIn_btn;
        private System.Windows.Forms.ToolStripButton zoomOut_btn;
        private System.Windows.Forms.ToolStripButton select_btn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem symbolItem;
        private System.Windows.Forms.ToolStripMenuItem labelItem;
        private System.Windows.Forms.ToolStripMenuItem prosperityItem;
        private System.Windows.Forms.ToolStripMenuItem table;
    }
}

