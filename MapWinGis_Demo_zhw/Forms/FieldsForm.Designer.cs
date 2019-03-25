namespace MapWinGis.ShapeEditor.Forms
{
    partial class AttributesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.editMenuStrip = new System.Windows.Forms.MenuStrip();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.可见性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFieldMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQL查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editInfo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.attributeDGV = new System.Windows.Forms.DataGridView();
            this.columnsContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.更改列名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除字段ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.editMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attributeDGV)).BeginInit();
            this.columnsContextMenuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.editMenuStrip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1234, 28);
            this.panel1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Image = global::MapWinGis_Demo_zhw.Properties.Resources.减号;
            this.button2.Location = new System.Drawing.Point(1152, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 23);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::MapWinGis_Demo_zhw.Properties.Resources.关闭;
            this.button1.Location = new System.Drawing.Point(1185, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // editMenuStrip
            // 
            this.editMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.editMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑ToolStripMenuItem,
            this.addFieldMenuItem,
            this.查询ToolStripMenuItem});
            this.editMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.editMenuStrip.Name = "editMenuStrip";
            this.editMenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.editMenuStrip.Size = new System.Drawing.Size(1234, 28);
            this.editMenuStrip.TabIndex = 0;
            this.editMenuStrip.Text = "编辑";
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startEditMenuItem,
            this.stopEditMenuItem,
            this.可见性ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // startEditMenuItem
            // 
            this.startEditMenuItem.Name = "startEditMenuItem";
            this.startEditMenuItem.Size = new System.Drawing.Size(159, 26);
            this.startEditMenuItem.Text = "开始编辑";
            this.startEditMenuItem.Click += new System.EventHandler(this.startEditMenuItem_Click);
            // 
            // stopEditMenuItem
            // 
            this.stopEditMenuItem.Name = "stopEditMenuItem";
            this.stopEditMenuItem.Size = new System.Drawing.Size(159, 26);
            this.stopEditMenuItem.Text = "停止编辑";
            this.stopEditMenuItem.Click += new System.EventHandler(this.stopEditMenuItem_Click);
            // 
            // 可见性ToolStripMenuItem
            // 
            this.可见性ToolStripMenuItem.Name = "可见性ToolStripMenuItem";
            this.可见性ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.可见性ToolStripMenuItem.Text = "字段可见性";
            this.可见性ToolStripMenuItem.Click += new System.EventHandler(this.可见性ToolStripMenuItem_Click);
            // 
            // addFieldMenuItem
            // 
            this.addFieldMenuItem.Name = "addFieldMenuItem";
            this.addFieldMenuItem.Size = new System.Drawing.Size(81, 24);
            this.addFieldMenuItem.Text = "添加字段";
            this.addFieldMenuItem.Click += new System.EventHandler(this.addFieldMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空选择ToolStripMenuItem,
            this.sQL查询ToolStripMenuItem});
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.查询ToolStripMenuItem.Text = "查询";
            // 
            // 清空选择ToolStripMenuItem
            // 
            this.清空选择ToolStripMenuItem.Name = "清空选择ToolStripMenuItem";
            this.清空选择ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.清空选择ToolStripMenuItem.Text = "清空选择";
            this.清空选择ToolStripMenuItem.Click += new System.EventHandler(this.清空选择ToolStripMenuItem_Click);
            // 
            // sQL查询ToolStripMenuItem
            // 
            this.sQL查询ToolStripMenuItem.Name = "sQL查询ToolStripMenuItem";
            this.sQL查询ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.sQL查询ToolStripMenuItem.Text = "SQL查询";
            this.sQL查询ToolStripMenuItem.Click += new System.EventHandler(this.sQL查询ToolStripMenuItem_Click);
            // 
            // editInfo
            // 
            this.editInfo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.editInfo.BackColor = System.Drawing.Color.White;
            this.editInfo.Location = new System.Drawing.Point(633, 6);
            this.editInfo.Name = "editInfo";
            this.editInfo.Size = new System.Drawing.Size(270, 18);
            this.editInfo.TabIndex = 1;
            this.editInfo.Text = "未编辑状态";
            this.editInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.attributeDGV, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1234, 655);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // attributeDGV
            // 
            this.attributeDGV.AllowUserToResizeColumns = false;
            this.attributeDGV.AllowUserToResizeRows = false;
            this.attributeDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attributeDGV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.attributeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attributeDGV.Location = new System.Drawing.Point(23, 2);
            this.attributeDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.attributeDGV.Name = "attributeDGV";
            this.attributeDGV.RowTemplate.Height = 30;
            this.attributeDGV.Size = new System.Drawing.Size(1188, 651);
            this.attributeDGV.TabIndex = 0;
            this.attributeDGV.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.attributeDGV_CellBeginEdit);
            this.attributeDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.attributeDGV_CellValueChanged);
            this.attributeDGV.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.attributeDGV_DataError);
            this.attributeDGV.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.attributeDGV_RowHeaderMouseDoubleClick);
            this.attributeDGV.KeyUp += new System.Windows.Forms.KeyEventHandler(this.attributeDGV_KeyUp);
            this.attributeDGV.MouseLeave += new System.EventHandler(this.attributeDGV_MouseLeave);
            // 
            // columnsContextMenuStrip1
            // 
            this.columnsContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.columnsContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更改列名ToolStripMenuItem,
            this.删除字段ToolStripMenuItem2});
            this.columnsContextMenuStrip1.Name = "columnsContextMenuStrip1";
            this.columnsContextMenuStrip1.Size = new System.Drawing.Size(139, 52);
            // 
            // 更改列名ToolStripMenuItem
            // 
            this.更改列名ToolStripMenuItem.Name = "更改列名ToolStripMenuItem";
            this.更改列名ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.更改列名ToolStripMenuItem.Text = "更改列名";
            this.更改列名ToolStripMenuItem.Click += new System.EventHandler(this.更改列名ToolStripMenuItem_Click);
            // 
            // 删除字段ToolStripMenuItem2
            // 
            this.删除字段ToolStripMenuItem2.Name = "删除字段ToolStripMenuItem2";
            this.删除字段ToolStripMenuItem2.Size = new System.Drawing.Size(138, 24);
            this.删除字段ToolStripMenuItem2.Text = "删除字段";
            this.删除字段ToolStripMenuItem2.Click += new System.EventHandler(this.删除字段ToolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(617, 18);
            this.label1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.editInfo);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 683);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1234, 30);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // AttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 713);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.editMenuStrip;
            this.Name = "AttributesForm";
            this.Text = "AttributesForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AttributesForm_FormClosing);
            this.Load += new System.EventHandler(this.AttributesForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.editMenuStrip.ResumeLayout(false);
            this.editMenuStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.attributeDGV)).EndInit();
            this.columnsContextMenuStrip1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView attributeDGV;
        private System.Windows.Forms.MenuStrip editMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFieldMenuItem;
        private System.Windows.Forms.ContextMenuStrip columnsContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 更改列名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除字段ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 可见性ToolStripMenuItem;
        private System.Windows.Forms.Label editInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQL查询ToolStripMenuItem;
    }
}