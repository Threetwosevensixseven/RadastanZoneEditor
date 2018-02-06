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
    #region Properties and Constructors

    private Zones zones;
    private Panel[] sourceColours;
    private Panel[] ulaPlusColours;
    private bool settingUp = true;
    private string fileName = "";
    private bool dirty = false;
    private Settings settings;
    private frmColour colourForm;

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
      SetUlaPlusColour(0, pnlULA0);
      SetUlaPlusColour(1, pnlULA1);
      SetUlaPlusColour(2, pnlULA2);
      SetUlaPlusColour(3, pnlULA3);
      SetUlaPlusColour(4, pnlULA4);
      SetUlaPlusColour(5, pnlULA5);
      SetUlaPlusColour(6, pnlULA6);
      SetUlaPlusColour(7, pnlULA7);
      SetUlaPlusColour(8, pnlULA8);
      SetUlaPlusColour(9, pnlULA9);
      SetUlaPlusColour(10, pnlULA10);
      SetUlaPlusColour(11, pnlULA11);
      SetUlaPlusColour(12, pnlULA12);
      SetUlaPlusColour(13, pnlULA13);
      SetUlaPlusColour(14, pnlULA14);
      SetUlaPlusColour(15, pnlULA15);
      settingUp = false;
      AddRecentFile();
      if (args.Length >= 1 && !string.IsNullOrWhiteSpace(args[0]))
        Open((args[0] ?? "").Trim());
    }

    #endregion Properties and Constructors

    #region File Menu

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
      AddRecentFile(fileName);
      zones = z;
      bool zo = zones.Optimized;
      saveToolStripMenuItem.Enabled = true;
      closeToolStripMenuItem.Enabled = true;
      pnlMain.Panel2.Enabled = true;
      settingUp = true;
      numZones.Value = zones.Items.Count;
      numZone.Maximum = zones.Items.Count;
      numTiles.Value = zones.Tiles.Sets.Count;
      numTiles_ValueChanged(numTiles, new EventArgs());
      chkTileCurrent.Checked = zones.Tiles.ShowCurrent;
      chkTileOthers.Checked = zones.Tiles.ShowOthers;
      settingUp = false;
      numZone.Value = zones.CurrentZone;
      numZones_ValueChanged(numZones, new EventArgs());
      numZone_ValueChanged(numZone, new EventArgs());
      zones.Optimized = zo;
      if (zones.Optimized)
        btnCalculate_Click(btnCalculate, new EventArgs());
      dirty = false;
    }

    private void AddRecentFile(string FileName = null)
    {
      settings = Settings.Load();
      settings.AddRecentFile(FileName);
      settings.Save();
      recentToolStripMenuItem.DropDownItems.Clear();
      foreach (string file in settings.Recent)
      {
        //var item = recentToolStripMenuItem.DropDownItems.Add(Settings.ShortenPath(file, 60));
        var item = recentToolStripMenuItem.DropDownItems.Add(file);
        item.Click += RecentItem_Click;
        item.Tag = file;
      }
    }

    private void RecentItem_Click(object sender, EventArgs e)
    {
      if (!SaveAndClose()) return;
      var item = sender as ToolStripMenuItem;
      if (item == null) return;
      var filename = item.Tag as string;
      if (string.IsNullOrWhiteSpace(filename)) return;
      Open(filename);
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
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
      SaveAndClose();
    }

    private bool SaveAndClose()
    {
      if (dirty)
      {
        var dr = MessageBox.Show("You have unsaved changes. Save project?", "Radastan Zone Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        if (dr == DialogResult.Cancel)
          return false;
        else if (dr == DialogResult.No)
        {
          dirty = false;
          return true;
        }
        if (!zones.Save(fileName))
        {
          MessageBox.Show("The project could not be saved.", "Radastan Zone Editor",
            MessageBoxButtons.OK, MessageBoxIcon.Stop);
          return false;
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
      return true;
    }

    #endregion File Menu

    #region Zones

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
        {
          sourceColours[i].BackColor = clut.Colours[i].OriginalRGB;
          toolTip.SetToolTip(sourceColours[i], clut.Colours[i].OriginalRGBToolTip);
        }
        for (int i = 0; i < 16; i++)
        {
          ulaPlusColours[i].BackColor = clut.Colours[i].ULAplusRGB;
          toolTip.SetToolTip(ulaPlusColours[i], clut.Colours[i].ULAplusRGBToolTip);
        }
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

    #endregion Zones
  
    #region Colours

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
        {
          sourceColours[i].BackColor = clut.Colours[i].OriginalRGB;
          toolTip.SetToolTip(sourceColours[i], clut.Colours[i].OriginalRGBToolTip);
        }
        for (int i = 0; i < 16; i++)
        {
          ulaPlusColours[i].BackColor = clut.Colours[i].ULAplusRGB;
          toolTip.SetToolTip(ulaPlusColours[i], clut.Colours[i].ULAplusRGBToolTip);
        }
        lblUniqueVal.Text = clut.OriginalColourCount.ToString();
        lblUniqueVal.ForeColor = clut.OriginalColourCount > 16 ? Color.Red : SystemColors.ControlText;
      }
      Recalculate();
    }

    private void tmrTooltip_Tick(object sender, EventArgs e)
    {
      toolTip.Active = false;
      toolTip.Active = true;
    }

    private void SetUlaPlusColour(int Index, Panel Panel)
    {
      ulaPlusColours[Index] = Panel;
      Panel.Tag = Index;
      ulaPlusColours[Index].Click += Colour_Click;
    }

    private void Colour_Click(object sender, EventArgs e)
    {
      var ctrl = sender as Control;
      if (ctrl == null) return;
      if (colourForm == null || colourForm.Disposing)
        colourForm = new frmColour();
      colourForm.ShowMe(ctrl, this);
    }

    public void SetCurrentColour(int Index, Color Color)
    {
      if (Index < 0 || Index > 15)
        return;
      int zoneval = Convert.ToInt32(numZone.Value);
      var zone = zones.Items[zoneval - 1];
      int clutid = zone.IndexToCLUT(cboClut.SelectedIndex);
      if (clutid < 0) return;
      var clut = zones.Palette.CLUTs[clutid];
      clut.Colours[Index].SetULAPlusRGB(Color);
      ulaPlusColours[Index].BackColor = clut.Colours[Index].ULAplusRGB;
    }

    private void chkBlue_CheckedChanged(object sender, EventArgs e)
    {
      foreach (var clut in zones.Palette.CLUTs)
        clut.OrBlue = chkBlue.Checked;
      btnCalculate_Click(btnCalculate, new EventArgs());
    }

    #endregion Colours

    #region Export

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
          int x = 0;
          for (int x2 = 0; x2 < (img.Width / 2); x2++)
          {
            byte b;
            if (zone.CLUT >= 0)
            {
              var colL = bmp.GetPixel(x, y);
              var ulaL = clut.GetColourFromULAplusRGB(colL);
              x++;
              var colR = bmp.GetPixel(x, y);
              var ulaR = clut.GetColourFromULAplusRGB(colR);
              x++;

              b = clut.GetRadastanColourByte(ulaL, ulaR);
            }
            else
            {
              b = 0;
              x = x + 2;
            }
            exportImage.Add(b);
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

      sb = new StringBuilder();
      foreach (string size in zones.Tiles.Sizes)
      {
        sb.Append(Tiles.GetDescription(size));
        sb.AppendLine(" proc Table:");
        sb.AppendLine();
        sb.Append(Tiles.GetHeader(size));
        sb.AppendLine();
        int index = zones.Tiles.StartIndex;
        foreach (var tile in zones.Tiles.GetTilesForSize(size))
        {
          var clut = zones.GetCLUTForCoordinate(bmp, tile.Y);
          for (int h = 0; h < tile.VCount; h++)
          {
            int ty = tile.Y + (h * tile.Height);
            string hc = (h + 1).ToString();
            for (int w = 0; w < tile.HCount; w++)
            {
              int tx = tile.X + (w * tile.Width);
              string wc = ((char)(65 + w)).ToString();
              string name = (tile.Name ?? "").Trim() + " " + wc + hc;
              sb.Append("  dh \"");
              for (int yy = 0; yy < tile.Height; yy++)
              {
                int tyy = ty + yy;
                for (int xx = 0; xx < (tile.Width / 2); xx++)
                {
                  int txx = tx + (xx * 2);
                  var b = exportImage.GetRadastanByte(txx, tyy);
                  sb.Append(b.ToString("X2"));
                }
              }
              sb.Append("\" ; ");
              sb.Append(index.ToString().PadLeft(3));
              sb.Append("  ");
              sb.AppendLine(name);
              index++;
            }
          }
        }
        sb.AppendLine();
        sb.AppendLine("  Length equ $-Table");
        sb.Append("  Size   equ ");
        sb.AppendLine(Tiles.GetLength(size).ToString());
        sb.AppendLine("  Count  equ Length/Size ");
        sb.AppendLine("pend");
        sb.AppendLine();
      }
      string filename5 = fileName.Replace(".png", "-tiles.asm");
      File.WriteAllText(filename5, sb.ToString());
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

    #endregion Export

    #region Tiles

    private bool _settingUpTiles = false;

    private void numTiles_ValueChanged(object sender, EventArgs e)
    {
      if (_settingUpTiles) return;
      _settingUpTiles = true;
      int tileNo = Convert.ToInt32(numTile.Value);
      while (zones.Tiles.Sets.Count > numTiles.Value)
      {
        zones.Tiles.Sets.Remove(zones.Tiles.Sets[zones.Tiles.Sets.Count - 1]);
      }
      while (zones.Tiles.Sets.Count < numTiles.Value)
      {
        var t = new Tile(zones.Tiles);
        zones.Tiles.Sets.Add(t);
      }
      if (numTiles.Value > 0 && numTile.Value > numTiles.Value)
        numTile.Value = numTiles.Value;
      if (numTile.Value <= 0)
      {
        if (numTile.Maximum < 1) numTile.Maximum = 1;
        numTile.Value = 1;
      }
      else numTile.Maximum = numTiles.Value;
      numTileIndex.Value = zones.Tiles.StartIndex;
      numTile.Enabled = zones.Tiles.Sets.Count > 0;
      numTileWidth.Enabled = zones.Tiles.Sets.Count > 0;
      numTileHeight.Enabled = zones.Tiles.Sets.Count > 0;
      numTileHCount.Enabled = zones.Tiles.Sets.Count > 0;
      numTileVCount.Enabled = zones.Tiles.Sets.Count > 0;
      numTileX.Enabled = zones.Tiles.Sets.Count > 0;
      numTileY.Enabled = zones.Tiles.Sets.Count > 0;
      txtTileName.Enabled = zones.Tiles.Sets.Count > 0;
      numTileIndex.Enabled = zones.Tiles.Sets.Count > 0;
      _settingUpTiles = false;
      numTile_ValueChanged(numTile, new EventArgs());
      dirty = true;
      RecalculateTiles();
    }

    private void numTile_ValueChanged(object sender, EventArgs e)
    {
      if (_settingUpTiles) return;
      if (numTile.Value < 1) return;
      _settingUpTiles = true;
      int tileNo = Convert.ToInt32(numTile.Value);
      zones.Tiles.CurrentSet = Convert.ToInt32(numTile.Value);
      var tile = zones.Tiles.Sets[zones.Tiles.CurrentSet - 1];
      numTileWidth.Value = tile.Width;
      numTileHeight.Value = tile.Height;
      numTileHCount.Value = tile.HCount;
      numTileVCount.Value = tile.VCount;
      numTileX.Value = tile.X;
      numTileY.Value = tile.Y;
      txtTileName.Text = (tile.Name ?? "").Trim();
      _settingUpTiles = false;
      dirty = true;
      RecalculateTiles();
    }

    private void numTileWidth_ValueChanged(object sender, EventArgs e)
    {
      if (_settingUpTiles) return;
      int tileNo = Convert.ToInt32(numTile.Value);
      var tile = zones.Tiles.Sets[zones.Tiles.CurrentSet - 1];
      tile.Width = Convert.ToInt32(numTileWidth.Value);
      dirty = true;
      RecalculateTiles();
    }

    private void numTileHeight_ValueChanged(object sender, EventArgs e)
    {
      if (_settingUpTiles) return;
      int tileNo = Convert.ToInt32(numTile.Value);
      var tile = zones.Tiles.Sets[zones.Tiles.CurrentSet - 1];
      tile.Height = Convert.ToInt32(numTileHeight.Value);
      dirty = true;
      RecalculateTiles();
    }

    private void numTileHCount_ValueChanged(object sender, EventArgs e)
    {
      if (_settingUpTiles) return;
      int tileNo = Convert.ToInt32(numTile.Value);
      var tile = zones.Tiles.Sets[zones.Tiles.CurrentSet - 1];
      tile.HCount = Convert.ToInt32(numTileHCount.Value);
      dirty = true;
      RecalculateTiles();
    }

    private void numTileVCount_ValueChanged(object sender, EventArgs e)
    {
      if (_settingUpTiles) return;
      int tileNo = Convert.ToInt32(numTile.Value);
      var tile = zones.Tiles.Sets[zones.Tiles.CurrentSet - 1];
      tile.VCount = Convert.ToInt32(numTileVCount.Value);
      dirty = true;
      RecalculateTiles();
    }

    private void numTileX_ValueChanged(object sender, EventArgs e)
    {
      if (_settingUpTiles) return;
      int tileNo = Convert.ToInt32(numTile.Value);
      var tile = zones.Tiles.Sets[zones.Tiles.CurrentSet - 1];
      tile.X = Convert.ToInt32(numTileX.Value);
      dirty = true;
      RecalculateTiles();
    }

    private void numTileY_ValueChanged(object sender, EventArgs e)
    {
      if (_settingUpTiles) return;
      int tileNo = Convert.ToInt32(numTile.Value);
      var tile = zones.Tiles.Sets[zones.Tiles.CurrentSet - 1];
      tile.Y = Convert.ToInt32(numTileY.Value);
      dirty = true;
      RecalculateTiles();
    }

    private void txtTileName_TextChanged(object sender, EventArgs e)
    {
      if (_settingUpTiles) return;
      if (zones.Tiles.Sets.Count <= 0) return;
      var tile = zones.Tiles.Sets[zones.Tiles.CurrentSet - 1];
      tile.Name = (txtTileName.Text ?? "").Trim();
      dirty = true;
    }

    private void txtTileName_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (_settingUpTiles) return;
      txtTileName_TextChanged(sender, new EventArgs());
    }

    private void numTileIndex_ValueChanged(object sender, EventArgs e)
    {
      if (_settingUpTiles) return;
      dirty = true;
      zones.Tiles.StartIndex = Convert.ToInt32(numTileIndex.Value);
    }

    private void chkTileOthers_CheckedChanged(object sender, EventArgs e)
    {
      zones.Tiles.ShowOthers = chkTileOthers.Checked;
      dirty = true;
      RecalculateTiles();
    }

    private void chkTileCurrent_CheckedChanged(object sender, EventArgs e)
    {
      zones.Tiles.ShowCurrent = chkTileCurrent.Checked;
      dirty = true;
      RecalculateTiles();
    }

    private void RecalculateTiles()
    {
      picSource.Invalidate(true);
      picOptimized.Invalidate(true);
    }

    #endregion Tiles
  }
}

