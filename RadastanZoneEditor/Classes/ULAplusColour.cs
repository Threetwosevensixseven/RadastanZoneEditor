using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RadastanZoneEditor.Classes
{
  public class ULAplusColour
  {
    //private static Random rnd = new Random();

    private Color _originalRGB = Color.Black;

    private int _index;
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }

    public ULAplusColour(int Index)
    {
      //RGB = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
      OriginalRGB = Color.FromArgb(0, 0, 0);
      _index = Index;
    }

    public int Index
    {
      get
      {
        return _index;
      }
    }

    public Color ULAplusRGB
    {
      get
      {
        return Color.FromArgb(Red * 32, Green * 32, Blue * 64);
      }
    }

    public byte ULAplusByte
    {
      get
      {
        return Convert.ToByte(Blue + (Red * 4) + (Green * 32));
      }
    }
    public Color OriginalRGB
    {
      get
      {
        return _originalRGB;
      }
      set
      {
        Red = Convert.ToInt32(Math.Min(Math.Round(Convert.ToDouble(value.R) / 32d, 0), 7d));
        Green = Convert.ToInt32(Math.Min(Math.Round(Convert.ToDouble(value.G) / 32d, 0), 7d));
        Blue = Convert.ToInt32(Math.Min(Math.Round(Convert.ToDouble(value.B) / 64d, 0), 3d));
        _originalRGB = value;
      }
    }
  }
}
