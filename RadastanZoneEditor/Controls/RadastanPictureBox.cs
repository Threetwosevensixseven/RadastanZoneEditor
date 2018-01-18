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
        double mult = Convert.ToDouble(Height) / 96d;
        int y = 0;
        if (Zones != null)
        {
          foreach (var zone in Zones)
          {
            y += Convert.ToInt32(zone.Height * mult);
            pe.Graphics.DrawLine(Pens.LimeGreen, 0, y, Width, y);
          }
        }
      }
      updating = false;
    }
  }
}
