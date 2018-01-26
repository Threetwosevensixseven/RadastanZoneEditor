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
        }
      }
      updating = false;
    }
  }
}
