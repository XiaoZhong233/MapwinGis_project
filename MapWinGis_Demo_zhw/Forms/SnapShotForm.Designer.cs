namespace MapWinGis_Demo_zhw.Forms
{
    partial class SnapShotForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SnapShotForm));
            this.MapPreview = new AxMapWinGIS.AxMap();
            this.PreviewMapContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.全局视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当前视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除预览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.MapPreview)).BeginInit();
            this.PreviewMapContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapPreview
            // 
            this.MapPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapPreview.Enabled = true;
            this.MapPreview.Location = new System.Drawing.Point(0, 0);
            this.MapPreview.Name = "MapPreview";
            this.MapPreview.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MapPreview.OcxState")));
            this.MapPreview.Size = new System.Drawing.Size(398, 318);
            this.MapPreview.TabIndex = 4;
            // 
            // PreviewMapContextMenuStrip
            // 
            this.PreviewMapContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PreviewMapContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全局视图ToolStripMenuItem,
            this.当前视图ToolStripMenuItem,
            this.清除预览ToolStripMenuItem});
            this.PreviewMapContextMenuStrip.Name = "PreviewMapContextMenuStrip";
            this.PreviewMapContextMenuStrip.Size = new System.Drawing.Size(211, 104);
            // 
            // 全局视图ToolStripMenuItem
            // 
            this.全局视图ToolStripMenuItem.Name = "全局视图ToolStripMenuItem";
            this.全局视图ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.全局视图ToolStripMenuItem.Text = "全局视图";
            this.全局视图ToolStripMenuItem.Click += new System.EventHandler(this.全局视图ToolStripMenuItem_Click);
            // 
            // 当前视图ToolStripMenuItem
            // 
            this.当前视图ToolStripMenuItem.Name = "当前视图ToolStripMenuItem";
            this.当前视图ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.当前视图ToolStripMenuItem.Text = "当前视图";
            this.当前视图ToolStripMenuItem.Click += new System.EventHandler(this.当前视图ToolStripMenuItem_Click);
            // 
            // 清除预览ToolStripMenuItem
            // 
            this.清除预览ToolStripMenuItem.Name = "清除预览ToolStripMenuItem";
            this.清除预览ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.清除预览ToolStripMenuItem.Text = "清除预览";
            this.清除预览ToolStripMenuItem.Click += new System.EventHandler(this.清除预览ToolStripMenuItem_Click);
            // 
            // SnapShotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 318);
            this.Controls.Add(this.MapPreview);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "SnapShotForm";
            this.Text = "Preview 鸟瞰";
            ((System.ComponentModel.ISupportInitialize)(this.MapPreview)).EndInit();
            this.PreviewMapContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxMapWinGIS.AxMap MapPreview;
        private System.Windows.Forms.ContextMenuStrip PreviewMapContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 全局视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 当前视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除预览ToolStripMenuItem;
    }
}