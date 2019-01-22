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
            this.SuspendLayout();
            // 
            // fieldNameTextBox
            // 
            this.fieldNameTextBox.Location = new System.Drawing.Point(105, 12);
            this.fieldNameTextBox.Multiline = true;
            this.fieldNameTextBox.Name = "fieldNameTextBox";
            this.fieldNameTextBox.Size = new System.Drawing.Size(190, 26);
            this.fieldNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "字段名：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "字段类型：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldTypeCmbox
            // 
            this.fieldTypeCmbox.FormattingEnabled = true;
            this.fieldTypeCmbox.Location = new System.Drawing.Point(105, 57);
            this.fieldTypeCmbox.Name = "fieldTypeCmbox";
            this.fieldTypeCmbox.Size = new System.Drawing.Size(190, 26);
            this.fieldTypeCmbox.TabIndex = 3;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(123, 195);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 38);
            this.okBtn.TabIndex = 4;
            this.okBtn.Text = "确定";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(220, 195);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 38);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // precisionTextBox
            // 
            this.precisionTextBox.Location = new System.Drawing.Point(195, 97);
            this.precisionTextBox.Name = "precisionTextBox";
            this.precisionTextBox.Size = new System.Drawing.Size(100, 28);
            this.precisionTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(89, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "字段精度：";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(195, 131);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(100, 28);
            this.widthTextBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(90, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "字段宽度：";
            // 
            // AddFieldsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 245);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.precisionTextBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.fieldTypeCmbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fieldNameTextBox);
            this.Name = "AddFieldsForm";
            this.Text = "新建字段";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}