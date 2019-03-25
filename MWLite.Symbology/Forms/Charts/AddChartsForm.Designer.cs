﻿namespace MWLite.Symbology.Forms.Charts
{
    partial class AddChartsForm
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.optPosition4 = new System.Windows.Forms.RadioButton();
            this.optPosition3 = new System.Windows.Forms.RadioButton();
            this.optPosition2 = new System.Windows.Forms.RadioButton();
            this.optPosition1 = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.optPosition4);
            this.groupBox5.Controls.Add(this.optPosition3);
            this.groupBox5.Controls.Add(this.optPosition2);
            this.groupBox5.Controls.Add(this.optPosition1);
            this.groupBox5.Location = new System.Drawing.Point(16, 3);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Size = new System.Drawing.Size(387, 173);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Position";
            // 
            // optPosition4
            // 
            this.optPosition4.AutoSize = true;
            this.optPosition4.Location = new System.Drawing.Point(43, 135);
            this.optPosition4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optPosition4.Name = "optPosition4";
            this.optPosition4.Size = new System.Drawing.Size(140, 19);
            this.optPosition4.TabIndex = 3;
            this.optPosition4.Text = "Interior point";
            this.optPosition4.UseVisualStyleBackColor = true;
            // 
            // optPosition3
            // 
            this.optPosition3.AutoSize = true;
            this.optPosition3.Location = new System.Drawing.Point(43, 102);
            this.optPosition3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optPosition3.Name = "optPosition3";
            this.optPosition3.Size = new System.Drawing.Size(140, 19);
            this.optPosition3.TabIndex = 2;
            this.optPosition3.Text = "Interior point";
            this.optPosition3.UseVisualStyleBackColor = true;
            // 
            // optPosition2
            // 
            this.optPosition2.AutoSize = true;
            this.optPosition2.Location = new System.Drawing.Point(43, 68);
            this.optPosition2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optPosition2.Name = "optPosition2";
            this.optPosition2.Size = new System.Drawing.Size(58, 19);
            this.optPosition2.TabIndex = 1;
            this.optPosition2.Text = "质心";
            this.optPosition2.UseVisualStyleBackColor = true;
            // 
            // optPosition1
            // 
            this.optPosition1.AutoSize = true;
            this.optPosition1.Checked = true;
            this.optPosition1.Location = new System.Drawing.Point(43, 35);
            this.optPosition1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optPosition1.Name = "optPosition1";
            this.optPosition1.Size = new System.Drawing.Size(58, 19);
            this.optPosition1.TabIndex = 0;
            this.optPosition1.TabStop = true;
            this.optPosition1.Text = "中心";
            this.optPosition1.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(280, 183);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 30);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(149, 183);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(123, 30);
            this.btnOk.TabIndex = 26;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // AddChartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(416, 218);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AddChartsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chart generation";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton optPosition4;
        private System.Windows.Forms.RadioButton optPosition3;
        private System.Windows.Forms.RadioButton optPosition2;
        private System.Windows.Forms.RadioButton optPosition1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}