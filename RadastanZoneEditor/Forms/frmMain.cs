using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using RadastanZoneEditor.Classes;

namespace RadastanZoneEditor.Forms
{
  public partial class frmMain : Form
  {
    private Zones zones;
    private Panel[] sourceColours;
    private Panel[] ulaPlusColours;
    private bool settingUp = true;
    private string fileName = "";
    private bool dirty = false;

    public frmMain(string[] args)
    {
      InitializeComponent();
      zones = new Zones(true);
      picSource.Zones = zones;
      cboClut.Items.Clear();
      cboClut.Items.Add(0);
      cboClut.Items.Add(1);
      cboClut.Items.Add(2);
      cboClut.Items.Add(3);
      cboClut.Items.Add("None");
      cboClut.SelectedIndex = 0;
      sourceColours = new Panel[16];
      sourceColours[0] = pnlCol0;
      sourceColours[1] = pnlCol1;
      sourceColours[2] = pnlCol2;
      sourceColours[3] = pnlCol3;
      sourceColours[4] = pnlCol4;
      sourceColours[5] = pnlCol5;
      sourceColours[6] = pnlCol6;
      sourceColours[7] = pnlCol7;
      sourceColours[8] = pnlCol8;
      sourceColours[9] = pnlCol9;
      sourceColours[10] = pnlCol10;
      sourceColours[11] = pnlCol11;
      sourceColours[12] = pnlCol12;
      sourceColours[13] = pnlCol13;
      sourceColours[14] = pnlCol14;
      sourceColours[15] = pnlCol15;
      ulaPlusColours = new Panel[16];
      ulaPlusColours[0] = pnlULA0;
      ulaPlusColours[1] = pnlULA1;
      ulaPlusColours[2] = pnlULA2;
      ulaPlusColours[3] = pnlULA3;
      ulaPlusColours[4] = pnlULA4;
      ulaPlusColours[5] = pnlULA5;
      ulaPlusColours[6] = pnlULA6;
      ulaPlusColours[7] = pnlULA7;
      ulaPlusColours[8] = pnlULA8;
      ulaPlusColours[9] = pnlULA9;
      ulaPlusColours[10] = pnlULA10;
      ulaPlusColours[11] = pnlULA11;
      ulaPlusColours[12] = pnlULA12;
      ulaPlusColours[13] = pnlULA13;
      ulaPlusColours[14] = pnlULA14;
      ulaPlusColours[15] = pnlULA15;
      settingUp = false;
      if (args.Length >= 1 && !string.IsNullOrWhiteSpace(args[0]))
        Open((args[0] ?? "").Trim());
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var res = dlgFileOpen.ShowDialog();
      if (res != DialogResult.OK)
        return;
      Open(dlgFileOpen.FileName);
    }

