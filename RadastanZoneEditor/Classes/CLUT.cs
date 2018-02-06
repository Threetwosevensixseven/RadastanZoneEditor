using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RadastanZoneEditor.Classes
{
  public class CLUT
  {
    public ULAplusColour[] Colours;
    public int OriginalColourCount;

    public bool OrBlue { get; set; }

    public CLUT()
    {
      Colours = new ULAplusColour[16];
      for (int i = 0; i < 16; i++)
        Colours[i] = new ULAplusColour(i, this);
    }

    public ULAplusColour GetColourFromOriginalRGB(Color OriginalRGB)
    {
      for (int i = 0; i < Colours.Length; i++)
      {
        if (Colours[i].OriginalRGB == OriginalRGB)
          return Colours[i];
      }
      return Colours[0];
    }

    public ULAplusColour GetColourFromULAplusRGB(Color ULAplusRGB)
    {
      for (int i = 0; i < Colours.Length; i++)
      {
        if (Colours[i].ULAplusRGB == ULAplusRGB)
          return Colours[i];
      }
      return Colours[0];
    }

    public byte GetRadastanColourByte(ULAplusColour ColourL, ULAplusColour ColourR)
    {
      byte rv = Convert.ToByte((ColourL.Index * 16) + ColourR.Index);
      return rv;
    }

    public byte GetRadastanColourByte(Color ColourL, Color ColourR)
    {
      int left = 0;
      int right = 0;
      for (int i = 0; i < Colours.Length; i++)
      {
        if (Colours[i].ULAplusRGB == ColourL)
          left = i;
        if (Colours[i].ULAplusRGB == ColourR)
          right = i;
      }
      return Convert.ToByte((left * 16) + right);
    }

    public string HexString
    {
      get
      {
        return string.Join("", Colours.Select(c => c.ULAplusByte.ToString("X2").ToUpper()));
      }
    }

    public string HexStringSpaced
    {
      get
      {
        return string.Join(" ", Colours.Select(c => c.ULAplusByte.ToString("X2").ToUpper()));
      }
    }
  }
}
