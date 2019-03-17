namespace MWLite.Symbology.Forms
{
    partial class InformationForm
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
            this.informationDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.informationDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // informationDGV
            // 
            this.informationDGV.AllowUserToAddRows = false;
            this.informationDGV.AllowUserToDeleteRows = false;
            this.informationDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.informationDGV.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.informationDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.informationDGV.Location = new System.Drawing.Point(9, 11);
            this.informationDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.informationDGV.Name = "informationDGV";
            this.informationDGV.RowTemplate.Height = 30;
            this.informationDGV.Size = new System.Drawing.Size(892, 587);
            this.informationDGV.TabIndex = 0;
            // 
            // InformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 609);
            this.Controls.Add(this.informationDGV);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "InformationForm";
            this.Text = "Information";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InformationForm_FormClosed);
            this.Load += new System.EventHandler(this.InformationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.informationDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView informationDGV;
    }
}