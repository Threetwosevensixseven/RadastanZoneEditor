using RadastanZoneEditor.Controls;

namespace RadastanZoneEditor.Forms
{
  partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.pnlMain = new System.Windows.Forms.SplitContainer();
            this.tabImage = new System.Windows.Forms.TabControl();
            this.tabSource = new System.Windows.Forms.TabPage();
            this.picSource = new RadastanZoneEditor.Controls.RadastanPictureBox();
            this.tabOptimized = new System.Windows.Forms.TabPage();
            this.picOptimized = new RadastanZoneEditor.Controls.RadastanPictureBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblULA = new System.Windows.Forms.Label();
            this.pnlULA = new System.Windows.Forms.TableLayoutPanel();
            this.pnlULA15 = new System.Windows.Forms.Panel();
            this.pnlULA14 = new System.Windows.Forms.Panel();
            this.pnlULA13 = new System.Windows.Forms.Panel();
            this.pnlULA12 = new System.Windows.Forms.Panel();
            this.pnlULA11 = new System.Windows.Forms.Panel();
            this.pnlULA10 = new System.Windows.Forms.Panel();
            this.pnlULA9 = new System.Windows.Forms.Panel();
            this.pnlULA8 = new System.Windows.Forms.Panel();
            this.pnlULA7 = new System.Windows.Forms.Panel();
            this.pnlULA6 = new System.Windows.Forms.Panel();
            this.pnlULA5 = new System.Windows.Forms.Panel();
            this.pnlULA4 = new System.Windows.Forms.Panel();
            this.pnlULA3 = new System.Windows.Forms.Panel();
            this.pnlULA2 = new System.Windows.Forms.Panel();
            this.pnlULA1 = new System.Windows.Forms.Panel();
            this.pnlULA0 = new System.Windows.Forms.Panel();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblUnique = new System.Windows.Forms.Label();
            this.lblUniqueVal = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.pnlSource = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCol15 = new System.Windows.Forms.Panel();
            this.pnlCol14 = new System.Windows.Forms.Panel();
            this.pnlCol13 = new System.Windows.Forms.Panel();
            this.pnlCol12 = new System.Windows.Forms.Panel();
            this.pnlCol11 = new System.Windows.Forms.Panel();
            this.pnlCol10 = new System.Windows.Forms.Panel();
            this.pnlCol9 = new System.Windows.Forms.Panel();
            this.pnlCol8 = new System.Windows.Forms.Panel();
            this.pnlCol7 = new System.Windows.Forms.Panel();
            this.pnlCol6 = new System.Windows.Forms.Panel();
            this.pnlCol5 = new System.Windows.Forms.Panel();
            this.pnlCol4 = new System.Windows.Forms.Panel();
            this.pnlCol3 = new System.Windows.Forms.Panel();
            this.pnlCol2 = new System.Windows.Forms.Panel();
            this.pnlCol1 = new System.Windows.Forms.Panel();
            this.pnlCol0 = new System.Windows.Forms.Panel();
            this.lblClut = new System.Windows.Forms.Label();
            this.cboClut = new System.Windows.Forms.ComboBox();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblZone = new System.Windows.Forms.Label();
            this.cboZone = new System.Windows.Forms.ComboBox();
            this.numZones = new System.Windows.Forms.NumericUpDown();
            this.lblZones = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.Panel1.SuspendLayout();
            this.pnlMain.Panel2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tabImage.SuspendLayout();
            this.tabSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).BeginInit();
            this.tabOptimized.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOptimized)).BeginInit();
            this.pnlULA.SuspendLayout();
            this.pnlSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZones)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(641, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dlgFileOpen
            // 
            this.dlgFileOpen.DefaultExt = "png";
            this.dlgFileOpen.FileName = "*.png";
            this.dlgFileOpen.Title = "Open File";
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Name = "pnlMain";
            // 
            // pnlMain.Panel1
            // 
            this.pnlMain.Panel1.Controls.Add(this.tabImage);
            // 
            // pnlMain.Panel2
            // 
            this.pnlMain.Panel2.Controls.Add(this.btnExport);
            this.pnlMain.Panel2.Controls.Add(this.lblULA);
            this.pnlMain.Panel2.Controls.Add(this.pnlULA);
            this.pnlMain.Panel2.Controls.Add(this.lblSource);
            this.pnlMain.Panel2.Controls.Add(this.lblUnique);
            this.pnlMain.Panel2.Controls.Add(this.lblUniqueVal);
            this.pnlMain.Panel2.Controls.Add(this.btnCalculate);
            this.pnlMain.Panel2.Controls.Add(this.pnlSource);
            this.pnlMain.Panel2.Controls.Add(this.lblClut);
            this.pnlMain.Panel2.Controls.Add(this.cboClut);
            this.pnlMain.Panel2.Controls.Add(this.numHeight);
            this.pnlMain.Panel2.Controls.Add(this.lblHeight);
            this.pnlMain.Panel2.Controls.Add(this.lblZone);
            this.pnlMain.Panel2.Controls.Add(this.cboZone);
            this.pnlMain.Panel2.Controls.Add(this.numZones);
            this.pnlMain.Panel2.Controls.Add(this.lblZones);
            this.pnlMain.Panel2.Enabled = false;
            this.pnlMain.Size = new System.Drawing.Size(641, 345);
            this.pnlMain.SplitterDistance = 468;
            this.pnlMain.TabIndex = 2;
            // 
            // tabImage
            // 
            this.tabImage.Controls.Add(this.tabSource);
            this.tabImage.Controls.Add(this.tabOptimized);
            this.tabImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabImage.Location = new System.Drawing.Point(0, 0);
            this.tabImage.Name = "tabImage";
            this.tabImage.SelectedIndex = 0;
            this.tabImage.Size = new System.Drawing.Size(468, 345);
            this.tabImage.TabIndex = 2;
            // 
            // tabSource
            // 
            this.tabSource.Controls.Add(this.picSource);
            this.tabSource.Location = new System.Drawing.Point(4, 22);
            this.tabSource.Name = "tabSource";
            this.tabSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabSource.Size = new System.Drawing.Size(460, 319);
            this.tabSource.TabIndex = 0;
            this.tabSource.Text = "Source";
            this.tabSource.UseVisualStyleBackColor = true;
            // 
            // picSource
            // 
            this.picSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSource.Location = new System.Drawing.Point(3, 3);
            this.picSource.Name = "picSource";
            this.picSource.Size = new System.Drawing.Size(454, 313);
            this.picSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSource.TabIndex = 1;
            this.picSource.TabStop = false;
            // 
            // tabOptimized
            // 
            this.tabOptimized.Controls.Add(this.picOptimized);
            this.tabOptimized.Location = new System.Drawing.Point(4, 22);
            this.tabOptimized.Name = "tabOptimized";
            this.tabOptimized.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptimized.Size = new System.Drawing.Size(460, 319);
            this.tabOptimized.TabIndex = 1;
            this.tabOptimized.Text = "Optimized";
            this.tabOptimized.UseVisualStyleBackColor = true;
            // 
            // picOptimized
            // 
            this.picOptimized.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picOptimized.Location = new System.Drawing.Point(3, 3);
            this.picOptimized.Name = "picOptimized";
            this.picOptimized.Size = new System.Drawing.Size(454, 313);
            this.picOptimized.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOptimized.TabIndex = 2;
            this.picOptimized.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(50, 310);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(107, 23);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "Export Data";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblULA
            // 
            this.lblULA.AutoSize = true;
            this.lblULA.Location = new System.Drawing.Point(5, 207);
            this.lblULA.Name = "lblULA";
            this.lblULA.Size = new System.Drawing.Size(37, 13);
            this.lblULA.TabIndex = 14;
            this.lblULA.Text = "ULA+:";
            // 
            // pnlULA
            // 
            this.pnlULA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlULA.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlULA.ColumnCount = 4;
            this.pnlULA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlULA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlULA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlULA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlULA.Controls.Add(this.pnlULA15, 3, 3);
            this.pnlULA.Controls.Add(this.pnlULA14, 2, 3);
            this.pnlULA.Controls.Add(this.pnlULA13, 1, 3);
            this.pnlULA.Controls.Add(this.pnlULA12, 0, 3);
            this.pnlULA.Controls.Add(this.pnlULA11, 3, 2);
            this.pnlULA.Controls.Add(this.pnlULA10, 2, 2);
            this.pnlULA.Controls.Add(this.pnlULA9, 1, 2);
            this.pnlULA.Controls.Add(this.pnlULA8, 0, 2);
            this.pnlULA.Controls.Add(this.pnlULA7, 3, 1);
            this.pnlULA.Controls.Add(this.pnlULA6, 2, 1);
            this.pnlULA.Controls.Add(this.pnlULA5, 1, 1);
            this.pnlULA.Controls.Add(this.pnlULA4, 0, 1);
            this.pnlULA.Controls.Add(this.pnlULA3, 3, 0);
            this.pnlULA.Controls.Add(this.pnlULA2, 2, 0);
            this.pnlULA.Controls.Add(this.pnlULA1, 1, 0);
            this.pnlULA.Controls.Add(this.pnlULA0, 0, 0);
            this.pnlULA.Location = new System.Drawing.Point(49, 204);
            this.pnlULA.Margin = new System.Windows.Forms.Padding(1);
            this.pnlULA.Name = "pnlULA";
            this.pnlULA.RowCount = 4;
            this.pnlULA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlULA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlULA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlULA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlULA.Size = new System.Drawing.Size(108, 67);
            this.pnlULA.TabIndex = 13;
            // 
            // pnlULA15
            // 
            this.pnlULA15.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA15.Location = new System.Drawing.Point(82, 49);
            this.pnlULA15.Margin = new System.Windows.Forms.Padding(1);
            this.pnlULA15.Name = "pnlULA15";
            this.pnlULA15.Size = new System.Drawing.Size(25, 17);
            this.pnlULA15.TabIndex = 15;
            // 
            // pnlULA14
            // 
            this.pnlULA14.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA14.Location = new System.Drawing.Point(55, 49);
            this.pnlULA14.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.pnlULA14.Name = "pnlULA14";
            this.pnlULA14.Size = new System.Drawing.Size(26, 17);
            this.pnlULA14.TabIndex = 14;
            // 
            // pnlULA13
            // 
            this.pnlULA13.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA13.Location = new System.Drawing.Point(28, 49);
            this.pnlULA13.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.pnlULA13.Name = "pnlULA13";
            this.pnlULA13.Size = new System.Drawing.Size(26, 17);
            this.pnlULA13.TabIndex = 13;
            // 
            // pnlULA12
            // 
            this.pnlULA12.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA12.Location = new System.Drawing.Point(1, 49);
            this.pnlULA12.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.pnlULA12.Name = "pnlULA12";
            this.pnlULA12.Size = new System.Drawing.Size(26, 17);
            this.pnlULA12.TabIndex = 12;
            // 
            // pnlULA11
            // 
            this.pnlULA11.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA11.Location = new System.Drawing.Point(82, 33);
            this.pnlULA11.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.pnlULA11.Name = "pnlULA11";
            this.pnlULA11.Size = new System.Drawing.Size(25, 15);
            this.pnlULA11.TabIndex = 11;
            // 
            // pnlULA10
            // 
            this.pnlULA10.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA10.Location = new System.Drawing.Point(55, 33);
            this.pnlULA10.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlULA10.Name = "pnlULA10";
            this.pnlULA10.Size = new System.Drawing.Size(26, 15);
            this.pnlULA10.TabIndex = 10;
            // 
            // pnlULA9
            // 
            this.pnlULA9.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA9.Location = new System.Drawing.Point(28, 33);
            this.pnlULA9.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlULA9.Name = "pnlULA9";
            this.pnlULA9.Size = new System.Drawing.Size(26, 15);
            this.pnlULA9.TabIndex = 9;
            // 
            // pnlULA8
            // 
            this.pnlULA8.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA8.Location = new System.Drawing.Point(1, 33);
            this.pnlULA8.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlULA8.Name = "pnlULA8";
            this.pnlULA8.Size = new System.Drawing.Size(26, 15);
            this.pnlULA8.TabIndex = 8;
            // 
            // pnlULA7
            // 
            this.pnlULA7.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA7.Location = new System.Drawing.Point(82, 17);
            this.pnlULA7.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.pnlULA7.Name = "pnlULA7";
            this.pnlULA7.Size = new System.Drawing.Size(25, 15);
            this.pnlULA7.TabIndex = 7;
            // 
            // pnlULA6
            // 
            this.pnlULA6.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA6.Location = new System.Drawing.Point(55, 17);
            this.pnlULA6.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlULA6.Name = "pnlULA6";
            this.pnlULA6.Size = new System.Drawing.Size(26, 15);
            this.pnlULA6.TabIndex = 6;
            // 
            // pnlULA5
            // 
            this.pnlULA5.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA5.Location = new System.Drawing.Point(28, 17);
            this.pnlULA5.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlULA5.Name = "pnlULA5";
            this.pnlULA5.Size = new System.Drawing.Size(26, 15);
            this.pnlULA5.TabIndex = 5;
            // 
            // pnlULA4
            // 
            this.pnlULA4.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA4.Location = new System.Drawing.Point(1, 17);
            this.pnlULA4.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlULA4.Name = "pnlULA4";
            this.pnlULA4.Size = new System.Drawing.Size(26, 15);
            this.pnlULA4.TabIndex = 4;
            // 
            // pnlULA3
            // 
            this.pnlULA3.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA3.Location = new System.Drawing.Point(82, 1);
            this.pnlULA3.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.pnlULA3.Name = "pnlULA3";
            this.pnlULA3.Size = new System.Drawing.Size(25, 15);
            this.pnlULA3.TabIndex = 3;
            // 
            // pnlULA2
            // 
            this.pnlULA2.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA2.Location = new System.Drawing.Point(55, 1);
            this.pnlULA2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlULA2.Name = "pnlULA2";
            this.pnlULA2.Size = new System.Drawing.Size(26, 15);
            this.pnlULA2.TabIndex = 2;
            // 
            // pnlULA1
            // 
            this.pnlULA1.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA1.Location = new System.Drawing.Point(28, 1);
            this.pnlULA1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlULA1.Name = "pnlULA1";
            this.pnlULA1.Size = new System.Drawing.Size(26, 15);
            this.pnlULA1.TabIndex = 1;
            // 
            // pnlULA0
            // 
            this.pnlULA0.BackColor = System.Drawing.SystemColors.Control;
            this.pnlULA0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlULA0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlULA0.Location = new System.Drawing.Point(1, 1);
            this.pnlULA0.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlULA0.Name = "pnlULA0";
            this.pnlULA0.Size = new System.Drawing.Size(26, 15);
            this.pnlULA0.TabIndex = 0;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(5, 119);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(44, 13);
            this.lblSource.TabIndex = 12;
            this.lblSource.Text = "Source:";
            // 
            // lblUnique
            // 
            this.lblUnique.AutoSize = true;
            this.lblUnique.Location = new System.Drawing.Point(5, 187);
            this.lblUnique.Name = "lblUnique";
            this.lblUnique.Size = new System.Drawing.Size(44, 13);
            this.lblUnique.TabIndex = 11;
            this.lblUnique.Text = "Unique:";
            // 
            // lblUniqueVal
            // 
            this.lblUniqueVal.Location = new System.Drawing.Point(49, 187);
            this.lblUniqueVal.Margin = new System.Windows.Forms.Padding(3);
            this.lblUniqueVal.Name = "lblUniqueVal";
            this.lblUniqueVal.Size = new System.Drawing.Size(108, 13);
            this.lblUniqueVal.TabIndex = 10;
            this.lblUniqueVal.Text = "0";
            this.lblUniqueVal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculate.Location = new System.Drawing.Point(50, 281);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(107, 23);
            this.btnCalculate.TabIndex = 9;
            this.btnCalculate.Text = "Optimize Palette";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // pnlSource
            // 
            this.pnlSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSource.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlSource.ColumnCount = 4;
            this.pnlSource.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSource.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSource.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSource.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSource.Controls.Add(this.pnlCol15, 3, 3);
            this.pnlSource.Controls.Add(this.pnlCol14, 2, 3);
            this.pnlSource.Controls.Add(this.pnlCol13, 1, 3);
            this.pnlSource.Controls.Add(this.pnlCol12, 0, 3);
            this.pnlSource.Controls.Add(this.pnlCol11, 3, 2);
            this.pnlSource.Controls.Add(this.pnlCol10, 2, 2);
            this.pnlSource.Controls.Add(this.pnlCol9, 1, 2);
            this.pnlSource.Controls.Add(this.pnlCol8, 0, 2);
            this.pnlSource.Controls.Add(this.pnlCol7, 3, 1);
            this.pnlSource.Controls.Add(this.pnlCol6, 2, 1);
            this.pnlSource.Controls.Add(this.pnlCol5, 1, 1);
            this.pnlSource.Controls.Add(this.pnlCol4, 0, 1);
            this.pnlSource.Controls.Add(this.pnlCol3, 3, 0);
            this.pnlSource.Controls.Add(this.pnlCol2, 2, 0);
            this.pnlSource.Controls.Add(this.pnlCol1, 1, 0);
            this.pnlSource.Controls.Add(this.pnlCol0, 0, 0);
            this.pnlSource.Location = new System.Drawing.Point(49, 116);
            this.pnlSource.Margin = new System.Windows.Forms.Padding(1);
            this.pnlSource.Name = "pnlSource";
            this.pnlSource.RowCount = 4;
            this.pnlSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlSource.Size = new System.Drawing.Size(108, 67);
            this.pnlSource.TabIndex = 8;
            // 
            // pnlCol15
            // 
            this.pnlCol15.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol15.Location = new System.Drawing.Point(82, 49);
            this.pnlCol15.Margin = new System.Windows.Forms.Padding(1);
            this.pnlCol15.Name = "pnlCol15";
            this.pnlCol15.Size = new System.Drawing.Size(25, 17);
            this.pnlCol15.TabIndex = 15;
            // 
            // pnlCol14
            // 
            this.pnlCol14.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol14.Location = new System.Drawing.Point(55, 49);
            this.pnlCol14.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.pnlCol14.Name = "pnlCol14";
            this.pnlCol14.Size = new System.Drawing.Size(26, 17);
            this.pnlCol14.TabIndex = 14;
            // 
            // pnlCol13
            // 
            this.pnlCol13.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol13.Location = new System.Drawing.Point(28, 49);
            this.pnlCol13.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.pnlCol13.Name = "pnlCol13";
            this.pnlCol13.Size = new System.Drawing.Size(26, 17);
            this.pnlCol13.TabIndex = 13;
            // 
            // pnlCol12
            // 
            this.pnlCol12.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol12.Location = new System.Drawing.Point(1, 49);
            this.pnlCol12.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.pnlCol12.Name = "pnlCol12";
            this.pnlCol12.Size = new System.Drawing.Size(26, 17);
            this.pnlCol12.TabIndex = 12;
            // 
            // pnlCol11
            // 
            this.pnlCol11.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol11.Location = new System.Drawing.Point(82, 33);
            this.pnlCol11.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.pnlCol11.Name = "pnlCol11";
            this.pnlCol11.Size = new System.Drawing.Size(25, 15);
            this.pnlCol11.TabIndex = 11;
            // 
            // pnlCol10
            // 
            this.pnlCol10.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol10.Location = new System.Drawing.Point(55, 33);
            this.pnlCol10.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlCol10.Name = "pnlCol10";
            this.pnlCol10.Size = new System.Drawing.Size(26, 15);
            this.pnlCol10.TabIndex = 10;
            // 
            // pnlCol9
            // 
            this.pnlCol9.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol9.Location = new System.Drawing.Point(28, 33);
            this.pnlCol9.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlCol9.Name = "pnlCol9";
            this.pnlCol9.Size = new System.Drawing.Size(26, 15);
            this.pnlCol9.TabIndex = 9;
            // 
            // pnlCol8
            // 
            this.pnlCol8.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol8.Location = new System.Drawing.Point(1, 33);
            this.pnlCol8.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlCol8.Name = "pnlCol8";
            this.pnlCol8.Size = new System.Drawing.Size(26, 15);
            this.pnlCol8.TabIndex = 8;
            // 
            // pnlCol7
            // 
            this.pnlCol7.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol7.Location = new System.Drawing.Point(82, 17);
            this.pnlCol7.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.pnlCol7.Name = "pnlCol7";
            this.pnlCol7.Size = new System.Drawing.Size(25, 15);
            this.pnlCol7.TabIndex = 7;
            // 
            // pnlCol6
            // 
            this.pnlCol6.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol6.Location = new System.Drawing.Point(55, 17);
            this.pnlCol6.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlCol6.Name = "pnlCol6";
            this.pnlCol6.Size = new System.Drawing.Size(26, 15);
            this.pnlCol6.TabIndex = 6;
            // 
            // pnlCol5
            // 
            this.pnlCol5.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol5.Location = new System.Drawing.Point(28, 17);
            this.pnlCol5.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlCol5.Name = "pnlCol5";
            this.pnlCol5.Size = new System.Drawing.Size(26, 15);
            this.pnlCol5.TabIndex = 5;
            // 
            // pnlCol4
            // 
            this.pnlCol4.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol4.Location = new System.Drawing.Point(1, 17);
            this.pnlCol4.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlCol4.Name = "pnlCol4";
            this.pnlCol4.Size = new System.Drawing.Size(26, 15);
            this.pnlCol4.TabIndex = 4;
            // 
            // pnlCol3
            // 
            this.pnlCol3.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol3.Location = new System.Drawing.Point(82, 1);
            this.pnlCol3.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.pnlCol3.Name = "pnlCol3";
            this.pnlCol3.Size = new System.Drawing.Size(25, 15);
            this.pnlCol3.TabIndex = 3;
            // 
            // pnlCol2
            // 
            this.pnlCol2.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol2.Location = new System.Drawing.Point(55, 1);
            this.pnlCol2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlCol2.Name = "pnlCol2";
            this.pnlCol2.Size = new System.Drawing.Size(26, 15);
            this.pnlCol2.TabIndex = 2;
            // 
            // pnlCol1
            // 
            this.pnlCol1.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol1.Location = new System.Drawing.Point(28, 1);
            this.pnlCol1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlCol1.Name = "pnlCol1";
            this.pnlCol1.Size = new System.Drawing.Size(26, 15);
            this.pnlCol1.TabIndex = 1;
            // 
            // pnlCol0
            // 
            this.pnlCol0.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCol0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCol0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCol0.Location = new System.Drawing.Point(1, 1);
            this.pnlCol0.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.pnlCol0.Name = "pnlCol0";
            this.pnlCol0.Size = new System.Drawing.Size(26, 15);
            this.pnlCol0.TabIndex = 0;
            // 
            // lblClut
            // 
            this.lblClut.AutoSize = true;
            this.lblClut.Location = new System.Drawing.Point(5, 92);
            this.lblClut.Name = "lblClut";
            this.lblClut.Size = new System.Drawing.Size(38, 13);
            this.lblClut.TabIndex = 7;
            this.lblClut.Text = "CLUT:";
            // 
            // cboClut
            // 
            this.cboClut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboClut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClut.FormattingEnabled = true;
            this.cboClut.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cboClut.Location = new System.Drawing.Point(49, 89);
            this.cboClut.Name = "cboClut";
            this.cboClut.Size = new System.Drawing.Size(108, 21);
            this.cboClut.TabIndex = 6;
            this.cboClut.SelectedIndexChanged += new System.EventHandler(this.cboClut_SelectedIndexChanged);
            // 
            // numHeight
            // 
            this.numHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numHeight.Location = new System.Drawing.Point(49, 63);
            this.numHeight.Maximum = new decimal(new int[] {
            96,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(108, 20);
            this.numHeight.TabIndex = 5;
            this.numHeight.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            this.numHeight.ValueChanged += new System.EventHandler(this.numHeight_ValueChanged);
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(5, 65);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(41, 13);
            this.lblHeight.TabIndex = 4;
            this.lblHeight.Text = "Height:";
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.Location = new System.Drawing.Point(5, 39);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(35, 13);
            this.lblZone.TabIndex = 3;
            this.lblZone.Text = "Zone:";
            // 
            // cboZone
            // 
            this.cboZone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZone.FormattingEnabled = true;
            this.cboZone.Items.AddRange(new object[] {
            "1"});
            this.cboZone.Location = new System.Drawing.Point(49, 36);
            this.cboZone.Name = "cboZone";
            this.cboZone.Size = new System.Drawing.Size(108, 21);
            this.cboZone.TabIndex = 2;
            this.cboZone.SelectedIndexChanged += new System.EventHandler(this.cboZone_SelectedIndexChanged);
            // 
            // numZones
            // 
            this.numZones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numZones.Location = new System.Drawing.Point(49, 10);
            this.numZones.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numZones.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numZones.Name = "numZones";
            this.numZones.Size = new System.Drawing.Size(108, 20);
            this.numZones.TabIndex = 1;
            this.numZones.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numZones.ValueChanged += new System.EventHandler(this.numZones_ValueChanged);
            // 
            // lblZones
            // 
            this.lblZones.AutoSize = true;
            this.lblZones.Location = new System.Drawing.Point(5, 12);
            this.lblZones.Name = "lblZones";
            this.lblZones.Size = new System.Drawing.Size(40, 13);
            this.lblZones.TabIndex = 0;
            this.lblZones.Text = "Zones:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 369);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Radastan Zone Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlMain.Panel1.ResumeLayout(false);
            this.pnlMain.Panel2.ResumeLayout(false);
            this.pnlMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.tabImage.ResumeLayout(false);
            this.tabSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).EndInit();
            this.tabOptimized.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOptimized)).EndInit();
            this.pnlULA.ResumeLayout(false);
            this.pnlSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.OpenFileDialog dlgFileOpen;
    private RadastanPictureBox picSource;
    private System.Windows.Forms.SplitContainer pnlMain;
    private System.Windows.Forms.NumericUpDown numZones;
    private System.Windows.Forms.Label lblZones;
    private System.Windows.Forms.Label lblZone;
    private System.Windows.Forms.ComboBox cboZone;
    private System.Windows.Forms.NumericUpDown numHeight;
    private System.Windows.Forms.Label lblHeight;
    private System.Windows.Forms.Label lblClut;
    private System.Windows.Forms.ComboBox cboClut;
    private System.Windows.Forms.TableLayoutPanel pnlSource;
    private System.Windows.Forms.Panel pnlCol0;
    private System.Windows.Forms.Panel pnlCol15;
    private System.Windows.Forms.Panel pnlCol14;
    private System.Windows.Forms.Panel pnlCol13;
    private System.Windows.Forms.Panel pnlCol12;
    private System.Windows.Forms.Panel pnlCol11;
    private System.Windows.Forms.Panel pnlCol10;
    private System.Windows.Forms.Panel pnlCol9;
    private System.Windows.Forms.Panel pnlCol8;
    private System.Windows.Forms.Panel pnlCol7;
    private System.Windows.Forms.Panel pnlCol6;
    private System.Windows.Forms.Panel pnlCol5;
    private System.Windows.Forms.Panel pnlCol4;
    private System.Windows.Forms.Panel pnlCol3;
    private System.Windows.Forms.Panel pnlCol2;
    private System.Windows.Forms.Panel pnlCol1;
    private System.Windows.Forms.Button btnCalculate;
    private System.Windows.Forms.Label lblUnique;
    private System.Windows.Forms.Label lblUniqueVal;
    private System.Windows.Forms.Label lblSource;
    private System.Windows.Forms.Label lblULA;
    private System.Windows.Forms.TableLayoutPanel pnlULA;
    private System.Windows.Forms.Panel pnlULA15;
    private System.Windows.Forms.Panel pnlULA14;
    private System.Windows.Forms.Panel pnlULA13;
    private System.Windows.Forms.Panel pnlULA12;
    private System.Windows.Forms.Panel pnlULA11;
    private System.Windows.Forms.Panel pnlULA10;
    private System.Windows.Forms.Panel pnlULA9;
    private System.Windows.Forms.Panel pnlULA8;
    private System.Windows.Forms.Panel pnlULA7;
    private System.Windows.Forms.Panel pnlULA6;
    private System.Windows.Forms.Panel pnlULA5;
    private System.Windows.Forms.Panel pnlULA4;
    private System.Windows.Forms.Panel pnlULA3;
    private System.Windows.Forms.Panel pnlULA2;
    private System.Windows.Forms.Panel pnlULA1;
    private System.Windows.Forms.Panel pnlULA0;
    private System.Windows.Forms.TabControl tabImage;
    private System.Windows.Forms.TabPage tabSource;
    private System.Windows.Forms.TabPage tabOptimized;
    private RadastanPictureBox picOptimized;
    private System.Windows.Forms.Button btnExport;
  }
}

