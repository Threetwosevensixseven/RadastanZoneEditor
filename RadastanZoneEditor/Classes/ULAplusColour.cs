using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RadastanZoneEditor.Classes
{
  public class ULAplusColour
  {
    private Color _originalRGB = Color.Black;
    private CLUT _parentCLUT;

    private int _index;
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }

    public ULAplusColour(int Index, CLUT ParentCLUT)
    {
      OriginalRGB = Color.FromArgb(0, 0, 0);
      _index = Index;
      _parentCLUT = ParentCLUT;
    }

    public int Index
    {
      get
      {
        return _index;
      }
    }

    public int Blue3
    {
      get
      {
        return (Blue << 1) | ((Blue & 2) >> 1) | (Blue & 1);
      }
    }

    public Color ULAplusRGB
    {
      get
      {
        int r8 = ((Red & 7) << 5) | ((Red & 7) << 2) | ((Red & 6) >> 1);
        int g8 = ((Green & 7) << 5) | ((Green & 7) << 2) | ((Green & 6) >> 1);
        int b8;
        if (_parentCLUT.OrBlue)
        {
          int b3 = Blue3;
          b8 = ((b3 & 7) << 5) | ((b3 & 7) << 2) | ((b3 & 6) >> 1);
        }
        else
          b8 = ((Blue & 3) << 6) | ((Blue & 3) << 4) | ((Blue & 3) << 2) | (Blue & 3);
        //if (Red != 0 || Green != 0 || Blue != 0)
        //  Debugger.Break();
        return Color.FromArgb(r8, g8, b8);
      }
    }

    public byte ULAplusByte
    {
      get
      {
        var byt = Convert.ToByte(((Green & 7) << 5) | ((Red & 7) << 2) | (Blue & 3));
        //if (byt != 0)
        //  Debugger.Break();
        return byt;
      }
    }

    public string ULAplusByteSpaced
    {
      get
      {
        string val = Convert.ToString(ULAplusByte, 2).PadLeft(8, '0');
        return val.Substring(0, 3) + " " + val.Substring(3, 3) + " " + val.Substring(6, 2);
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
        Red = (value.R & 224) >> 5;
        Green = (value.G & 224) >> 5;
        Blue = (value.B & 192) >> 6;
        _originalRGB = value;
        //if (Red != 0 || Green != 0 || Blue != 0)
          //Debugger.Break();
      }
    }

    public void SetULAPlusRGB(Color RGB)
    {
      Red = (RGB.R & 224) >> 5;
      Green = (RGB.G & 224) >> 5;
      Blue = (RGB.B & 192) >> 6;
    }

    public string OriginalRGBToolTip
    {
      get
      {
        var col = OriginalRGB;
        StringBuilder sb = new StringBuilder();
        sb.Append("#");
        sb.Append(col.R.ToString("x2"));
        sb.Append(col.G.ToString("x2"));
        sb.AppendLine(col.B.ToString("x2"));

        sb.AppendLine();
        sb.Append("R8: ");
        sb.Append(Group35(col.R));
        sb.Append(" (");
        sb.Append(col.R);
        sb.Append(") [$");
        sb.Append(col.R.ToString("X2"));
        sb.AppendLine("]");
        sb.Append("G8: ");
        sb.Append(Group35(col.G));
        sb.Append(" (");
        sb.Append(col.G);
        sb.Append(") [$");
        sb.Append(col.G.ToString("X2"));
        sb.AppendLine("]");
        sb.Append("B8: ");
        sb.Append(Group35(col.B));
        sb.Append(" (");
        sb.Append(col.B);
        sb.Append(") [$");
        sb.Append(col.B.ToString("X2"));
        sb.AppendLine("]");

        return sb.ToString();
      }
    }

    public string ULAplusRGBToolTip
    {
      get
      {
        var col = ULAplusRGB;
        StringBuilder sb = new StringBuilder();
        sb.Append("#");
        sb.Append(col.R.ToString("x2"));
        sb.Append(col.G.ToString("x2"));
        sb.AppendLine(col.B.ToString("x2"));

        sb.AppendLine();
        sb.Append("R3: ");
        sb.Append(Binary(Red, 3));
        sb.Append(" (");
        sb.Append(Red);
        sb.AppendLine(")");
        sb.Append("G3: ");
        sb.Append(Binary(Green, 3));
        sb.Append(" (");
        sb.Append(Green);
        sb.AppendLine(")");
        sb.Append("B2: ");
        sb.Append(Binary(Blue, 2));
        sb.Append(" (");
        sb.Append(Blue);
        sb.AppendLine(")");
        sb.Append("B3: ");
        sb.Append(Binary(Blue3, 3));
        sb.Append(" (");
        sb.Append(Blue3);
        sb.AppendLine(")");

        sb.AppendLine();
        sb.Append("GRB8: ");
        sb.Append(ULAplusByteSpaced);
        sb.Append(" (");
        sb.Append(ULAplusByte);
        sb.Append(") [$");
        sb.Append(ULAplusByte.ToString("X2"));
        sb.AppendLine("]");

        sb.AppendLine();
        sb.Append("R8: ");
        sb.Append(Group332(col.R));
        sb.Append(" (");
        sb.Append(col.R);
        sb.Append(") [$");
        sb.Append(col.R.ToString("X2"));
        sb.AppendLine("]");
        sb.Append("G8: ");
        sb.Append(Group332(col.G));
        sb.Append(" (");
        sb.Append(col.G);
        sb.Append(") [$");
        sb.Append(col.G.ToString("X2"));
        sb.AppendLine("]");
        sb.Append("B8: ");
        sb.Append(Group2222(col.B));
        sb.Append(" (");
        sb.Append(col.B);
        sb.Append(") [$");
        sb.Append(col.B.ToString("X2"));
        sb.AppendLine("]");

        sb.AppendLine();
        sb.AppendLine((_parentCLUT ?? new CLUT()).HexStringSpaced);
        sb.AppendLine((_parentCLUT ?? new CLUT()).HexString);

        return sb.ToString();
      }
    }

    private static string Group332(int Value)
    {
      string val = Convert.ToString(Value, 2).PadLeft(8, '0');
      return val.Substring(0, 3) + " " + val.Substring(3, 3) + " " + val.Substring(6);
    }

    private static string Group2222(int Value)
    {
      string val = Convert.ToString(Value, 2).PadLeft(8, '0');
      return val.Substring(0, 2) + " " + val.Substring(2, 2) + " " + val.Substring(4, 2) + " " + val.Substring(6);
    }

    private static string Group35(int Value)
    {
      string val = Convert.ToString(Value, 2).PadLeft(8, '0');
      return val.Substring(0, 3) + " " + val.Substring(3);
    }

    private static string Binary(int Value, int Length)
    {
      return Convert.ToString(Value, 2).PadLeft(Length, '0');
    }



    #region HSV

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
        var ulac = new ULAplusColour(0, new Classes.CLUT());
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
        var ulac = new ULAplusColour(0, new CLUT());
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

    #endregion HSV
  }
}
