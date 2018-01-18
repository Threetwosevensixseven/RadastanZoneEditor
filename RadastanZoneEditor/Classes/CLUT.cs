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

    public CLUT()
    {
      Colours = new ULAplusColour[16];
      for (int i = 0; i < 16; i++)
        Colours[i] = new ULAplusColour(i);
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
  }
}