    private void Open(string FileName)
    {
      var z = Zones.Open(FileName, picSource);
      if (z == null) return;
      fileName = FileName;
      zones = z;
      bool zo = zones.Optimized;
      saveToolStripMenuItem.Enabled = true;
      closeToolStripMenuItem.Enabled = true;
      pnlMain.Panel2.Enabled = true;
      settingUp = true;
      numZones.Value = zones.Items.Count;
      numZone.Maximum = zones.Items.Count;
      settingUp = false;
      numZone.Value = zones.CurrentZone;
      numZones_ValueChanged(numZones, new EventArgs());
      numZone_ValueChanged(numZone, new EventArgs());
      zones.Optimized = zo;
      if (zones.Optimized)
        btnCalculate_Click(btnCalculate, new EventArgs());
      dirty = false;
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private int Quantize(Color Colour)
    {
      int r = Convert.ToInt32(Math.Min(Math.Round(Convert.ToDouble(Colour.R) / 32, 0), 7));
      int g = Convert.ToInt32(Math.Min(Math.Round(Convert.ToDouble(Colour.G) / 32, 0), 7));
      int b = Convert.ToInt32(Math.Min(Math.Round(Convert.ToDouble(Colour.B) / 64, 0), 3));
      int rv = b + (r * 4) + (g * 32);
      return rv;
    }

    private void numZones_ValueChanged(object sender, EventArgs e)
    {
      int zone = Convert.ToInt32(numZone.Value);
      while (zones.Items.Count > numZones.Value)
      {
        zones.Items.Remove(zones.Items[zones.Items.Count - 1]);
      }
      while (zones.Items.Count < numZones.Value)
      {
        var z = new Zone(zones);
        zones.Items.Add(z);
        z.CLUT = z.DefaultCLUT;
        zones.RecalculateHeights();
      }
      if (numZone.Value > numZones.Value)
        numZone.Value = numZones.Value;
      numZone.Maximum = numZones.Value;
      numZone_ValueChanged(numZone, new EventArgs());
      Recalculate();
    }

    private void numZone_ValueChanged(object sender, EventArgs e)
    {
      if (settingUp) return;
      int zoneval = Convert.ToInt32(numZone.Value);
      zones.CurrentZone = zoneval;
      var zone = zones.Items[zoneval - 1];
      settingUp = true;
      numHeight.Value = zone.Height;
      numHeight.Enabled = !zone.IsLastZone;
      cboClut.SelectedIndex = zone.CLUTToIndex(zone.CLUT);
      settingUp = false;
      if (zone.CLUT >= 0)
      {
        var clut = zones.Palette.CLUTs[zone.CLUT];
        for (int i = 0; i < 16; i++)
          sourceColours[i].BackColor = clut.Colours[i].OriginalRGB;
        for (int i = 0; i < 16; i++)
          ulaPlusColours[i].BackColor = clut.Colours[i].ULAplusRGB;
      }
      cboClut_SelectedIndexChanged(cboClut, new EventArgs());
      Recalculate();
    }

    private void numHeight_ValueChanged(object sender, EventArgs e)
    {
      if (settingUp) return;
      int zoneval = Convert.ToInt32(numZone.Value);
      var zone = zones.Items[zoneval - 1];
      zone.Height = Convert.ToInt32(numHeight.Value);
      Recalculate();
    }

    private void cboClut_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (settingUp) return;
      int zoneval = Convert.ToInt32(numZone.Value);
      var zone = zones.Items[zoneval - 1];
      zone.CLUT = zone.IndexToCLUT(cboClut.SelectedIndex);
      if (zone.CLUT >= 0)
      {
        var clut = zones.Palette.CLUTs[zone.CLUT];
        for (int i = 0; i < 16; i++)
          sourceColours[i].BackColor = clut.Colours[i].OriginalRGB;
        for (int i = 0; i < 16; i++)
          ulaPlusColours[i].BackColor = clut.Colours[i].ULAplusRGB;
        lblUniqueVal.Text = clut.OriginalColourCount.ToString();
        lblUniqueVal.ForeColor = clut.OriginalColourCount > 16 ? Color.Red : SystemColors.ControlText;
      }
      Recalculate();
    }

