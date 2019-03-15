namespace MapWinGis_Demo_zhw.Controls
{
    partial class IdentifierContextMenu
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxAllLayers = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCurrentLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxHotTracking = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxShowTooltip = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxAllLayers,
            this.ctxCurrentLayer,
            this.toolStripSeparator1,
            this.ctxHotTracking,
            this.ctxShowTooltip});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 134);
            // 
            // ctxAllLayers
            // 
            this.ctxAllLayers.Name = "ctxAllLayers";
            this.ctxAllLayers.Size = new System.Drawing.Size(210, 24);
            this.ctxAllLayers.Text = "识别所有图层";
            this.ctxAllLayers.Click += new System.EventHandler(this.ctxAllLayers_Click);
            // 
            // ctxCurrentLayer
            // 
            this.ctxCurrentLayer.Name = "ctxCurrentLayer";
            this.ctxCurrentLayer.Size = new System.Drawing.Size(210, 24);
            this.ctxCurrentLayer.Text = "识别当前图层";
            this.ctxCurrentLayer.Click += new System.EventHandler(this.ctxCurrentLayer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // ctxHotTracking
            // 
            this.ctxHotTracking.Name = "ctxHotTracking";
            this.ctxHotTracking.Size = new System.Drawing.Size(210, 24);
            this.ctxHotTracking.Text = "高亮追踪";
            this.ctxHotTracking.Click += new System.EventHandler(this.ctxHotTracking_Click);
            // 
            // ctxShowTooltip
            // 
            this.ctxShowTooltip.Name = "ctxShowTooltip";
            this.ctxShowTooltip.Size = new System.Drawing.Size(210, 24);
            this.ctxShowTooltip.Text = "显示摘要";
            this.ctxShowTooltip.Click += new System.EventHandler(this.ctxShowTooltip_Click);
            // 
            // IdentifierContextMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "IdentifierContextMenu";
            this.Size = new System.Drawing.Size(200, 173);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctxAllLayers;
        private System.Windows.Forms.ToolStripMenuItem ctxCurrentLayer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ctxHotTracking;
        private System.Windows.Forms.ToolStripMenuItem ctxShowTooltip;
    }
}
