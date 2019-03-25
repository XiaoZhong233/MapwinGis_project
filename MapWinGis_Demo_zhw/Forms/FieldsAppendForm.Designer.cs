namespace MapWinGis_Demo_zhw.Forms
{
    partial class AddFieldsForm
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
            this.fieldNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fieldTypeCmbox = new System.Windows.Forms.ComboBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.precisionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fieldNameTextBox
            // 
            this.fieldNameTextBox.Location = new System.Drawing.Point(96, 16);
            this.fieldNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fieldNameTextBox.Multiline = true;
            this.fieldNameTextBox.Name = "fieldNameTextBox";
            this.fieldNameTextBox.Size = new System.Drawing.Size(169, 22);
            this.fieldNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "字段名：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "字段类型：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldTypeCmbox
            // 
            this.fieldTypeCmbox.FormattingEnabled = true;
            this.fieldTypeCmbox.Location = new System.Drawing.Point(96, 47);
            this.fieldTypeCmbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fieldTypeCmbox.Name = "fieldTypeCmbox";
            this.fieldTypeCmbox.Size = new System.Drawing.Size(169, 23);
            this.fieldTypeCmbox.TabIndex = 3;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(125, 155);
            this.okBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(67, 32);
            this.okBtn.TabIndex = 4;
            this.okBtn.Text = "确定";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(198, 155);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(67, 32);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // precisionTextBox
            // 
            this.precisionTextBox.Location = new System.Drawing.Point(96, 76);
            this.precisionTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.precisionTextBox.Name = "precisionTextBox";
            this.precisionTextBox.Size = new System.Drawing.Size(169, 25);
            this.precisionTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "字段精度：";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(96, 105);
            this.widthTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(169, 25);
            this.widthTextBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "字段宽度：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.widthTextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.precisionTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cancelBtn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.okBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.fieldTypeCmbox);
            this.panel1.Controls.Add(this.fieldNameTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 236);
            this.panel1.TabIndex = 10;
            // 
            // AddFieldsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 236);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddFieldsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建字段";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox fieldNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox fieldTypeCmbox;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox precisionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
    }
}