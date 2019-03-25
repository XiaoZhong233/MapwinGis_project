﻿namespace MWLite.Symbology.Forms.Utilities
{
    partial class frmQueryBuilder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvField = new System.Windows.Forms.DataGridView();
            this.cmnIcon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button0 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvValues = new System.Windows.Forms.DataGridView();
            this.cmnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.chkShowDynamically = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnShowValues = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkShowValues = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValues)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvField
            // 
            this.dgvField.AllowUserToAddRows = false;
            this.dgvField.AllowUserToDeleteRows = false;
            this.dgvField.AllowUserToResizeColumns = false;
            this.dgvField.AllowUserToResizeRows = false;
            this.dgvField.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvField.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvField.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvField.ColumnHeadersVisible = false;
            this.dgvField.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnIcon,
            this.cmnName});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvField.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvField.Location = new System.Drawing.Point(4, 21);
            this.dgvField.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvField.MultiSelect = false;
            this.dgvField.Name = "dgvField";
            this.dgvField.ReadOnly = true;
            this.dgvField.RowHeadersVisible = false;
            this.dgvField.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvField.Size = new System.Drawing.Size(277, 204);
            this.dgvField.TabIndex = 1;
            this.dgvField.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvField_CellClick);
            this.dgvField.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvField_CellDoubleClick);
            // 
            // cmnIcon
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmnIcon.DefaultCellStyle = dataGridViewCellStyle1;
            this.cmnIcon.HeaderText = "Icon";
            this.cmnIcon.Name = "cmnIcon";
            this.cmnIcon.ReadOnly = true;
            this.cmnIcon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmnIcon.Width = 5;
            // 
            // cmnName
            // 
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.cmnName.DefaultCellStyle = dataGridViewCellStyle2;
            this.cmnName.HeaderText = "Name";
            this.cmnName.Name = "cmnName";
            this.cmnName.ReadOnly = true;
            this.cmnName.Width = 5;
            // 
            // button0
            // 
            this.button0.Location = new System.Drawing.Point(163, 137);
            this.button0.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(45, 29);
            this.button0.TabIndex = 2;
            this.button0.Tag = "";
            this.button0.Text = ">";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 137);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 29);
            this.button1.TabIndex = 3;
            this.button1.Tag = "";
            this.button1.Text = ">=";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button0_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(67, 137);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 29);
            this.button2.TabIndex = 4;
            this.button2.Tag = "";
            this.button2.Text = "<=";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button0_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(19, 137);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 29);
            this.button3.TabIndex = 5;
            this.button3.Tag = "";
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button0_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(211, 137);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(45, 29);
            this.button4.TabIndex = 6;
            this.button4.Tag = "";
            this.button4.Text = "=";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button0_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(259, 137);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(45, 29);
            this.button5.TabIndex = 7;
            this.button5.Tag = "";
            this.button5.Text = "<>";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button0_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(324, 137);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(52, 29);
            this.button6.TabIndex = 8;
            this.button6.Tag = "";
            this.button6.Text = "AND";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button0_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(384, 137);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 29);
            this.button7.TabIndex = 9;
            this.button7.Tag = "";
            this.button7.Text = "OR";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button0_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(439, 137);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(60, 29);
            this.button8.TabIndex = 10;
            this.button8.Tag = "";
            this.button8.Text = "NOT";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button0_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(520, 137);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(24, 29);
            this.button9.TabIndex = 11;
            this.button9.Tag = "";
            this.button9.Text = "(";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button0_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(552, 137);
            this.button10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(25, 29);
            this.button10.TabIndex = 12;
            this.button10.Tag = "";
            this.button10.Text = ")";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button0_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(4, 21);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(617, 93);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(652, 24);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(127, 30);
            this.btnTest.TabIndex = 20;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(653, 405);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 30);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgvValues
            // 
            this.dgvValues.AllowUserToAddRows = false;
            this.dgvValues.AllowUserToDeleteRows = false;
            this.dgvValues.AllowUserToResizeColumns = false;
            this.dgvValues.AllowUserToResizeRows = false;
            this.dgvValues.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvValues.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvValues.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValues.ColumnHeadersVisible = false;
            this.dgvValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnCount,
            this.cmnValue});
            this.dgvValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvValues.Location = new System.Drawing.Point(4, 21);
            this.dgvValues.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvValues.MultiSelect = false;
            this.dgvValues.Name = "dgvValues";
            this.dgvValues.ReadOnly = true;
            this.dgvValues.RowHeadersVisible = false;
            this.dgvValues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvValues.Size = new System.Drawing.Size(324, 204);
            this.dgvValues.TabIndex = 24;
            this.dgvValues.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvValues_CellDoubleClick);
            this.dgvValues.SelectionChanged += new System.EventHandler(this.dgvValues_SelectionChanged);
            // 
            // cmnCount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.cmnCount.DefaultCellStyle = dataGridViewCellStyle4;
            this.cmnCount.HeaderText = "Count";
            this.cmnCount.Name = "cmnCount";
            this.cmnCount.ReadOnly = true;
            this.cmnCount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmnCount.Width = 35;
            // 
            // cmnValue
            // 
            this.cmnValue.HeaderText = "Value";
            this.cmnValue.Name = "cmnValue";
            this.cmnValue.ReadOnly = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(517, 405);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(127, 30);
            this.btnOk.TabIndex = 25;
            this.btnOk.Text = "确认";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResult.Location = new System.Drawing.Point(19, 413);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(491, 22);
            this.lblResult.TabIndex = 26;
            this.lblResult.Text = "Results";
            // 
            // chkShowDynamically
            // 
            this.chkShowDynamically.AutoSize = true;
            this.chkShowDynamically.Location = new System.Drawing.Point(652, 270);
            this.chkShowDynamically.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkShowDynamically.Name = "chkShowDynamically";
            this.chkShowDynamically.Size = new System.Drawing.Size(89, 19);
            this.chkShowDynamically.TabIndex = 28;
            this.chkShowDynamically.Text = "更新选择";
            this.chkShowDynamically.UseVisualStyleBackColor = true;
            this.chkShowDynamically.CheckedChanged += new System.EventHandler(this.chkShowDynamically_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvField);
            this.groupBox1.Location = new System.Drawing.Point(19, 170);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(285, 228);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "字段";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvValues);
            this.groupBox2.Location = new System.Drawing.Point(312, 170);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(332, 228);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "值域";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(19, 14);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(625, 117);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "表达式";
            // 
            // btnShowValues
            // 
            this.btnShowValues.Location = new System.Drawing.Point(651, 188);
            this.btnShowValues.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnShowValues.Name = "btnShowValues";
            this.btnShowValues.Size = new System.Drawing.Size(127, 27);
            this.btnShowValues.TabIndex = 32;
            this.btnShowValues.Text = "获取值";
            this.btnShowValues.UseVisualStyleBackColor = true;
            this.btnShowValues.Click += new System.EventHandler(this.btnShowValues_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(652, 61);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(127, 30);
            this.btnClear.TabIndex = 33;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkShowValues
            // 
            this.chkShowValues.AutoSize = true;
            this.chkShowValues.Location = new System.Drawing.Point(652, 233);
            this.chkShowValues.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkShowValues.Name = "chkShowValues";
            this.chkShowValues.Size = new System.Drawing.Size(74, 19);
            this.chkShowValues.TabIndex = 34;
            this.chkShowValues.Text = "显示值";
            this.chkShowValues.UseVisualStyleBackColor = true;
            this.chkShowValues.CheckedChanged += new System.EventHandler(this.chkShowValues_CheckedChanged);
            // 
            // frmQueryBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(797, 444);
            this.Controls.Add(this.chkShowValues);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnShowValues);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.chkShowDynamically);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQueryBuilder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询构建";
            ((System.ComponentModel.ISupportInitialize)(this.dgvField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValues)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvField;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvValues;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.CheckBox chkShowDynamically;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnShowValues;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkShowValues;
    }
}