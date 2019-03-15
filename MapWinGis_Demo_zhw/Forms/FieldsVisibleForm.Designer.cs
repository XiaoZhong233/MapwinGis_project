namespace MapWinGis_Demo_zhw.Forms
{
    partial class FieldsVisibleForm
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
            this.visibleFieldsCLB = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // visibleFieldsCLB
            // 
            this.visibleFieldsCLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visibleFieldsCLB.FormattingEnabled = true;
            this.visibleFieldsCLB.Location = new System.Drawing.Point(0, 0);
            this.visibleFieldsCLB.Name = "visibleFieldsCLB";
            this.visibleFieldsCLB.Size = new System.Drawing.Size(305, 342);
            this.visibleFieldsCLB.TabIndex = 1;
            this.visibleFieldsCLB.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.visibleFieldsCLB_ItemCheck);
            // 
            // FieldsVisibleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 342);
            this.Controls.Add(this.visibleFieldsCLB);
            this.Name = "FieldsVisibleForm";
            this.Text = "隐藏/显示字段";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox visibleFieldsCLB;
    }
}