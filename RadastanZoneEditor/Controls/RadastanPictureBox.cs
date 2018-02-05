using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RadastanZoneEditor.Classes;

namespace RadastanZoneEditor.Controls
{
  public class RadastanPictureBox : PictureBox
  {
    public Zones Zones;
    private bool updating = false;

    protected override void OnPaint(PaintEventArgs pe)
    {
      pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
      pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      base.OnPaint(pe);
      if (!updating)
      {
        updating = true;
        float mult = Convert.ToSingle(Height) / 96f;
        float y = 0;
        if (Zones != null)
        {
          for (int i = 0; i < Zones.Items.Count - 1; i++)
          {
            y += Zones.Items[i].Height * mult;
            pe.Graphics.DrawLine(Pens.LimeGreen, 0, y, Width, y);
          }
          if (Zones.Tiles != null && Zones.Tiles.Sets != null)
          {
            for (int i = 0; i < Zones.Tiles.Sets.Count; i++)
            {
              bool isCurr = i == Zones.Tiles.CurrentSet - 1;
              if (isCurr && !Zones.Tiles.ShowCurrent) continue;
              if (!isCurr && !Zones.Tiles.ShowOthers) continue;
              var col = isCurr ? Pens.Cyan : Pens.Magenta;
              var t = Zones.Tiles.Sets[i];
              pe.Graphics.DrawLine(col, t.X * mult, t.Y * mult, (t.X + (t.Width * t.HCount)) * mult, t.Y * mult);
              pe.Graphics.DrawLine(col, t.X * mult, t.Y * mult, t.X * mult, (t.Y + (t.Height * t.VCount)) * mult);
              float ty = t.Y;
              for (int j = 0; j < t.VCount; j++)
              {
                ty += t.Height;
                pe.Graphics.DrawLine(col, t.X * mult, ty * mult, (t.X + (t.Width * t.HCount)) * mult, ty * mult);
              }
              float tx = t.X;
              for (int j = 0; j < t.HCount; j++)
              {
                tx += t.Width;
                pe.Graphics.DrawLine(col, tx * mult, t.Y * mult, tx * mult, (t.Y + (t.Height * t.VCount)) * mult);
              }
            }
          }
        }
      }
      updating = false;
    }
  }
}