    private void btnCalculate_Click(object sender, EventArgs e)
    {
      int zoneval = Convert.ToInt32(numZone.Value);
      var zone = zones.Items[zoneval - 1];
      zone.CLUT = zone.IndexToCLUT(cboClut.SelectedIndex);
      for (int CLUTid = 0; CLUTid < 4; CLUTid++)
      {
        var bmp = zones.GetCombinedBitmapForCLUT(picSource.Image, CLUTid);
        if (bmp == null) continue;
        //bmp.Save(fileName.Replace(".png", "-clut-" + CLUTid + ".png"));
        zones.SetCLUTFromBitmap(bmp, CLUTid);
      }
      cboClut_SelectedIndexChanged(cboClut, new EventArgs());
      var src = picSource.Image as Bitmap;
      var rect = new Rectangle(0, 0, src.Width, src.Height);
      var dest = src.Clone(rect, src.PixelFormat);
      picOptimized.Image = dest;
      picOptimized.Zones = zones;
      tabImage.SelectedTab = tabOptimized;
      var pal = src.Palette;
      for (int i = 0; i < src.Palette.Entries.Length; i++)
      {
        var srccol = src.Palette.Entries[i];
        var destcol = zones.Palette.GetUlaPlusColour(srccol);
        pal.Entries[i] = destcol;
      }
      picOptimized.Image.Palette = pal;
      picOptimized.Invalidate(true);
      zones.Optimized = true;
      btnExport.Enabled = zones.Optimized;
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      var img = picOptimized.Image;
      var bmp = img as Bitmap;
      var pal = img.Palette;
      var exportImage = new List<byte>();
      var dic = new Dictionary<int, int>();
      string filename2 = fileName.Replace(".png", "-optimized.png");
      picOptimized.Image.Save(filename2);

      int y = 0;
      foreach (var zone in zones.Items)
      {
        CLUT clut = null;
        if (zone.CLUT >= 0)
          clut = zones.Palette.CLUTs[zone.CLUT];
        for (int y1 = 0; y1 < zone.Height; y1++)
        {
          if (zone.CLUT >= 0)
          {
            int x = 0;
            for (int x2 = 0; x2 < (img.Width / 2); x2++)
            {
              var colL = bmp.GetPixel(x, y);
              var ulaL = clut.GetColourFromULAplusRGB(colL);
              x++;
              var colR = bmp.GetPixel(x, y);
              var ulaR = clut.GetColourFromULAplusRGB(colR);
              x++;

              byte b = clut.GetRadastanColourByte(ulaL, ulaR);
              exportImage.Add(b);
            }
          }
          y++;
        }
      }

      string filename3 = fileName.Replace(".png", ".radscr");
      File.WriteAllBytes(filename3, exportImage.ToArray());

      var sb = new StringBuilder();
      int line = 0;
      for (int i = 0; i < zones.Items.Count; i++)
      {
        line += zones.Items[i].Height * 2;
        sb.Append("; Zone ");
        sb.Append(i);
        sb.Append(": RASTERCTRL line ");
        sb.AppendLine(line.ToString());
      }
      sb.AppendLine();
      for (int i = 0; i < 4; i++)
      {
        var clut = zones.Palette.CLUTs[i];
        sb.Append("; CLUT ");
        sb.Append(i);
        sb.Append(" (");
        sb.Append(zones.GetZoneDescription(i));
        sb.Append(") - ");
        sb.AppendLine(clut.HexString);
        sb.Append("  db ");
        string join = "";
        foreach (var col in clut.Colours)
        {
          sb.Append(join);
          sb.Append("$");
          sb.Append(col.ULAplusByte.ToString("X2").ToUpper());
          join = ", ";
        }
        sb.AppendLine();
      }
      string filename4 = fileName.Replace(".png", "-palette.asm");
      File.WriteAllText(filename4, sb.ToString());
    }

    private void Recalculate()
    {
      dirty = true;
      picSource.Invalidate(true);
      picOptimized.Invalidate(true);
      zones.Optimized = false;
      btnExport.Enabled = zones.Optimized;
      //tmrRecalculate.Start();
    }

    private void tmrRecalculate_Tick(object sender, EventArgs e)
    {
      tmrRecalculate.Stop();
      //btnCalculate_Click(btnCalculate, new EventArgs());
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.WindowsShutDown)
        return;
      if (dirty)
      {
        var dr = MessageBox.Show("You have unsaved changes. Save project?", "Radastan Zone Editor",
          MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        if (dr == DialogResult.Cancel)
        {
          e.Cancel = true;
          return;
        }
        else if (dr == DialogResult.No)
          return;
        if (!zones.Save(fileName))
        {
          e.Cancel = true;
          MessageBox.Show("The project could not be saved.", "Radastan Zone Editor",
            MessageBoxButtons.OK, MessageBoxIcon.Stop);
          return;
        }
        saveToolStripMenuItem.Enabled = false;
        closeToolStripMenuItem.Enabled = false;
        dirty = false;
      }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!zones.Save(fileName))
      {
        MessageBox.Show("The project could not be saved.", "Radastan Zone Editor",
          MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }
      dirty = false;
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (dirty)
      {
        var dr = MessageBox.Show("You have unsaved changes. Save project?", "Radastan Zone Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        if (dr == DialogResult.Cancel)
          return;
        else if (dr == DialogResult.No)
          return;
        if (!zones.Save(fileName))
        {
          MessageBox.Show("The project could not be saved.", "Radastan Zone Editor",
            MessageBoxButtons.OK, MessageBoxIcon.Stop);
          return;
        }
      }
      picSource.Image = null;
      picOptimized.Image = null;
      tabImage.SelectedTab = tabSource;
      picSource.Invalidate(true);
      picOptimized.Invalidate(true);
      zones.Optimized = false;
      btnExport.Enabled = zones.Optimized;
      pnlMain.Panel2.Enabled = false;
      saveToolStripMenuItem.Enabled = false;
      closeToolStripMenuItem.Enabled = false;
      dirty = false;
    }
  }
}

