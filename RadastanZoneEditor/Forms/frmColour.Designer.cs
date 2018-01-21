namespace RadastanZoneEditor.Forms
{
  partial class frmColour
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
      this.pnlColours = new System.Windows.Forms.TableLayoutPanel();
      this.pnlOriginal = new System.Windows.Forms.Panel();
      this.pnlNew = new System.Windows.Forms.Panel();
      this.trkRed = new System.Windows.Forms.TrackBar();
      this.trackBar1 = new System.Windows.Forms.TrackBar();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.trkGreen = new System.Windows.Forms.TrackBar();
      this.label3 = new System.Windows.Forms.Label();
      this.trkBlue = new System.Windows.Forms.TrackBar();
      this.trackBar4 = new System.Windows.Forms.TrackBar();
      this.lblBlue = new System.Windows.Forms.Label();
      this.lblGreen = new System.Windows.Forms.Label();
      this.lblRed = new System.Windows.Forms.Label();
      this.lblValue = new System.Windows.Forms.Label();
      this.lblSaturation = new System.Windows.Forms.Label();
      this.lblHue = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.trkValue = new System.Windows.Forms.TrackBar();
      this.label11 = new System.Windows.Forms.Label();
      this.trkSaturation = new System.Windows.Forms.TrackBar();
      this.label12 = new System.Windows.Forms.Label();
      this.trkHue = new System.Windows.Forms.TrackBar();
      this.pnlColours.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trkRed)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkGreen)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkBlue)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkValue)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkSaturation)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkHue)).BeginInit();
      this.SuspendLayout();
      // 
      // pnlColours
      // 
      this.pnlColours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlColours.AutoSize = true;
      this.pnlColours.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
      this.pnlColours.ColumnCount = 1;
      this.pnlColours.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.pnlColours.Controls.Add(this.pnlOriginal, 0, 1);
      this.pnlColours.Controls.Add(this.pnlNew, 0, 0);
      this.pnlColours.Location = new System.Drawing.Point(194, 12);
      this.pnlColours.Name = "pnlColours";
      this.pnlColours.RowCount = 2;
      this.pnlColours.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.pnlColours.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.pnlColours.Size = new System.Drawing.Size(87, 173);
      this.pnlColours.TabIndex = 0;
      // 
      // pnlOriginal
      // 
      this.pnlOriginal.AutoSize = true;
      this.pnlOriginal.Cursor = System.Windows.Forms.Cursors.Hand;
      this.pnlOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlOriginal.Location = new System.Drawing.Point(1, 87);
      this.pnlOriginal.Margin = new System.Windows.Forms.Padding(0);
      this.pnlOriginal.MaximumSize = new System.Drawing.Size(85, 85);
      this.pnlOriginal.MinimumSize = new System.Drawing.Size(85, 85);
      this.pnlOriginal.Name = "pnlOriginal";
      this.pnlOriginal.Size = new System.Drawing.Size(85, 85);
      this.pnlOriginal.TabIndex = 1;
      this.pnlOriginal.Click += new System.EventHandler(this.pnlOriginal_Click);
      // 
      // pnlNew
      // 
      this.pnlNew.AutoSize = true;
      this.pnlNew.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlNew.Location = new System.Drawing.Point(1, 1);
      this.pnlNew.Margin = new System.Windows.Forms.Padding(0);
      this.pnlNew.MaximumSize = new System.Drawing.Size(85, 85);
      this.pnlNew.MinimumSize = new System.Drawing.Size(85, 85);
      this.pnlNew.Name = "pnlNew";
      this.pnlNew.Size = new System.Drawing.Size(85, 85);
      this.pnlNew.TabIndex = 0;
      // 
      // trkRed
      // 
      this.trkRed.AutoSize = false;
      this.trkRed.LargeChange = 1;
      this.trkRed.Location = new System.Drawing.Point(24, 12);
      this.trkRed.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
      this.trkRed.Maximum = 7;
      this.trkRed.Name = "trkRed";
      this.trkRed.Size = new System.Drawing.Size(142, 28);
      this.trkRed.TabIndex = 0;
      this.trkRed.ValueChanged += new System.EventHandler(this.trkRed_ValueChanged);
      // 
      // trackBar1
      // 
      this.trackBar1.AutoSize = false;
      this.trackBar1.LargeChange = 1;
      this.trackBar1.Location = new System.Drawing.Point(12, 50);
      this.trackBar1.Maximum = 7;
      this.trackBar1.Name = "trackBar1";
      this.trackBar1.Size = new System.Drawing.Size(0, 0);
      this.trackBar1.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(9, 7);
      this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(15, 28);
      this.label1.TabIndex = 2;
      this.label1.Text = "R";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(9, 33);
      this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(15, 28);
      this.label2.TabIndex = 4;
      this.label2.Text = "G";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // trkGreen
      // 
      this.trkGreen.AutoSize = false;
      this.trkGreen.LargeChange = 1;
      this.trkGreen.Location = new System.Drawing.Point(24, 38);
      this.trkGreen.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.trkGreen.Maximum = 7;
      this.trkGreen.Name = "trkGreen";
      this.trkGreen.Size = new System.Drawing.Size(142, 28);
      this.trkGreen.TabIndex = 3;
      this.trkGreen.ValueChanged += new System.EventHandler(this.trkGreen_ValueChanged);
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(9, 59);
      this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(15, 28);
      this.label3.TabIndex = 7;
      this.label3.Text = "B";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // trkBlue
      // 
      this.trkBlue.AutoSize = false;
      this.trkBlue.LargeChange = 1;
      this.trkBlue.Location = new System.Drawing.Point(24, 64);
      this.trkBlue.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.trkBlue.Maximum = 3;
      this.trkBlue.Name = "trkBlue";
      this.trkBlue.Size = new System.Drawing.Size(142, 28);
      this.trkBlue.TabIndex = 6;
      this.trkBlue.ValueChanged += new System.EventHandler(this.trkBlue_ValueChanged);
      // 
      // trackBar4
      // 
      this.trackBar4.AutoSize = false;
      this.trackBar4.LargeChange = 1;
      this.trackBar4.Location = new System.Drawing.Point(12, 74);
      this.trackBar4.Maximum = 7;
      this.trackBar4.Name = "trackBar4";
      this.trackBar4.Size = new System.Drawing.Size(0, 0);
      this.trackBar4.TabIndex = 5;
      // 
      // lblBlue
      // 
      this.lblBlue.Location = new System.Drawing.Point(161, 59);
      this.lblBlue.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.lblBlue.Name = "lblBlue";
      this.lblBlue.Size = new System.Drawing.Size(29, 28);
      this.lblBlue.TabIndex = 10;
      this.lblBlue.Text = "0";
      this.lblBlue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblGreen
      // 
      this.lblGreen.Location = new System.Drawing.Point(161, 33);
      this.lblGreen.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.lblGreen.Name = "lblGreen";
      this.lblGreen.Size = new System.Drawing.Size(29, 28);
      this.lblGreen.TabIndex = 9;
      this.lblGreen.Text = "0";
      this.lblGreen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblRed
      // 
      this.lblRed.Location = new System.Drawing.Point(161, 7);
      this.lblRed.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.lblRed.Name = "lblRed";
      this.lblRed.Size = new System.Drawing.Size(29, 28);
      this.lblRed.TabIndex = 8;
      this.lblRed.Text = "0";
      this.lblRed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblValue
      // 
      this.lblValue.Location = new System.Drawing.Point(161, 147);
      this.lblValue.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.lblValue.Name = "lblValue";
      this.lblValue.Size = new System.Drawing.Size(53, 28);
      this.lblValue.TabIndex = 19;
      this.lblValue.Text = "0%";
      this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.lblValue.Visible = false;
      // 
      // lblSaturation
      // 
      this.lblSaturation.Location = new System.Drawing.Point(161, 121);
      this.lblSaturation.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.lblSaturation.Name = "lblSaturation";
      this.lblSaturation.Size = new System.Drawing.Size(53, 28);
      this.lblSaturation.TabIndex = 18;
      this.lblSaturation.Text = "0%";
      this.lblSaturation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.lblSaturation.Visible = false;
      // 
      // lblHue
      // 
      this.lblHue.Location = new System.Drawing.Point(161, 95);
      this.lblHue.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.lblHue.Name = "lblHue";
      this.lblHue.Size = new System.Drawing.Size(53, 28);
      this.lblHue.TabIndex = 17;
      this.lblHue.Text = "0°";
      this.lblHue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.lblHue.Visible = false;
      // 
      // label10
      // 
      this.label10.Location = new System.Drawing.Point(9, 147);
      this.label10.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(15, 28);
      this.label10.TabIndex = 16;
      this.label10.Text = "V";
      this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.label10.Visible = false;
      // 
      // trkValue
      // 
      this.trkValue.AutoSize = false;
      this.trkValue.LargeChange = 10;
      this.trkValue.Location = new System.Drawing.Point(24, 152);
      this.trkValue.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.trkValue.Maximum = 100;
      this.trkValue.Name = "trkValue";
      this.trkValue.Size = new System.Drawing.Size(142, 28);
      this.trkValue.TabIndex = 15;
      this.trkValue.TickFrequency = 10;
      this.trkValue.Visible = false;
      this.trkValue.ValueChanged += new System.EventHandler(this.trkValue_ValueChanged);
      // 
      // label11
      // 
      this.label11.Location = new System.Drawing.Point(9, 121);
      this.label11.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(15, 28);
      this.label11.TabIndex = 14;
      this.label11.Text = "S";
      this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.label11.Visible = false;
      // 
      // trkSaturation
      // 
      this.trkSaturation.AutoSize = false;
      this.trkSaturation.LargeChange = 10;
      this.trkSaturation.Location = new System.Drawing.Point(24, 126);
      this.trkSaturation.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.trkSaturation.Maximum = 100;
      this.trkSaturation.Name = "trkSaturation";
      this.trkSaturation.Size = new System.Drawing.Size(142, 28);
      this.trkSaturation.TabIndex = 13;
      this.trkSaturation.TickFrequency = 10;
      this.trkSaturation.Visible = false;
      this.trkSaturation.ValueChanged += new System.EventHandler(this.trkSaturation_ValueChanged);
      // 
      // label12
      // 
      this.label12.Location = new System.Drawing.Point(9, 95);
      this.label12.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(15, 28);
      this.label12.TabIndex = 12;
      this.label12.Text = "H";
      this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.label12.Visible = false;
      // 
      // trkHue
      // 
      this.trkHue.AutoSize = false;
      this.trkHue.LargeChange = 10;
      this.trkHue.Location = new System.Drawing.Point(24, 100);
      this.trkHue.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
      this.trkHue.Maximum = 360;
      this.trkHue.Name = "trkHue";
      this.trkHue.Size = new System.Drawing.Size(142, 28);
      this.trkHue.TabIndex = 11;
      this.trkHue.TickFrequency = 60;
      this.trkHue.Visible = false;
      this.trkHue.ValueChanged += new System.EventHandler(this.trkHue_ValueChanged);
      // 
      // frmColour
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(293, 197);
      this.Controls.Add(this.pnlColours);
      this.Controls.Add(this.lblValue);
      this.Controls.Add(this.lblSaturation);
      this.Controls.Add(this.lblHue);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.trkValue);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.trkSaturation);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.trkHue);
      this.Controls.Add(this.lblBlue);
      this.Controls.Add(this.lblGreen);
      this.Controls.Add(this.lblRed);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.trkBlue);
      this.Controls.Add(this.trackBar4);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.trkGreen);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.trackBar1);
      this.Controls.Add(this.trkRed);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "frmColour";
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Edit ULAplus Colour";
      this.TopMost = true;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmColour_FormClosing);
      this.pnlColours.ResumeLayout(false);
      this.pnlColours.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trkRed)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkGreen)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkBlue)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkValue)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkSaturation)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trkHue)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel pnlColours;
    private System.Windows.Forms.Panel pnlOriginal;
    private System.Windows.Forms.Panel pnlNew;
    private System.Windows.Forms.TrackBar trkRed;
    private System.Windows.Forms.TrackBar trackBar1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TrackBar trkGreen;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TrackBar trkBlue;
    private System.Windows.Forms.TrackBar trackBar4;
    private System.Windows.Forms.Label lblBlue;
    private System.Windows.Forms.Label lblGreen;
    private System.Windows.Forms.Label lblRed;
    private System.Windows.Forms.Label lblValue;
    private System.Windows.Forms.Label lblSaturation;
    private System.Windows.Forms.Label lblHue;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TrackBar trkValue;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TrackBar trkSaturation;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TrackBar trkHue;
  }
}