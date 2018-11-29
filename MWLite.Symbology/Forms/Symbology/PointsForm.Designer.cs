using MWLite.Symbology.Controls;
using MWLite.Symbology.Controls.ColorPicker;
using MWLite.Symbology.Controls.ListControls;

namespace MWLite.Symbology.Forms.Symbology
{
    partial class PointsForm
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.udSize = new MWLite.Symbology.Controls.NumericUpDownExt(this.components);
            this.udRotation = new MWLite.Symbology.Controls.NumericUpDownExt(this.components);
            this.clpFillColor = new MWLite.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSymbol = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.transparencyControl1 = new MWLite.Symbology.Controls.TransparencyControl();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.udPointNumSides = new MWLite.Symbology.Controls.NumericUpDownExt(this.components);
            this.udSideRatio = new MWLite.Symbology.Controls.NumericUpDownExt(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.symbolControl1 = new MWLite.Symbology.Controls.ListControls.SymbolControl();
            this.icbPointShape = new MWLite.Symbology.Controls.ImageCombo();
            this.label17 = new System.Windows.Forms.Label();
            this.tabCharacter = new System.Windows.Forms.TabPage();
            this.chkShowAllFonts = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.cboFontName = new System.Windows.Forms.ComboBox();
            this.characterControl1 = new MWLite.Symbology.Controls.ListControls.CharacterControl();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblNoOptions = new System.Windows.Forms.Label();
            this.chkFillVisible = new System.Windows.Forms.CheckBox();
            this.pnlFillHatch = new System.Windows.Forms.Panel();
            this.icbHatchStyle = new MWLite.Symbology.Controls.ImageCombo();
            this.label6 = new System.Windows.Forms.Label();
            this.chkFillBgTransparent = new System.Windows.Forms.CheckBox();
            this.clpHatchBack = new MWLite.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cboFillType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkOutlineVisible = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.icbLineWidth = new MWLite.Symbology.Controls.ImageCombo();
            this.icbLineType = new MWLite.Symbology.Controls.ImageCombo();
            this.clpOutline = new MWLite.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pctPreview = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlFillGradient = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.udGradientRotation = new MWLite.Symbology.Controls.NumericUpDownExt(this.components);
            this.label26 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.clpGradient2 = new MWLite.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.cboGradientType = new System.Windows.Forms.ComboBox();
            this.pnlFillPicture = new System.Windows.Forms.Panel();
            this.btnChooseTexture = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.cboIconCollection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkScaleIcons = new System.Windows.Forms.CheckBox();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.iconControl1 = new MWLite.Symbology.Controls.ListControls.IconControl();
            this.tabIcon = new System.Windows.Forms.TabPage();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRotation)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabSymbol.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udPointNumSides)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSideRatio)).BeginInit();
            this.tabCharacter.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlFillHatch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPreview)).BeginInit();
            this.pnlFillGradient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udGradientRotation)).BeginInit();
            this.pnlFillPicture.SuspendLayout();
            this.tabIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel1);
            this.groupBox4.Location = new System.Drawing.Point(12, 202);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Size = new System.Drawing.Size(235, 204);
            this.groupBox4.TabIndex = 41;
            this.groupBox4.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.udSize);
            this.panel1.Controls.Add(this.udRotation);
            this.panel1.Controls.Add(this.clpFillColor);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Controls.Add(this.label33);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 21);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 180);
            this.panel1.TabIndex = 35;
            // 
            // udSize
            // 
            this.udSize.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.udSize.Location = new System.Drawing.Point(141, 25);
            this.udSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.udSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.udSize.Name = "udSize";
            this.udSize.Size = new System.Drawing.Size(65, 25);
            this.udSize.TabIndex = 15;
            this.udSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // udRotation
            // 
            this.udRotation.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udRotation.Location = new System.Drawing.Point(141, 77);
            this.udRotation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.udRotation.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.udRotation.Name = "udRotation";
            this.udRotation.Size = new System.Drawing.Size(65, 25);
            this.udRotation.TabIndex = 25;
            this.udRotation.ValueChanged += new System.EventHandler(this.Gui2Options);
            // 
            // clpFillColor
            // 
            this.clpFillColor.Color = System.Drawing.Color.Black;
            this.clpFillColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpFillColor.DropDownHeight = 1;
            this.clpFillColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpFillColor.FormattingEnabled = true;
            this.clpFillColor.IntegralHeight = false;
            this.clpFillColor.Items.AddRange(new object[] {
            "Color"});
            this.clpFillColor.Location = new System.Drawing.Point(128, 127);
            this.clpFillColor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clpFillColor.Name = "clpFillColor";
            this.clpFillColor.Size = new System.Drawing.Size(77, 26);
            this.clpFillColor.TabIndex = 86;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(25, 130);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(37, 15);
            this.label34.TabIndex = 29;
            this.label34.Text = "颜色";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(24, 80);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(37, 15);
            this.label33.TabIndex = 26;
            this.label33.Text = "角度";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(25, 28);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(37, 15);
            this.label32.TabIndex = 16;
            this.label32.Text = "大小";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSymbol);
            this.tabControl1.Controls.Add(this.tabCharacter);
            this.tabControl1.Controls.Add(this.tabIcon);
            this.tabControl1.Controls.Add(this.tabOptions);
            this.tabControl1.Location = new System.Drawing.Point(255, 14);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(564, 392);
            this.tabControl1.TabIndex = 37;
            // 
            // tabSymbol
            // 
            this.tabSymbol.Controls.Add(this.label3);
            this.tabSymbol.Controls.Add(this.transparencyControl1);
            this.tabSymbol.Controls.Add(this.groupBox5);
            this.tabSymbol.Controls.Add(this.symbolControl1);
            this.tabSymbol.Controls.Add(this.icbPointShape);
            this.tabSymbol.Controls.Add(this.label17);
            this.tabSymbol.Location = new System.Drawing.Point(4, 25);
            this.tabSymbol.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabSymbol.Name = "tabSymbol";
            this.tabSymbol.Size = new System.Drawing.Size(556, 363);
            this.tabSymbol.TabIndex = 2;
            this.tabSymbol.Text = "点";
            this.tabSymbol.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 277);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 137;
            this.label3.Text = "透明度";
            // 
            // transparencyControl1
            // 
            this.transparencyControl1.BandColor = System.Drawing.Color.Empty;
            this.transparencyControl1.Location = new System.Drawing.Point(155, 277);
            this.transparencyControl1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.transparencyControl1.MaximumSize = new System.Drawing.Size(1365, 37);
            this.transparencyControl1.MinimumSize = new System.Drawing.Size(171, 37);
            this.transparencyControl1.Name = "transparencyControl1";
            this.transparencyControl1.Size = new System.Drawing.Size(377, 37);
            this.transparencyControl1.TabIndex = 136;
            this.transparencyControl1.Value = ((byte)(255));
            this.transparencyControl1.ValueChanged += new MWLite.Symbology.Controls.TransparencyControl.ValueChangedDeleg(this.transparencyControl1_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.udPointNumSides);
            this.groupBox5.Controls.Add(this.udSideRatio);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Location = new System.Drawing.Point(13, 77);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Size = new System.Drawing.Size(519, 78);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            // 
            // udPointNumSides
            // 
            this.udPointNumSides.Location = new System.Drawing.Point(141, 29);
            this.udPointNumSides.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.udPointNumSides.Name = "udPointNumSides";
            this.udPointNumSides.Size = new System.Drawing.Size(75, 25);
            this.udPointNumSides.TabIndex = 24;
            // 
            // udSideRatio
            // 
            this.udSideRatio.Location = new System.Drawing.Point(380, 29);
            this.udSideRatio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.udSideRatio.Name = "udSideRatio";
            this.udSideRatio.Size = new System.Drawing.Size(77, 25);
            this.udSideRatio.TabIndex = 23;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(292, 31);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 15);
            this.label19.TabIndex = 2;
            this.label19.Text = "边比例";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 31);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 15);
            this.label18.TabIndex = 1;
            this.label18.Text = "边数";
            // 
            // symbolControl1
            // 
            this.symbolControl1.BackColor = System.Drawing.Color.Transparent;
            this.symbolControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.symbolControl1.CellHeight = 24;
            this.symbolControl1.CellWidth = 24;
            this.symbolControl1.Font = new System.Drawing.Font("Arial", 25.6F);
            this.symbolControl1.GridColor = System.Drawing.Color.Black;
            this.symbolControl1.GridVisible = false;
            this.symbolControl1.ItemCount = 17;
            this.symbolControl1.Location = new System.Drawing.Point(13, 170);
            this.symbolControl1.Margin = new System.Windows.Forms.Padding(13, 10, 13, 10);
            this.symbolControl1.Name = "symbolControl1";
            this.symbolControl1.SelectedIndex = -1;
            this.symbolControl1.Size = new System.Drawing.Size(518, 83);
            this.symbolControl1.TabIndex = 26;
            // 
            // icbPointShape
            // 
            this.icbPointShape.Color1 = System.Drawing.Color.Orange;
            this.icbPointShape.Color2 = System.Drawing.Color.Honeydew;
            this.icbPointShape.ColorSchemes = null;
            this.icbPointShape.ComboStyle = MWLite.Symbology.Controls.ImageComboStyle.Common;
            this.icbPointShape.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbPointShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbPointShape.FormattingEnabled = true;
            this.icbPointShape.Location = new System.Drawing.Point(155, 33);
            this.icbPointShape.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.icbPointShape.Name = "icbPointShape";
            this.icbPointShape.OutlineColor = System.Drawing.Color.DimGray;
            this.icbPointShape.Size = new System.Drawing.Size(164, 26);
            this.icbPointShape.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(36, 37);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 15);
            this.label17.TabIndex = 0;
            this.label17.Text = "点类型";
            // 
            // tabCharacter
            // 
            this.tabCharacter.Controls.Add(this.chkShowAllFonts);
            this.tabCharacter.Controls.Add(this.label35);
            this.tabCharacter.Controls.Add(this.cboFontName);
            this.tabCharacter.Controls.Add(this.characterControl1);
            this.tabCharacter.Location = new System.Drawing.Point(4, 25);
            this.tabCharacter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabCharacter.Name = "tabCharacter";
            this.tabCharacter.Size = new System.Drawing.Size(556, 363);
            this.tabCharacter.TabIndex = 3;
            this.tabCharacter.Text = "字符";
            this.tabCharacter.UseVisualStyleBackColor = true;
            // 
            // chkShowAllFonts
            // 
            this.chkShowAllFonts.AutoSize = true;
            this.chkShowAllFonts.Location = new System.Drawing.Point(393, 31);
            this.chkShowAllFonts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkShowAllFonts.Name = "chkShowAllFonts";
            this.chkShowAllFonts.Size = new System.Drawing.Size(89, 19);
            this.chkShowAllFonts.TabIndex = 70;
            this.chkShowAllFonts.Text = "显示全部";
            this.chkShowAllFonts.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(33, 32);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(0, 15);
            this.label35.TabIndex = 69;
            // 
            // cboFontName
            // 
            this.cboFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFontName.FormattingEnabled = true;
            this.cboFontName.Location = new System.Drawing.Point(90, 29);
            this.cboFontName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboFontName.Name = "cboFontName";
            this.cboFontName.Size = new System.Drawing.Size(279, 23);
            this.cboFontName.TabIndex = 68;
            // 
            // characterControl1
            // 
            this.characterControl1.BackColor = System.Drawing.Color.Transparent;
            this.characterControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.characterControl1.CellHeight = 32;
            this.characterControl1.CellWidth = 32;
            this.characterControl1.Font = new System.Drawing.Font("Webdings", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.characterControl1.ForeColor = System.Drawing.Color.Black;
            this.characterControl1.GridColor = System.Drawing.Color.DimGray;
            this.characterControl1.GridVisible = true;
            this.characterControl1.ItemCount = 224;
            this.characterControl1.Location = new System.Drawing.Point(23, 66);
            this.characterControl1.Margin = new System.Windows.Forms.Padding(23, 9, 23, 9);
            this.characterControl1.Name = "characterControl1";
            this.characterControl1.SelectedCharacterCode = ((byte)(0));
            this.characterControl1.SelectedIndex = -1;
            this.characterControl1.Size = new System.Drawing.Size(517, 280);
            this.characterControl1.TabIndex = 0;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.groupBox3);
            this.tabOptions.Controls.Add(this.groupBox2);
            this.tabOptions.Location = new System.Drawing.Point(4, 25);
            this.tabOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabOptions.Size = new System.Drawing.Size(556, 363);
            this.tabOptions.TabIndex = 0;
            this.tabOptions.Text = "填充选项";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblNoOptions);
            this.groupBox3.Controls.Add(this.chkFillVisible);
            this.groupBox3.Controls.Add(this.pnlFillHatch);
            this.groupBox3.Controls.Add(this.cboFillType);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(16, 7);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(515, 170);
            this.groupBox3.TabIndex = 133;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "填充";
            // 
            // lblNoOptions
            // 
            this.lblNoOptions.AutoSize = true;
            this.lblNoOptions.Location = new System.Drawing.Point(99, 96);
            this.lblNoOptions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoOptions.Name = "lblNoOptions";
            this.lblNoOptions.Size = new System.Drawing.Size(112, 15);
            this.lblNoOptions.TabIndex = 86;
            this.lblNoOptions.Text = "没有可用的设置";
            this.lblNoOptions.Visible = false;
            // 
            // chkFillVisible
            // 
            this.chkFillVisible.AutoSize = true;
            this.chkFillVisible.Location = new System.Drawing.Point(356, 37);
            this.chkFillVisible.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkFillVisible.Name = "chkFillVisible";
            this.chkFillVisible.Size = new System.Drawing.Size(89, 19);
            this.chkFillVisible.TabIndex = 85;
            this.chkFillVisible.Text = "是否填充";
            this.chkFillVisible.UseVisualStyleBackColor = true;
            // 
            // pnlFillHatch
            // 
            this.pnlFillHatch.Controls.Add(this.icbHatchStyle);
            this.pnlFillHatch.Controls.Add(this.label6);
            this.pnlFillHatch.Controls.Add(this.chkFillBgTransparent);
            this.pnlFillHatch.Controls.Add(this.clpHatchBack);
            this.pnlFillHatch.Controls.Add(this.label4);
            this.pnlFillHatch.Location = new System.Drawing.Point(8, 63);
            this.pnlFillHatch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlFillHatch.Name = "pnlFillHatch";
            this.pnlFillHatch.Size = new System.Drawing.Size(483, 98);
            this.pnlFillHatch.TabIndex = 43;
            // 
            // icbHatchStyle
            // 
            this.icbHatchStyle.Color1 = System.Drawing.Color.Blue;
            this.icbHatchStyle.Color2 = System.Drawing.Color.Honeydew;
            this.icbHatchStyle.ColorSchemes = null;
            this.icbHatchStyle.ComboStyle = MWLite.Symbology.Controls.ImageComboStyle.Common;
            this.icbHatchStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbHatchStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbHatchStyle.FormattingEnabled = true;
            this.icbHatchStyle.Location = new System.Drawing.Point(113, 13);
            this.icbHatchStyle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.icbHatchStyle.Name = "icbHatchStyle";
            this.icbHatchStyle.OutlineColor = System.Drawing.Color.Black;
            this.icbHatchStyle.Size = new System.Drawing.Size(261, 26);
            this.icbHatchStyle.TabIndex = 90;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 82;
            this.label6.Text = "类型";
            // 
            // chkFillBgTransparent
            // 
            this.chkFillBgTransparent.AutoSize = true;
            this.chkFillBgTransparent.Location = new System.Drawing.Point(231, 61);
            this.chkFillBgTransparent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkFillBgTransparent.Name = "chkFillBgTransparent";
            this.chkFillBgTransparent.Size = new System.Drawing.Size(59, 19);
            this.chkFillBgTransparent.TabIndex = 89;
            this.chkFillBgTransparent.Text = "透明";
            this.chkFillBgTransparent.UseVisualStyleBackColor = true;
            // 
            // clpHatchBack
            // 
            this.clpHatchBack.Color = System.Drawing.Color.Black;
            this.clpHatchBack.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpHatchBack.DropDownHeight = 1;
            this.clpHatchBack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpHatchBack.FormattingEnabled = true;
            this.clpHatchBack.IntegralHeight = false;
            this.clpHatchBack.Items.AddRange(new object[] {
            "Color"});
            this.clpHatchBack.Location = new System.Drawing.Point(113, 59);
            this.clpHatchBack.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clpHatchBack.Name = "clpHatchBack";
            this.clpHatchBack.Size = new System.Drawing.Size(97, 26);
            this.clpHatchBack.TabIndex = 87;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 84;
            this.label4.Text = "背景";
            // 
            // cboFillType
            // 
            this.cboFillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFillType.FormattingEnabled = true;
            this.cboFillType.Location = new System.Drawing.Point(121, 32);
            this.cboFillType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboFillType.Name = "cboFillType";
            this.cboFillType.Size = new System.Drawing.Size(180, 23);
            this.cboFillType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "填充类型";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkOutlineVisible);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.icbLineWidth);
            this.groupBox2.Controls.Add(this.icbLineType);
            this.groupBox2.Controls.Add(this.clpOutline);
            this.groupBox2.Location = new System.Drawing.Point(16, 183);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(515, 162);
            this.groupBox2.TabIndex = 132;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "边框";
            // 
            // chkOutlineVisible
            // 
            this.chkOutlineVisible.AutoSize = true;
            this.chkOutlineVisible.Location = new System.Drawing.Point(300, 36);
            this.chkOutlineVisible.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkOutlineVisible.Name = "chkOutlineVisible";
            this.chkOutlineVisible.Size = new System.Drawing.Size(89, 19);
            this.chkOutlineVisible.TabIndex = 131;
            this.chkOutlineVisible.Text = "显示边框";
            this.chkOutlineVisible.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(32, 37);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 15);
            this.label21.TabIndex = 130;
            this.label21.Text = "颜色";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(296, 83);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 15);
            this.label22.TabIndex = 126;
            this.label22.Text = "宽度";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(33, 81);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(37, 15);
            this.label23.TabIndex = 125;
            this.label23.Text = "样式";
            // 
            // icbLineWidth
            // 
            this.icbLineWidth.Color1 = System.Drawing.Color.Blue;
            this.icbLineWidth.Color2 = System.Drawing.Color.Honeydew;
            this.icbLineWidth.ColorSchemes = null;
            this.icbLineWidth.ComboStyle = MWLite.Symbology.Controls.ImageComboStyle.Common;
            this.icbLineWidth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbLineWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbLineWidth.FormattingEnabled = true;
            this.icbLineWidth.Location = new System.Drawing.Point(369, 81);
            this.icbLineWidth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.icbLineWidth.Name = "icbLineWidth";
            this.icbLineWidth.OutlineColor = System.Drawing.Color.Black;
            this.icbLineWidth.Size = new System.Drawing.Size(97, 26);
            this.icbLineWidth.TabIndex = 129;
            // 
            // icbLineType
            // 
            this.icbLineType.Color1 = System.Drawing.Color.Blue;
            this.icbLineType.Color2 = System.Drawing.Color.Honeydew;
            this.icbLineType.ColorSchemes = null;
            this.icbLineType.ComboStyle = MWLite.Symbology.Controls.ImageComboStyle.Common;
            this.icbLineType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbLineType.FormattingEnabled = true;
            this.icbLineType.Location = new System.Drawing.Point(87, 77);
            this.icbLineType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.icbLineType.Name = "icbLineType";
            this.icbLineType.OutlineColor = System.Drawing.Color.Black;
            this.icbLineType.Size = new System.Drawing.Size(97, 26);
            this.icbLineType.TabIndex = 128;
            // 
            // clpOutline
            // 
            this.clpOutline.Color = System.Drawing.Color.Black;
            this.clpOutline.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpOutline.DropDownHeight = 1;
            this.clpOutline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpOutline.FormattingEnabled = true;
            this.clpOutline.IntegralHeight = false;
            this.clpOutline.Items.AddRange(new object[] {
            "Color"});
            this.clpOutline.Location = new System.Drawing.Point(87, 33);
            this.clpOutline.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clpOutline.Name = "clpOutline";
            this.clpOutline.Size = new System.Drawing.Size(97, 26);
            this.clpOutline.TabIndex = 127;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pctPreview);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(235, 189);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预览";
            // 
            // pctPreview
            // 
            this.pctPreview.BackColor = System.Drawing.Color.Transparent;
            this.pctPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctPreview.Location = new System.Drawing.Point(4, 21);
            this.pctPreview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pctPreview.Name = "pctPreview";
            this.pctPreview.Size = new System.Drawing.Size(227, 165);
            this.pctPreview.TabIndex = 0;
            this.pctPreview.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(687, 408);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 30);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(552, 408);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(127, 30);
            this.btnOk.TabIndex = 38;
            this.btnOk.Text = "确认";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlFillGradient
            // 
            this.pnlFillGradient.Controls.Add(this.label5);
            this.pnlFillGradient.Controls.Add(this.udGradientRotation);
            this.pnlFillGradient.Controls.Add(this.label26);
            this.pnlFillGradient.Controls.Add(this.label8);
            this.pnlFillGradient.Controls.Add(this.clpGradient2);
            this.pnlFillGradient.Controls.Add(this.cboGradientType);
            this.pnlFillGradient.Location = new System.Drawing.Point(840, 28);
            this.pnlFillGradient.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlFillGradient.Name = "pnlFillGradient";
            this.pnlFillGradient.Size = new System.Drawing.Size(483, 96);
            this.pnlFillGradient.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 62);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 100;
            this.label5.Text = "第二个颜色";
            // 
            // udGradientRotation
            // 
            this.udGradientRotation.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udGradientRotation.Location = new System.Drawing.Point(389, 13);
            this.udGradientRotation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.udGradientRotation.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.udGradientRotation.Name = "udGradientRotation";
            this.udGradientRotation.Size = new System.Drawing.Size(75, 25);
            this.udGradientRotation.TabIndex = 99;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(336, 15);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(37, 15);
            this.label26.TabIndex = 95;
            this.label26.Text = "角度";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 16);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 89;
            this.label8.Text = "混合类型";
            // 
            // clpGradient2
            // 
            this.clpGradient2.Color = System.Drawing.Color.Black;
            this.clpGradient2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpGradient2.DropDownHeight = 1;
            this.clpGradient2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpGradient2.FormattingEnabled = true;
            this.clpGradient2.IntegralHeight = false;
            this.clpGradient2.Items.AddRange(new object[] {
            "Color"});
            this.clpGradient2.Location = new System.Drawing.Point(113, 59);
            this.clpGradient2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clpGradient2.Name = "clpGradient2";
            this.clpGradient2.Size = new System.Drawing.Size(95, 26);
            this.clpGradient2.TabIndex = 88;
            // 
            // cboGradientType
            // 
            this.cboGradientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradientType.FormattingEnabled = true;
            this.cboGradientType.Location = new System.Drawing.Point(131, 13);
            this.cboGradientType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboGradientType.Name = "cboGradientType";
            this.cboGradientType.Size = new System.Drawing.Size(180, 23);
            this.cboGradientType.TabIndex = 90;
            // 
            // pnlFillPicture
            // 
            this.pnlFillPicture.Controls.Add(this.btnChooseTexture);
            this.pnlFillPicture.Location = new System.Drawing.Point(840, 168);
            this.pnlFillPicture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlFillPicture.Name = "pnlFillPicture";
            this.pnlFillPicture.Size = new System.Drawing.Size(483, 73);
            this.pnlFillPicture.TabIndex = 43;
            // 
            // btnChooseTexture
            // 
            this.btnChooseTexture.Location = new System.Drawing.Point(113, 8);
            this.btnChooseTexture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnChooseTexture.Name = "btnChooseTexture";
            this.btnChooseTexture.Size = new System.Drawing.Size(151, 27);
            this.btnChooseTexture.TabIndex = 0;
            this.btnChooseTexture.Text = "选择纹理";
            this.btnChooseTexture.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(417, 408);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(127, 30);
            this.btnApply.TabIndex = 44;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cboIconCollection
            // 
            this.cboIconCollection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIconCollection.FormattingEnabled = true;
            this.cboIconCollection.Location = new System.Drawing.Point(103, 19);
            this.cboIconCollection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboIconCollection.Name = "cboIconCollection";
            this.cboIconCollection.Size = new System.Drawing.Size(235, 23);
            this.cboIconCollection.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 71;
            // 
            // chkScaleIcons
            // 
            this.chkScaleIcons.AutoSize = true;
            this.chkScaleIcons.Location = new System.Drawing.Point(392, 21);
            this.chkScaleIcons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkScaleIcons.Name = "chkScaleIcons";
            this.chkScaleIcons.Size = new System.Drawing.Size(74, 19);
            this.chkScaleIcons.TabIndex = 73;
            this.chkScaleIcons.Text = "分辨率";
            this.chkScaleIcons.UseVisualStyleBackColor = true;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Location = new System.Drawing.Point(529, 344);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(13, 12);
            this.lblCopyright.TabIndex = 45;
            // 
            // iconControl1
            // 
            this.iconControl1.BackColor = System.Drawing.Color.Transparent;
            this.iconControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iconControl1.CellHeight = 24;
            this.iconControl1.CellWidth = 24;
            this.iconControl1.FilePath = "";
            this.iconControl1.Font = new System.Drawing.Font("Arial", 25.6F);
            this.iconControl1.GridColor = System.Drawing.Color.Black;
            this.iconControl1.GridVisible = true;
            this.iconControl1.ItemCount = 0;
            this.iconControl1.Location = new System.Drawing.Point(13, 54);
            this.iconControl1.Margin = new System.Windows.Forms.Padding(13, 10, 13, 10);
            this.iconControl1.Name = "iconControl1";
            this.iconControl1.SelectedIndex = -1;
            this.iconControl1.Size = new System.Drawing.Size(526, 297);
            this.iconControl1.TabIndex = 72;
            this.iconControl1.Textures = false;
            // 
            // tabIcon
            // 
            this.tabIcon.Controls.Add(this.iconControl1);
            this.tabIcon.Controls.Add(this.lblCopyright);
            this.tabIcon.Controls.Add(this.chkScaleIcons);
            this.tabIcon.Controls.Add(this.label2);
            this.tabIcon.Controls.Add(this.cboIconCollection);
            this.tabIcon.Location = new System.Drawing.Point(4, 25);
            this.tabIcon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabIcon.Name = "tabIcon";
            this.tabIcon.Size = new System.Drawing.Size(556, 363);
            this.tabIcon.TabIndex = 4;
            this.tabIcon.Text = "图标";
            this.tabIcon.UseVisualStyleBackColor = true;
            // 
            // PointsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(825, 444);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.pnlFillGradient);
            this.Controls.Add(this.pnlFillPicture);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PointsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "点样式";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPoints_FormClosing);
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRotation)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabSymbol.ResumeLayout(false);
            this.tabSymbol.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udPointNumSides)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSideRatio)).EndInit();
            this.tabCharacter.ResumeLayout(false);
            this.tabCharacter.PerformLayout();
            this.tabOptions.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pnlFillHatch.ResumeLayout(false);
            this.pnlFillHatch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctPreview)).EndInit();
            this.pnlFillGradient.ResumeLayout(false);
            this.pnlFillGradient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udGradientRotation)).EndInit();
            this.pnlFillPicture.ResumeLayout(false);
            this.tabIcon.ResumeLayout(false);
            this.tabIcon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private MWLite.Symbology.Controls.NumericUpDownExt udSize;
        private MWLite.Symbology.Controls.NumericUpDownExt udRotation;
        private Office2007ColorPicker clpFillColor;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSymbol;
        private SymbolControl symbolControl1;
        private MWLite.Symbology.Controls.NumericUpDownExt udPointNumSides;
        private MWLite.Symbology.Controls.NumericUpDownExt udSideRatio;
        private ImageCombo icbPointShape;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkOutlineVisible;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private ImageCombo icbLineWidth;
        private ImageCombo icbLineType;
        private Office2007ColorPicker clpOutline;
        private System.Windows.Forms.CheckBox chkFillVisible;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFillType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pctPreview;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private Office2007ColorPicker clpHatchBack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlFillHatch;
        private ImageCombo icbHatchStyle;
        private System.Windows.Forms.CheckBox chkFillBgTransparent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlFillGradient;
        private MWLite.Symbology.Controls.NumericUpDownExt udGradientRotation;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboGradientType;
        private Office2007ColorPicker clpGradient2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlFillPicture;
        private System.Windows.Forms.Button btnChooseTexture;
        private System.Windows.Forms.Label lblNoOptions;
        private System.Windows.Forms.Label label3;
        private MWLite.Symbology.Controls.TransparencyControl transparencyControl1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TabPage tabCharacter;
        private System.Windows.Forms.CheckBox chkShowAllFonts;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cboFontName;
        private CharacterControl characterControl1;
        private System.Windows.Forms.TabPage tabIcon;
        private IconControl iconControl1;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.CheckBox chkScaleIcons;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboIconCollection;
    }
}