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

    public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
    {
      int max = Math.Max(color.R, Math.Max(color.G, color.B));
      int min = Math.Min(color.R, Math.Min(color.G, color.B));

      hue = color.GetHue();
      saturation = (max == 0) ? 0 : 1d - (1d * min / max);
      value = max / 255d;
    }

    public static Color ColorFromHSV(double hue, double saturation, double value)
    {
      int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
      double f = hue / 60 - Math.Floor(hue / 60);

      value = value * 255;
      int v = Convert.ToInt32(value);
      int p = Convert.ToInt32(value * (1 - saturation));
      int q = Convert.ToInt32(value * (1 - f * saturation));
      int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

      if (hi == 0)
        return Color.FromArgb(255, v, t, p);
      else if (hi == 1)
        return Color.FromArgb(255, q, v, p);
      else if (hi == 2)
        return Color.FromArgb(255, p, v, t);
      else if (hi == 3)
        return Color.FromArgb(255, p, q, v);
      else if (hi == 4)
        return Color.FromArgb(255, t, p, v);
      else
        return Color.FromArgb(255, v, p, q);
    }

    public int Hue
    {
      get
      {
        double h, s, v;
        ColorToHSV(this.ULAplusRGB, out h, out s, out v);
        return Convert.ToInt32(h);
      }
    }

    public int Saturation
    {
      get
      {
        double h, s, v;
        ColorToHSV(this.ULAplusRGB, out h, out s, out v);
        return Convert.ToInt32(Math.Round(s * 100, 0));
      }
    }

    public int Value
    {
      get
      {
        double h, s, v;
        ColorToHSV(this.ULAplusRGB, out h, out s, out v);
        return Convert.ToInt32(Math.Round(v * 100, 0));
      }
    }

    public void SetHue(int Hue)
    {
      double h, s, v;
      ColorToHSV(this.ULAplusRGB, out h, out s, out v);
      if (h == this.Hue && Hue < this.Hue)
      {
        double h1 = h;
        var ulac = new ULAplusColour(0);
        var rgb = ColorFromHSV(h1, s, v);
        while (rgb == this.ULAplusRGB)
        {
          h1--;
          ulac.OriginalRGB = rgb;
        }
      }
      else if (h == this.Hue && Hue < this.Hue)
      {
        double h1 = h;
        var ulac = new ULAplusColour(0);
        var rgb = ColorFromHSV(h1, s, v);
        while (rgb == this.ULAplusRGB)
        {
          h1++;
          ulac.OriginalRGB = rgb;
        }
      }
    }

    public void SetSaturation(int Saturation)
    {
      double h, s, v;
      ColorToHSV(this.ULAplusRGB, out h, out s, out v);
      s = Convert.ToDouble(Saturation) / 100;
      ColorFromHSV(h, s, v);
    }

    public void SetValue(int Value)
    {
      double h, s, v;
      ColorToHSV(this.ULAplusRGB, out h, out s, out v);
      v = Convert.ToDouble(Value) / 100;
      ColorFromHSV(h, s, v);
    }

    public void SetULAPlusRGB(Color RGB)
    {
      Red = Convert.ToInt32(Math.Min(Math.Round(Convert.ToDouble(RGB.R) / 32d, 0), 7d));
      Green = Convert.ToInt32(Math.Min(Math.Round(Convert.ToDouble(RGB.G) / 32d, 0), 7d));
      Blue = Convert.ToInt32(Math.Min(Math.Round(Convert.ToDouble(RGB.B) / 64d, 0), 3d));
    }
  }
}
