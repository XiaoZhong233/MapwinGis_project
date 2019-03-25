namespace MapWinGis_Demo_zhw.Forms
{
    partial class QueryBuilderForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SQL1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.getValueBtn = new System.Windows.Forms.Button();
            this._Btn = new System.Windows.Forms.Button();
            this.asBtn = new System.Windows.Forms.Button();
            this.likeBtn = new System.Windows.Forms.Button();
            this.notBtn = new System.Windows.Forms.Button();
            this.orBtn = new System.Windows.Forms.Button();
            this.andBtn = new System.Windows.Forms.Button();
            this.leftBracketBtn = new System.Windows.Forms.Button();
            this.rightBracketBtn = new System.Windows.Forms.Button();
            this.unequalBtn = new System.Windows.Forms.Button();
            this.equalBtn = new System.Windows.Forms.Button();
            this.moreequalBtn = new System.Windows.Forms.Button();
            this.morethanBtn = new System.Windows.Forms.Button();
            this.lessBtn = new System.Windows.Forms.Button();
            this.lessequalBtn = new System.Windows.Forms.Button();
            this.ValueBox = new System.Windows.Forms.ListBox();
            this.fieldsBox = new System.Windows.Forms.ListBox();
            this.sqlBox = new System.Windows.Forms.TextBox();
            this.vetifyBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.testBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.vetifyInfo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.SQL1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.ValueBox);
            this.panel1.Controls.Add(this.fieldsBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 373);
            this.panel1.TabIndex = 0;
            // 
            // SQL1
            // 
            this.SQL1.AutoSize = true;
            this.SQL1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SQL1.Location = new System.Drawing.Point(15, 335);
            this.SQL1.Name = "SQL1";
            this.SQL1.Size = new System.Drawing.Size(199, 15);
            this.SQL1.TabIndex = 5;
            this.SQL1.Text = "SELECT * FROM XXX WHERE ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.getValueBtn);
            this.panel2.Controls.Add(this._Btn);
            this.panel2.Controls.Add(this.asBtn);
            this.panel2.Controls.Add(this.likeBtn);
            this.panel2.Controls.Add(this.notBtn);
            this.panel2.Controls.Add(this.orBtn);
            this.panel2.Controls.Add(this.andBtn);
            this.panel2.Controls.Add(this.leftBracketBtn);
            this.panel2.Controls.Add(this.rightBracketBtn);
            this.panel2.Controls.Add(this.unequalBtn);
            this.panel2.Controls.Add(this.equalBtn);
            this.panel2.Controls.Add(this.moreequalBtn);
            this.panel2.Controls.Add(this.morethanBtn);
            this.panel2.Controls.Add(this.lessBtn);
            this.panel2.Controls.Add(this.lessequalBtn);
            this.panel2.Location = new System.Drawing.Point(16, 252);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(493, 80);
            this.panel2.TabIndex = 4;
            // 
            // getValueBtn
            // 
            this.getValueBtn.Location = new System.Drawing.Point(387, 12);
            this.getValueBtn.Name = "getValueBtn";
            this.getValueBtn.Size = new System.Drawing.Size(85, 28);
            this.getValueBtn.TabIndex = 16;
            this.getValueBtn.Text = "获取值";
            this.getValueBtn.UseVisualStyleBackColor = true;
            // 
            // _Btn
            // 
            this._Btn.Location = new System.Drawing.Point(241, 44);
            this._Btn.Name = "_Btn";
            this._Btn.Size = new System.Drawing.Size(39, 23);
            this._Btn.TabIndex = 15;
            this._Btn.Text = "_";
            this._Btn.UseVisualStyleBackColor = true;
            // 
            // asBtn
            // 
            this.asBtn.Location = new System.Drawing.Point(196, 44);
            this.asBtn.Name = "asBtn";
            this.asBtn.Size = new System.Drawing.Size(39, 23);
            this.asBtn.TabIndex = 14;
            this.asBtn.Text = "%";
            this.asBtn.UseVisualStyleBackColor = true;
            // 
            // likeBtn
            // 
            this.likeBtn.Location = new System.Drawing.Point(140, 44);
            this.likeBtn.Name = "likeBtn";
            this.likeBtn.Size = new System.Drawing.Size(50, 23);
            this.likeBtn.TabIndex = 13;
            this.likeBtn.Text = "LIKE";
            this.likeBtn.UseVisualStyleBackColor = true;
            // 
            // notBtn
            // 
            this.notBtn.Location = new System.Drawing.Point(94, 44);
            this.notBtn.Name = "notBtn";
            this.notBtn.Size = new System.Drawing.Size(39, 23);
            this.notBtn.TabIndex = 12;
            this.notBtn.Text = "NOT";
            this.notBtn.UseVisualStyleBackColor = true;
            // 
            // orBtn
            // 
            this.orBtn.Location = new System.Drawing.Point(50, 44);
            this.orBtn.Name = "orBtn";
            this.orBtn.Size = new System.Drawing.Size(39, 23);
            this.orBtn.TabIndex = 11;
            this.orBtn.Text = "OR";
            this.orBtn.UseVisualStyleBackColor = true;
            // 
            // andBtn
            // 
            this.andBtn.Location = new System.Drawing.Point(3, 44);
            this.andBtn.Name = "andBtn";
            this.andBtn.Size = new System.Drawing.Size(41, 23);
            this.andBtn.TabIndex = 10;
            this.andBtn.Text = "AND";
            this.andBtn.UseVisualStyleBackColor = true;
            // 
            // leftBracketBtn
            // 
            this.leftBracketBtn.Location = new System.Drawing.Point(324, 15);
            this.leftBracketBtn.Name = "leftBracketBtn";
            this.leftBracketBtn.Size = new System.Drawing.Size(27, 23);
            this.leftBracketBtn.TabIndex = 9;
            this.leftBracketBtn.Text = ")";
            this.leftBracketBtn.UseVisualStyleBackColor = true;
            // 
            // rightBracketBtn
            // 
            this.rightBracketBtn.Location = new System.Drawing.Point(292, 15);
            this.rightBracketBtn.Name = "rightBracketBtn";
            this.rightBracketBtn.Size = new System.Drawing.Size(26, 23);
            this.rightBracketBtn.TabIndex = 8;
            this.rightBracketBtn.Text = "(";
            this.rightBracketBtn.UseVisualStyleBackColor = true;
            // 
            // unequalBtn
            // 
            this.unequalBtn.Location = new System.Drawing.Point(232, 15);
            this.unequalBtn.Name = "unequalBtn";
            this.unequalBtn.Size = new System.Drawing.Size(40, 23);
            this.unequalBtn.TabIndex = 7;
            this.unequalBtn.Text = "<>";
            this.unequalBtn.UseVisualStyleBackColor = true;
            // 
            // equalBtn
            // 
            this.equalBtn.Location = new System.Drawing.Point(186, 15);
            this.equalBtn.Name = "equalBtn";
            this.equalBtn.Size = new System.Drawing.Size(40, 23);
            this.equalBtn.TabIndex = 6;
            this.equalBtn.Text = "=";
            this.equalBtn.UseVisualStyleBackColor = true;
            // 
            // moreequalBtn
            // 
            this.moreequalBtn.Location = new System.Drawing.Point(140, 15);
            this.moreequalBtn.Name = "moreequalBtn";
            this.moreequalBtn.Size = new System.Drawing.Size(40, 23);
            this.moreequalBtn.TabIndex = 5;
            this.moreequalBtn.Text = ">=";
            this.moreequalBtn.UseVisualStyleBackColor = true;
            // 
            // morethanBtn
            // 
            this.morethanBtn.Location = new System.Drawing.Point(94, 15);
            this.morethanBtn.Name = "morethanBtn";
            this.morethanBtn.Size = new System.Drawing.Size(40, 23);
            this.morethanBtn.TabIndex = 4;
            this.morethanBtn.Text = ">";
            this.morethanBtn.UseVisualStyleBackColor = true;
            // 
            // lessBtn
            // 
            this.lessBtn.Location = new System.Drawing.Point(3, 15);
            this.lessBtn.Name = "lessBtn";
            this.lessBtn.Size = new System.Drawing.Size(41, 23);
            this.lessBtn.TabIndex = 2;
            this.lessBtn.Text = "<";
            this.lessBtn.UseVisualStyleBackColor = true;
            // 
            // lessequalBtn
            // 
            this.lessequalBtn.Location = new System.Drawing.Point(50, 15);
            this.lessequalBtn.Name = "lessequalBtn";
            this.lessequalBtn.Size = new System.Drawing.Size(40, 23);
            this.lessequalBtn.TabIndex = 3;
            this.lessequalBtn.Text = "<=";
            this.lessequalBtn.UseVisualStyleBackColor = true;
            // 
            // ValueBox
            // 
            this.ValueBox.FormattingEnabled = true;
            this.ValueBox.ItemHeight = 15;
            this.ValueBox.Location = new System.Drawing.Point(223, 16);
            this.ValueBox.Name = "ValueBox";
            this.ValueBox.Size = new System.Drawing.Size(286, 229);
            this.ValueBox.TabIndex = 1;
            // 
            // fieldsBox
            // 
            this.fieldsBox.FormattingEnabled = true;
            this.fieldsBox.ItemHeight = 15;
            this.fieldsBox.Location = new System.Drawing.Point(16, 16);
            this.fieldsBox.Name = "fieldsBox";
            this.fieldsBox.Size = new System.Drawing.Size(190, 229);
            this.fieldsBox.TabIndex = 0;
            // 
            // sqlBox
            // 
            this.sqlBox.Location = new System.Drawing.Point(12, 392);
            this.sqlBox.Multiline = true;
            this.sqlBox.Name = "sqlBox";
            this.sqlBox.Size = new System.Drawing.Size(421, 107);
            this.sqlBox.TabIndex = 1;
            // 
            // vetifyBtn
            // 
            this.vetifyBtn.Location = new System.Drawing.Point(447, 397);
            this.vetifyBtn.Name = "vetifyBtn";
            this.vetifyBtn.Size = new System.Drawing.Size(74, 30);
            this.vetifyBtn.TabIndex = 2;
            this.vetifyBtn.Text = "验证";
            this.vetifyBtn.UseVisualStyleBackColor = true;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(447, 469);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(74, 30);
            this.clearBtn.TabIndex = 3;
            this.clearBtn.Text = "清除";
            this.clearBtn.UseVisualStyleBackColor = true;
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(447, 433);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(74, 30);
            this.testBtn.TabIndex = 4;
            this.testBtn.Text = "测试";
            this.testBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(336, 518);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(74, 30);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "确定";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(444, 518);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(74, 30);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // vetifyInfo
            // 
            this.vetifyInfo.AutoSize = true;
            this.vetifyInfo.Font = new System.Drawing.Font("宋体", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.vetifyInfo.Location = new System.Drawing.Point(12, 502);
            this.vetifyInfo.Name = "vetifyInfo";
            this.vetifyInfo.Size = new System.Drawing.Size(47, 12);
            this.vetifyInfo.TabIndex = 7;
            this.vetifyInfo.Text = "label3";
            // 
            // QueryBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 560);
            this.Controls.Add(this.vetifyInfo);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.vetifyBtn);
            this.Controls.Add(this.sqlBox);
            this.Controls.Add(this.panel1);
            this.Name = "QueryBuilderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QueryBuilderForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


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
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.CheckBox chkShowDynamically;
        private System.Windows.Forms.Button btnShowValues;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkShowValues;
     
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvField;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvValues;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnValue;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SQL1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button getValueBtn;
        private System.Windows.Forms.Button _Btn;
        private System.Windows.Forms.Button asBtn;
        private System.Windows.Forms.Button likeBtn;
        private System.Windows.Forms.Button notBtn;
        private System.Windows.Forms.Button orBtn;
        private System.Windows.Forms.Button andBtn;
        private System.Windows.Forms.Button leftBracketBtn;
        private System.Windows.Forms.Button rightBracketBtn;
        private System.Windows.Forms.Button unequalBtn;
        private System.Windows.Forms.Button equalBtn;
        private System.Windows.Forms.Button moreequalBtn;
        private System.Windows.Forms.Button morethanBtn;
        private System.Windows.Forms.Button lessBtn;
        private System.Windows.Forms.Button lessequalBtn;
        private System.Windows.Forms.ListBox ValueBox;
        private System.Windows.Forms.ListBox fieldsBox;
        private System.Windows.Forms.TextBox sqlBox;
        private System.Windows.Forms.Button vetifyBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label vetifyInfo;
    }
}