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

    public frmMain()
    {
      InitializeComponent();
      zones = new Zones();
      picSource.Zones = zones;
      cboZone.Items.Clear();
      cboZone.Items.Add(1);
      cboZone.SelectedIndex = 0;
      cboClut.Items.Clear();
      cboClut.Items.Add(0);
      cboClut.Items.Add(1);
      cboClut.Items.Add(2);
      cboClut.Items.Add(3);
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
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var res = dlgFileOpen.ShowDialog();
      if (res != DialogResult.OK)
        return;
      fileName = dlgFileOpen.FileName;
      if (!File.Exists(fileName))
      {
        MessageBox.Show("Cant open file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return;
      }
      picSource.Load(fileName);
      pnlMain.Panel2.Enabled = true;
      numZones_ValueChanged(numZones, new EventArgs());
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
      int zone = cboZone.SelectedIndex + 1;
      while (zones.Count > numZones.Value)
      {
        zones.Remove(zones[zones.Count - 1]);
        cboZone.Items.Remove(cboZone.Items[cboZone.Items.Count - 1]);
      }
      while (zones.Count < numZones.Value)
      {
        zones.Add(new Zone());
        zones.RecalculateHeights();
        cboZone.Items.Add((cboZone.Items.Count + 1));
      }
      if (cboZone.Items.Count < zone)
        cboZone.SelectedIndex = cboZone.Items.Count - 1;
      else
        cboZone.SelectedIndex = zone - 1;
      cboZone_SelectedIndexChanged(cboZone, new EventArgs());
      picSource.Invalidate(true);
    }

    private void cboZone_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (settingUp) return;
      int val = cboZone.SelectedIndex;
      var zone = zones[cboZone.SelectedIndex];
      var clut = zones.Palette.CLUTs[zone.CLUT];
      settingUp = true;
      numHeight.Value = zone.Height;
      cboClut.SelectedIndex = zone.CLUT;
      settingUp = false;
      for (int i = 0; i < 16; i++)
        sourceColours[i].BackColor = clut.Colours[i].OriginalRGB;
      for (int i = 0; i < 16; i++)
        ulaPlusColours[i].BackColor = clut.Colours[i].ULAplusRGB;
      cboClut_SelectedIndexChanged(cboClut, new EventArgs());
      picSource.Invalidate(true);
    }

    private void numHeight_ValueChanged(object sender, EventArgs e)
    {
      if (settingUp) return;
      int val = cboZone.SelectedIndex;
      var zone = zones[cboZone.SelectedIndex];
      zone.Height = Convert.ToInt32(numHeight.Value);
      picSource.Invalidate(true);
    }

    private void cboClut_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (settingUp) return;
      int val = cboZone.SelectedIndex;
      var zone = zones[cboZone.SelectedIndex];
      zone.CLUT = cboClut.SelectedIndex;
      var clut = zones.Palette.CLUTs[zone.CLUT];
      for (int i = 0; i < 16; i++)
        sourceColours[i].BackColor = clut.Colours[i].OriginalRGB;
      for (int i = 0; i < 16; i++)
        ulaPlusColours[i].BackColor = clut.Colours[i].ULAplusRGB;
      lblUniqueVal.Text = clut.OriginalColourCount.ToString();
      lblUniqueVal.ForeColor = clut.OriginalColourCount > 16 ? Color.Red : SystemColors.ControlText;
      picSource.Invalidate(true);
    }

    private void btnCalculate_Click(object sender, EventArgs e)
    {
      int val = cboZone.SelectedIndex;
      var zone = zones[cboZone.SelectedIndex];
      zone.CLUT = cboClut.SelectedIndex;
      var clut = zones.Palette.CLUTs[zone.CLUT];
      for (int CLUTid = 0; CLUTid < 4; CLUTid++)
      {
        var bmp = zones.GetCombinedBitmapForCLUT(picSource.Image, CLUTid);
        if (bmp == null) continue;
        bmp.Save(fileName.Replace(".png", "-clut-" + CLUTid + ".png"));
        zones.SetCLUTFromBitmap(bmp, CLUTid);
      }
      cboClut_SelectedIndexChanged(cboClut, new EventArgs());
      var src = picSource.Image as Bitmap;
      var rect = new Rectangle(0, 0, src.Width, src.Height);
      var dest = src.Clone(rect, src.PixelFormat);
      picOptimized.Image = dest;
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
      btnExport.Enabled = true;
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
      foreach (var zone in zones)
      {
        var clut = zones.Palette.CLUTs[zone.CLUT];
        for (int y1 = 0; y1 < zone.Height; y1++)
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
          y++;
        }
      }

      string filename3 = fileName.Replace(".png", ".radscr");
      File.WriteAllBytes(filename3, exportImage.ToArray());

      var sb = new StringBuilder();
      for (int i = 0; i < 4; i++)
      {
        var clut = zones.Palette.CLUTs[i];
        sb.AppendLine("; ULAplus CLUT " + i);
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
        sb.AppendLine();
      }
      string filename4 = fileName.Replace(".png", "-palette.asm");
      File.WriteAllText(filename4, sb.ToString());
    }
  }
}

