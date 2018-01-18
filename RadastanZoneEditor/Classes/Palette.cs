using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RadastanZoneEditor.Classes
{
  public class Palette
  {
    public CLUT[] CLUTs;

    public Palette()
    {
      CLUTs = new CLUT[4];
      for (int i = 0; i < 4; i++)
        CLUTs[i] = new CLUT();
    }

    public Color GetUlaPlusColour(Color SourceColour)
    {
      foreach (var clut in CLUTs)
      {
        foreach (var col in clut.Colours)
        {
          if (col.OriginalRGB == SourceColour)
            return col.ULAplusRGB;
        }
      }
      return Color.Black;
    }
  }
}
