using System.Windows.Forms;

namespace MapWinGis_Demo_zhw
{
    partial class Main
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
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            this._mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusSelectedCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblProgressMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripPanel1 = new System.Windows.Forms.ToolStripPanel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this._toolStripLayer = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.symbolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prosperityItem = new System.Windows.Forms.ToolStripMenuItem();
            this.table = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCloseProject = new System.Windows.Forms.ToolStripButton();
            this.toolLoadProject = new System.Windows.Forms.ToolStripButton();
            this.toolSaveProject = new System.Windows.Forms.ToolStripButton();
            this.toolSaveProjectAs = new System.Windows.Forms.ToolStripButton();
            this.toolOpen = new System.Windows.Forms.ToolStripButton();
            this.toolAddVector = new System.Windows.Forms.ToolStripButton();
            this.toolAddRaster = new System.Windows.Forms.ToolStripButton();
            this.toolAddDatabase = new System.Windows.Forms.ToolStripButton();
            this.toolCreateLayer = new System.Windows.Forms.ToolStripButton();
            this.toolRemoveLayer = new System.Windows.Forms.ToolStripButton();
            this.toolZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolZoomMax = new System.Windows.Forms.ToolStripButton();
            this.toolZoomToLayer = new System.Windows.Forms.ToolStripButton();
            this.toolPan = new System.Windows.Forms.ToolStripButton();
            this.toolSetProjection = new System.Windows.Forms.ToolStripButton();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.toolIdentify = new System.Windows.Forms.ToolStripButton();
            this.toolMeasure = new System.Windows.Forms.ToolStripButton();
            this.toolMeasureArea = new System.Windows.Forms.ToolStripButton();
            this.toolSelection = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSelectByPolygon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolZoomToSelected = new System.Windows.Forms.ToolStripButton();
            this.toolClearSelection = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.mnuCloseProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddVector = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddRaster = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveProjectAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseApp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetProjection = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSnapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this._mainToolStrip.SuspendLayout();
            this._menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this._toolStripLayer.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainToolStrip
            // 
            this._mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._mainToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolZoomIn,
            this.toolZoomOut,
            this.toolZoomMax,
            this.toolZoomToLayer,
            this.toolPan,
            this.toolStripSeparator10,
            this.toolSetProjection,
            this.toolSearch,
            this.toolStripSeparator4,
            this.toolIdentify,
            this.toolMeasure,
            this.toolMeasureArea,
            this.toolStripSeparator3,
            this.toolSelection,
            this.toolZoomToSelected,
            this.toolClearSelection,
            this.toolStripSeparator11,
            this.toolStripButton1,
            this.toolStripButton2});
            this._mainToolStrip.Location = new System.Drawing.Point(3, 0);
            this._mainToolStrip.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this._mainToolStrip.Name = "_mainToolStrip";
            this._mainToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this._mainToolStrip.Size = new System.Drawing.Size(587, 41);
            this._mainToolStrip.TabIndex = 0;
            this._mainToolStrip.Text = "toolStrip1";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
            // 
            // _menuStrip1
            // 
            this._menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuMap,
            this.mnuTiles});
            this._menuStrip1.Location = new System.Drawing.Point(0, 0);
            this._menuStrip1.Name = "_menuStrip1";
            this._menuStrip1.Size = new System.Drawing.Size(1010, 28);
            this._menuStrip1.TabIndex = 2;
            this._menuStrip1.Text = "_menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCloseProject,
            this.toolStripSeparator5,
            this.mnuOpen,
            this.mnuAddVector,
            this.mnuAddRaster,
            this.toolStripSeparator7,
            this.mnuLoadProject,
            this.toolStripSeparator2,
            this.mnuSaveProject,
            this.mnuSaveProjectAs,
            this.toolStripSeparator6,
            this.mnuCloseApp});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(51, 24);
            this.mnuFile.Text = "文件";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(203, 6);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(203, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(203, 6);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(203, 6);
            // 
            // mnuMap
            // 
            this.mnuMap.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetProjection,
            this.mnuSearch,
            this.toolStripSeparator9,
            this.mnuSnapshot});
            this.mnuMap.Name = "mnuMap";
            this.mnuMap.Size = new System.Drawing.Size(51, 24);
            this.mnuMap.Text = "地图";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuTiles
            // 
            this.mnuTiles.Name = "mnuTiles";
            this.mnuTiles.Size = new System.Drawing.Size(54, 24);
            this.mnuTiles.Text = "Tiles";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusSelectedCount,
            this.lblProgressMessage,
            this.progressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 589);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1010, 25);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusSelectedCount
            // 
            this.statusSelectedCount.Name = "statusSelectedCount";
            this.statusSelectedCount.Size = new System.Drawing.Size(995, 20);
            this.statusSelectedCount.Spring = true;
            this.statusSelectedCount.Text = "Selected: 0";
            this.statusSelectedCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProgressMessage
            // 
            this.lblProgressMessage.Name = "lblProgressMessage";
            this.lblProgressMessage.Size = new System.Drawing.Size(0, 20);
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 19);
            this.progressBar1.Visible = false;
            // 
            // toolStripPanel1
            // 
            this.toolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripPanel1.Location = new System.Drawing.Point(0, 28);
            this.toolStripPanel1.MaximumSize = new System.Drawing.Size(0, 40);
            this.toolStripPanel1.Name = "toolStripPanel1";
            this.toolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.toolStripPanel1.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripPanel1.Size = new System.Drawing.Size(1010, 0);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dockPanel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(971, 520);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this._toolStripLayer);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 28);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1010, 561);
            this.toolStripContainer1.TabIndex = 5;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this._mainToolStrip);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.SystemColors.Control;
            this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingSdi;
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(971, 520);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            autoHideStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            dockPaneStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.dockPanel1.Skin = dockPanelSkin1;
            this.dockPanel1.TabIndex = 0;
            // 
            // _toolStripLayer
            // 
            this._toolStripLayer.Dock = System.Windows.Forms.DockStyle.None;
            this._toolStripLayer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolStripLayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCloseProject,
            this.toolLoadProject,
            this.toolSaveProject,
            this.toolSaveProjectAs,
            this.toolStripSeparator8,
            this.toolOpen,
            this.toolAddVector,
            this.toolAddRaster,
            this.toolAddDatabase,
            this.toolStripSeparator1,
            this.toolCreateLayer,
            this.toolRemoveLayer});
            this._toolStripLayer.Location = new System.Drawing.Point(0, 3);
            this._toolStripLayer.Name = "_toolStripLayer";
            this._toolStripLayer.Size = new System.Drawing.Size(39, 431);
            this._toolStripLayer.TabIndex = 1;
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(37, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(37, 6);
            // 
            // ContextMenu
            // 
            this.ContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeItem,
            this.symbolItem,
            this.labelItem,
            this.prosperityItem,
            this.table});
            this.ContextMenu.Name = "contextMenuStrip1";
            this.ContextMenu.Size = new System.Drawing.Size(139, 124);
            this.ContextMenu.Text = "符号设置";
            // 
            // removeItem
            // 
            this.removeItem.Name = "removeItem";
            this.removeItem.Size = new System.Drawing.Size(138, 24);
            this.removeItem.Text = "移除";
            this.removeItem.Click += new System.EventHandler(this.removeItem_Click);
            // 
            // symbolItem
            // 
            this.symbolItem.Name = "symbolItem";
            this.symbolItem.Size = new System.Drawing.Size(138, 24);
            this.symbolItem.Text = "符号设置";
            this.symbolItem.Click += new System.EventHandler(this.symbolItem_Click);
            // 
            // labelItem
            // 
            this.labelItem.Name = "labelItem";
            this.labelItem.Size = new System.Drawing.Size(138, 24);
            this.labelItem.Text = "标注设置";
            this.labelItem.Click += new System.EventHandler(this.lableItem_Click);
            // 
            // prosperityItem
            // 
            this.prosperityItem.Name = "prosperityItem";
            this.prosperityItem.Size = new System.Drawing.Size(138, 24);
            this.prosperityItem.Text = "属性";
            this.prosperityItem.Click += new System.EventHandler(this.prosperityItem_Click);
            // 
            // table
            // 
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(138, 24);
            this.table.Text = "表";
            this.table.Click += new System.EventHandler(this.table_Click);
            // 
            // toolCloseProject
            // 
            this.toolCloseProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCloseProject.Image = global::MapWinGis_Demo_zhw.Properties.Resources.map;
            this.toolCloseProject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolCloseProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCloseProject.Name = "toolCloseProject";
            this.toolCloseProject.Padding = new System.Windows.Forms.Padding(5);
            this.toolCloseProject.Size = new System.Drawing.Size(37, 38);
            this.toolCloseProject.Text = "新建工程";
            // 
            // toolLoadProject
            // 
            this.toolLoadProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLoadProject.Image = global::MapWinGis_Demo_zhw.Properties.Resources.folder1;
            this.toolLoadProject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolLoadProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLoadProject.Name = "toolLoadProject";
            this.toolLoadProject.Padding = new System.Windows.Forms.Padding(5);
            this.toolLoadProject.Size = new System.Drawing.Size(37, 38);
            this.toolLoadProject.Text = "加载工程";
            // 
            // toolSaveProject
            // 
            this.toolSaveProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSaveProject.Image = global::MapWinGis_Demo_zhw.Properties.Resources.save;
            this.toolSaveProject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSaveProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveProject.Name = "toolSaveProject";
            this.toolSaveProject.Padding = new System.Windows.Forms.Padding(5);
            this.toolSaveProject.Size = new System.Drawing.Size(37, 38);
            this.toolSaveProject.Text = "保存";
            // 
            // toolSaveProjectAs
            // 
            this.toolSaveProjectAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSaveProjectAs.Image = global::MapWinGis_Demo_zhw.Properties.Resources.save_as1;
            this.toolSaveProjectAs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSaveProjectAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveProjectAs.Name = "toolSaveProjectAs";
            this.toolSaveProjectAs.Padding = new System.Windows.Forms.Padding(5);
            this.toolSaveProjectAs.Size = new System.Drawing.Size(37, 38);
            this.toolSaveProjectAs.Text = "另存为...";
            // 
            // toolOpen
            // 
            this.toolOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolOpen.Image = global::MapWinGis_Demo_zhw.Properties.Resources.layer_add;
            this.toolOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOpen.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.toolOpen.Name = "toolOpen";
            this.toolOpen.Padding = new System.Windows.Forms.Padding(5);
            this.toolOpen.Size = new System.Drawing.Size(37, 38);
            this.toolOpen.Text = "加入图层";
            // 
            // toolAddVector
            // 
            this.toolAddVector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAddVector.Image = global::MapWinGis_Demo_zhw.Properties.Resources.layer_vector_add;
            this.toolAddVector.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolAddVector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddVector.Name = "toolAddVector";
            this.toolAddVector.Padding = new System.Windows.Forms.Padding(5);
            this.toolAddVector.Size = new System.Drawing.Size(37, 38);
            this.toolAddVector.Text = "加入矢量图层";
            // 
            // toolAddRaster
            // 
            this.toolAddRaster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAddRaster.Image = global::MapWinGis_Demo_zhw.Properties.Resources.layer_raster_add;
            this.toolAddRaster.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolAddRaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddRaster.Name = "toolAddRaster";
            this.toolAddRaster.Padding = new System.Windows.Forms.Padding(5);
            this.toolAddRaster.Size = new System.Drawing.Size(37, 38);
            this.toolAddRaster.Text = "加入栅格图层";
            // 
            // toolAddDatabase
            // 
            this.toolAddDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAddDatabase.Image = global::MapWinGis_Demo_zhw.Properties.Resources.layer_db_add;
            this.toolAddDatabase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolAddDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddDatabase.Name = "toolAddDatabase";
            this.toolAddDatabase.Padding = new System.Windows.Forms.Padding(5);
            this.toolAddDatabase.Size = new System.Drawing.Size(37, 38);
            this.toolAddDatabase.Text = "加入postGis图层";
            // 
            // toolCreateLayer
            // 
            this.toolCreateLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCreateLayer.Image = global::MapWinGis_Demo_zhw.Properties.Resources.layer_create;
            this.toolCreateLayer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolCreateLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCreateLayer.Name = "toolCreateLayer";
            this.toolCreateLayer.Padding = new System.Windows.Forms.Padding(5);
            this.toolCreateLayer.Size = new System.Drawing.Size(37, 38);
            this.toolCreateLayer.Text = "新建图层";
            // 
            // toolRemoveLayer
            // 
            this.toolRemoveLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolRemoveLayer.Image = global::MapWinGis_Demo_zhw.Properties.Resources.layer_remove;
            this.toolRemoveLayer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolRemoveLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRemoveLayer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.toolRemoveLayer.Name = "toolRemoveLayer";
            this.toolRemoveLayer.Padding = new System.Windows.Forms.Padding(5);
            this.toolRemoveLayer.Size = new System.Drawing.Size(37, 38);
            this.toolRemoveLayer.Text = "移除图层";
            // 
            // toolZoomIn
            // 
            this.toolZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolZoomIn.Image = global::MapWinGis_Demo_zhw.Properties.Resources.zoom_inNew;
            this.toolZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolZoomIn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.toolZoomIn.Name = "toolZoomIn";
            this.toolZoomIn.Padding = new System.Windows.Forms.Padding(5);
            this.toolZoomIn.Size = new System.Drawing.Size(38, 39);
            this.toolZoomIn.Text = "放大";
            // 
            // toolZoomOut
            // 
            this.toolZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolZoomOut.Image = global::MapWinGis_Demo_zhw.Properties.Resources.zoom_outNew;
            this.toolZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolZoomOut.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.toolZoomOut.Name = "toolZoomOut";
            this.toolZoomOut.Padding = new System.Windows.Forms.Padding(5);
            this.toolZoomOut.Size = new System.Drawing.Size(38, 39);
            this.toolZoomOut.Text = "缩小";
            // 
            // toolZoomMax
            // 
            this.toolZoomMax.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolZoomMax.Image = global::MapWinGis_Demo_zhw.Properties.Resources.zoom_extentNew;
            this.toolZoomMax.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolZoomMax.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolZoomMax.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.toolZoomMax.Name = "toolZoomMax";
            this.toolZoomMax.Padding = new System.Windows.Forms.Padding(5);
            this.toolZoomMax.Size = new System.Drawing.Size(38, 39);
            this.toolZoomMax.Text = "全局";
            // 
            // toolZoomToLayer
            // 
            this.toolZoomToLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolZoomToLayer.Image = global::MapWinGis_Demo_zhw.Properties.Resources.zoom_layer;
            this.toolZoomToLayer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolZoomToLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolZoomToLayer.Name = "toolZoomToLayer";
            this.toolZoomToLayer.Padding = new System.Windows.Forms.Padding(5);
            this.toolZoomToLayer.Size = new System.Drawing.Size(38, 38);
            this.toolZoomToLayer.Text = "复位";
            // 
            // toolPan
            // 
            this.toolPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPan.Image = global::MapWinGis_Demo_zhw.Properties.Resources.pan;
            this.toolPan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolPan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPan.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.toolPan.Name = "toolPan";
            this.toolPan.Padding = new System.Windows.Forms.Padding(5);
            this.toolPan.Size = new System.Drawing.Size(38, 39);
            this.toolPan.Text = "漫游";
            // 
            // toolSetProjection
            // 
            this.toolSetProjection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSetProjection.Image = global::MapWinGis_Demo_zhw.Properties.Resources.crs_change;
            this.toolSetProjection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSetProjection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSetProjection.Name = "toolSetProjection";
            this.toolSetProjection.Padding = new System.Windows.Forms.Padding(5);
            this.toolSetProjection.Size = new System.Drawing.Size(38, 38);
            this.toolSetProjection.Text = "设置坐标与投影";
            // 
            // toolSearch
            // 
            this.toolSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSearch.Image = global::MapWinGis_Demo_zhw.Properties.Resources.search;
            this.toolSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSearch.Name = "toolSearch";
            this.toolSearch.Padding = new System.Windows.Forms.Padding(5);
            this.toolSearch.Size = new System.Drawing.Size(38, 38);
            this.toolSearch.Text = "查找";
            // 
            // toolIdentify
            // 
            this.toolIdentify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolIdentify.Image = global::MapWinGis_Demo_zhw.Properties.Resources.attribute_show;
            this.toolIdentify.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolIdentify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolIdentify.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.toolIdentify.Name = "toolIdentify";
            this.toolIdentify.Padding = new System.Windows.Forms.Padding(5);
            this.toolIdentify.Size = new System.Drawing.Size(38, 39);
            this.toolIdentify.Text = "识别";
            // 
            // toolMeasure
            // 
            this.toolMeasure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMeasure.Image = global::MapWinGis_Demo_zhw.Properties.Resources.measure;
            this.toolMeasure.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolMeasure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMeasure.Name = "toolMeasure";
            this.toolMeasure.Padding = new System.Windows.Forms.Padding(5);
            this.toolMeasure.Size = new System.Drawing.Size(38, 38);
            this.toolMeasure.Text = "距离量算";
            // 
            // toolMeasureArea
            // 
            this.toolMeasureArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMeasureArea.Image = global::MapWinGis_Demo_zhw.Properties.Resources.area_measure;
            this.toolMeasureArea.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolMeasureArea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMeasureArea.Name = "toolMeasureArea";
            this.toolMeasureArea.Padding = new System.Windows.Forms.Padding(5);
            this.toolMeasureArea.Size = new System.Drawing.Size(38, 38);
            this.toolMeasureArea.Text = "面积量算";
            // 
            // toolSelection
            // 
            this.toolSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSelection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSelect,
            this.toolSelectByPolygon});
            this.toolSelection.Image = global::MapWinGis_Demo_zhw.Properties.Resources.select1;
            this.toolSelection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSelection.Name = "toolSelection";
            this.toolSelection.Padding = new System.Windows.Forms.Padding(5);
            this.toolSelection.Size = new System.Drawing.Size(48, 38);
            this.toolSelection.Text = "选择";
            // 
            // toolSelect
            // 
            this.toolSelect.Name = "toolSelect";
            this.toolSelect.Size = new System.Drawing.Size(216, 26);
            this.toolSelect.Text = "By Rectangle";
            // 
            // toolSelectByPolygon
            // 
            this.toolSelectByPolygon.Name = "toolSelectByPolygon";
            this.toolSelectByPolygon.Size = new System.Drawing.Size(216, 26);
            this.toolSelectByPolygon.Text = "By Polygon";
            // 
            // toolZoomToSelected
            // 
            this.toolZoomToSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolZoomToSelected.Image = global::MapWinGis_Demo_zhw.Properties.Resources.zoom_selection;
            this.toolZoomToSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolZoomToSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolZoomToSelected.Name = "toolZoomToSelected";
            this.toolZoomToSelected.Padding = new System.Windows.Forms.Padding(5);
            this.toolZoomToSelected.Size = new System.Drawing.Size(38, 38);
            this.toolZoomToSelected.Text = "缩放至所选";
            // 
            // toolClearSelection
            // 
            this.toolClearSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolClearSelection.Image = global::MapWinGis_Demo_zhw.Properties.Resources.selected_delete;
            this.toolClearSelection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolClearSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClearSelection.Name = "toolClearSelection";
            this.toolClearSelection.Padding = new System.Windows.Forms.Padding(5);
            this.toolClearSelection.Size = new System.Drawing.Size(38, 38);
            this.toolClearSelection.Text = "清除选择";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::MapWinGis_Demo_zhw.Properties.Resources.question;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 38);
            this.toolStripButton1.Text = "帮助";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::MapWinGis_Demo_zhw.Properties.Resources.github__1_;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 38);
            this.toolStripButton2.Text = "远程仓库代码";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // mnuCloseProject
            // 
            this.mnuCloseProject.Image = global::MapWinGis_Demo_zhw.Properties.Resources.map;
            this.mnuCloseProject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCloseProject.Name = "mnuCloseProject";
            this.mnuCloseProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuCloseProject.Size = new System.Drawing.Size(206, 30);
            this.mnuCloseProject.Text = "新建地图";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Image = global::MapWinGis_Demo_zhw.Properties.Resources.layer_add;
            this.mnuOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpen.Size = new System.Drawing.Size(206, 30);
            this.mnuOpen.Text = "打开文件";
            // 
            // mnuAddVector
            // 
            this.mnuAddVector.Image = global::MapWinGis_Demo_zhw.Properties.Resources.layer_vector_add;
            this.mnuAddVector.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuAddVector.Name = "mnuAddVector";
            this.mnuAddVector.Size = new System.Drawing.Size(206, 30);
            this.mnuAddVector.Text = "打开要素文件";
            // 
            // mnuAddRaster
            // 
            this.mnuAddRaster.Image = global::MapWinGis_Demo_zhw.Properties.Resources.layer_raster_add;
            this.mnuAddRaster.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuAddRaster.Name = "mnuAddRaster";
            this.mnuAddRaster.Size = new System.Drawing.Size(206, 30);
            this.mnuAddRaster.Text = "打开栅格文件";
            // 
            // mnuLoadProject
            // 
            this.mnuLoadProject.Image = global::MapWinGis_Demo_zhw.Properties.Resources.folder1;
            this.mnuLoadProject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuLoadProject.Name = "mnuLoadProject";
            this.mnuLoadProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuLoadProject.Size = new System.Drawing.Size(206, 30);
            this.mnuLoadProject.Text = "加载文件";
            // 
            // mnuSaveProject
            // 
            this.mnuSaveProject.Image = global::MapWinGis_Demo_zhw.Properties.Resources.save1;
            this.mnuSaveProject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSaveProject.Name = "mnuSaveProject";
            this.mnuSaveProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSaveProject.Size = new System.Drawing.Size(206, 30);
            this.mnuSaveProject.Text = "保存文件";
            // 
            // mnuSaveProjectAs
            // 
            this.mnuSaveProjectAs.Image = global::MapWinGis_Demo_zhw.Properties.Resources.save_as1;
            this.mnuSaveProjectAs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSaveProjectAs.Name = "mnuSaveProjectAs";
            this.mnuSaveProjectAs.Size = new System.Drawing.Size(206, 30);
            this.mnuSaveProjectAs.Text = "另存为";
            // 
            // mnuCloseApp
            // 
            this.mnuCloseApp.Image = global::MapWinGis_Demo_zhw.Properties.Resources.quit1;
            this.mnuCloseApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCloseApp.Name = "mnuCloseApp";
            this.mnuCloseApp.Size = new System.Drawing.Size(206, 30);
            this.mnuCloseApp.Text = "关闭";
            // 
            // mnuSetProjection
            // 
            this.mnuSetProjection.Image = global::MapWinGis_Demo_zhw.Properties.Resources.crs_change;
            this.mnuSetProjection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSetProjection.Name = "mnuSetProjection";
            this.mnuSetProjection.Size = new System.Drawing.Size(178, 30);
            this.mnuSetProjection.Text = "设置投影";
            // 
            // mnuSearch
            // 
            this.mnuSearch.Image = global::MapWinGis_Demo_zhw.Properties.Resources.search;
            this.mnuSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSearch.Name = "mnuSearch";
            this.mnuSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuSearch.Size = new System.Drawing.Size(178, 30);
            this.mnuSearch.Text = "查找";
            // 
            // mnuSnapshot
            // 
            this.mnuSnapshot.Image = global::MapWinGis_Demo_zhw.Properties.Resources.Snapshot;
            this.mnuSnapshot.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSnapshot.Name = "mnuSnapshot";
            this.mnuSnapshot.Size = new System.Drawing.Size(178, 30);
            this.mnuSnapshot.Text = "获取当前快照";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 41);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 614);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripPanel1);
            this.Controls.Add(this._menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this._menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MapWindow Lite";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this._mainToolStrip.ResumeLayout(false);
            this._mainToolStrip.PerformLayout();
            this._menuStrip1.ResumeLayout(false);
            this._menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this._toolStripLayer.ResumeLayout(false);
            this._toolStripLayer.PerformLayout();
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion



        private ToolStrip _mainToolStrip;
        private MenuStrip _menuStrip1;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuOpen;
        private StatusStrip statusStrip1;
        private ToolStripButton toolZoomIn;
        private ToolStripButton toolZoomOut;
        private ToolStripButton toolZoomMax;
        private ToolStripButton toolPan;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem mnuCloseProject;
        private ToolStripMenuItem mnuSaveProject;
        private ToolStripMenuItem mnuTiles;
        private ToolStripButton toolIdentify;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripPanel toolStripPanel1;
        private ToolStripContainer toolStripContainer1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private ToolStripButton toolZoomToLayer;
        private ToolStripButton toolMeasureArea;
        private ToolStripButton toolMeasure;
        private ToolStripMenuItem mnuMap;
        private ToolStripMenuItem mnuSetProjection;
        private ToolStrip _toolStripLayer;
        private ToolStripButton toolOpen;
        private ToolStripButton toolRemoveLayer;
        private ToolStripButton toolAddVector;
        private ToolStripButton toolAddRaster;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripProgressBar progressBar1;
        private ToolStripStatusLabel lblProgressMessage;
        private ToolStripStatusLabel statusSelectedCount;
        private ToolStripButton toolCreateLayer;
        private ToolStripButton toolClearSelection;
        private ToolStripButton toolZoomToSelected;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem mnuAddVector;
        private ToolStripMenuItem mnuAddRaster;
        private ToolStripMenuItem mnuSaveProjectAs;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem mnuCloseApp;
        private ToolStripMenuItem mnuSearch;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem mnuLoadProject;
        private ToolStripButton toolLoadProject;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripButton toolCloseProject;
        private ToolStripButton toolSaveProject;
        private ToolStripButton toolSaveProjectAs;
        private ToolStripDropDownButton toolSelection;
        private ToolStripMenuItem toolSelect;
        private ToolStripMenuItem toolSelectByPolygon;
        private ToolStripButton toolAddDatabase;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem mnuSnapshot;
        private ToolStripButton toolSearch;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripButton toolSetProjection;
        private ContextMenuStrip ContextMenu;
        private ToolStripMenuItem removeItem;
        private ToolStripMenuItem symbolItem;
        private ToolStripMenuItem labelItem;
        private ToolStripMenuItem prosperityItem;
        private ToolStripMenuItem table;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripSeparator toolStripSeparator11;
    }
}