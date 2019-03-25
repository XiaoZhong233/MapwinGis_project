﻿using MWLite.Symbology.Controls;
using MWLite.Symbology.Controls.ColorPicker;

namespace MWLite.Symbology.Forms.Labels
{
    partial class FontGradientForm
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
            this.label8 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUseGradient = new System.Windows.Forms.CheckBox();
            this.clpFont1 = new MWLite.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.clpFont2 = new MWLite.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.icbFontGradient = new MWLite.Symbology.Controls.ImageCombo();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 117;
            this.label8.Text = "颜色混合";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(157, 143);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 30);
            this.btnOk.TabIndex = 122;
            this.btnOk.Text = "确认";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(285, 143);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 123;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUseGradient);
            this.groupBox1.Controls.Add(this.clpFont1);
            this.groupBox1.Controls.Add(this.clpFont2);
            this.groupBox1.Controls.Add(this.icbFontGradient);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(13, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(392, 129);
            this.groupBox1.TabIndex = 124;
            this.groupBox1.TabStop = false;
            // 
            // chkUseGradient
            // 
            this.chkUseGradient.AutoSize = true;
            this.chkUseGradient.Location = new System.Drawing.Point(71, 35);
            this.chkUseGradient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkUseGradient.Name = "chkUseGradient";
            this.chkUseGradient.Size = new System.Drawing.Size(74, 19);
            this.chkUseGradient.TabIndex = 121;
            this.chkUseGradient.Text = "可用性";
            this.chkUseGradient.UseVisualStyleBackColor = true;
            this.chkUseGradient.CheckedChanged += new System.EventHandler(this.chkUseGradient_CheckedChanged);
            // 
            // clpFont1
            // 
            this.clpFont1.Color = System.Drawing.Color.Black;
            this.clpFont1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpFont1.DropDownHeight = 1;
            this.clpFont1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpFont1.FormattingEnabled = true;
            this.clpFont1.IntegralHeight = false;
            this.clpFont1.Items.AddRange(new object[] {
            "Color"});
            this.clpFont1.Location = new System.Drawing.Point(165, 78);
            this.clpFont1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clpFont1.Name = "clpFont1";
            this.clpFont1.Size = new System.Drawing.Size(97, 26);
            this.clpFont1.TabIndex = 118;
            this.clpFont1.SelectedColorChanged += new System.EventHandler(this.GUI2Settings);
            // 
            // clpFont2
            // 
            this.clpFont2.Color = System.Drawing.Color.Black;
            this.clpFont2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpFont2.DropDownHeight = 1;
            this.clpFont2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpFont2.FormattingEnabled = true;
            this.clpFont2.IntegralHeight = false;
            this.clpFont2.Items.AddRange(new object[] {
            "Color"});
            this.clpFont2.Location = new System.Drawing.Point(272, 78);
            this.clpFont2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clpFont2.Name = "clpFont2";
            this.clpFont2.Size = new System.Drawing.Size(97, 26);
            this.clpFont2.TabIndex = 119;
            this.clpFont2.SelectedColorChanged += new System.EventHandler(this.GUI2Settings);
            // 
            // icbFontGradient
            // 
            this.icbFontGradient.Color1 = System.Drawing.Color.Blue;
            this.icbFontGradient.Color2 = System.Drawing.Color.Honeydew;
            this.icbFontGradient.ColorSchemes = null;
            this.icbFontGradient.ComboStyle = MWLite.Symbology.Controls.ImageComboStyle.Common;
            this.icbFontGradient.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbFontGradient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbFontGradient.FormattingEnabled = true;
            this.icbFontGradient.Location = new System.Drawing.Point(165, 30);
            this.icbFontGradient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.icbFontGradient.Name = "icbFontGradient";
            this.icbFontGradient.OutlineColor = System.Drawing.Color.Black;
            this.icbFontGradient.Size = new System.Drawing.Size(204, 26);
            this.icbFontGradient.TabIndex = 120;
            this.icbFontGradient.SelectedIndexChanged += new System.EventHandler(this.GUI2Settings);
            // 
            // FontGradientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(416, 180);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FontGradientForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Font gradient";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private ImageCombo icbFontGradient;
        private Office2007ColorPicker clpFont2;
        private Office2007ColorPicker clpFont1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkUseGradient;
    }
}