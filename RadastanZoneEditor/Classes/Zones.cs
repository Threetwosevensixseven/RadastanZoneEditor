using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RadastanZoneEditor.Classes
{
  public class Zones : List<Zone>
  {
    public Palette Palette { get; set; }

    public Zones()
      : base()
    {
      Palette = new Palette();
      var zone = new Zone();
      zone.Height = 96;
      zone.CLUT = 0;
      Add(zone);
    }

    public void RecalculateHeights()
    {
      int each = this.Count == 0 ? 96 :  (96 / this.Count);
      var add = 96 - (each * this.Count);
      Zone last = null;
      foreach (var item in this)
      {
        item.Height = each;
        last = item;
      }
      if (last != null)
        last.Height = last.Height + add;
     }

    public List<Zone> GetZonesForCLUT(int CLUTid)
    {
      return this.Where(t => t.CLUT == CLUTid).ToList();
    }

    public Bitmap GetCombinedBitmapForCLUT(Image Img, int CLUTid)
    {
      Bitmap bmp = null;
      var src = Img as Bitmap;
      if (Img == null || src == null) return null;
      var zones = GetZonesForCLUT(CLUTid);
      int h = zones.Select(z => z.Height).Sum();
      if (h <= 0) return null;
      bmp = new Bitmap(Img.Width, h, Img.PixelFormat);
      var pal = Img.Palette;
      bmp.Palette = pal;
      var y = 0;
      var dY = 0;
      var dic = new Dictionary<Color, byte>();
      byte palIndex = 0;
      foreach (var item in src.Palette.Entries)
      {
        if (!dic.ContainsKey(item))
          dic.Add(item, palIndex);
        palIndex++;
      }
      byte[] bytes;
      var data = LockBits(bmp, out bytes);
      foreach (var zone in this)
      {
        if (zone.CLUT == CLUTid)
        {
          for (int y1 = 0; y1 < zone.Height; y1++)
          {
            var y2 = y + y1;
            var dy2 = dY + y1;
            if (y2 >= Img.Height || dy2 >= Img.Height)
              break;
            for (int x = 0; x < Img.Width; x++)
            {
              var col = src.GetPixel(x, y2);
              var index = dic[col];
              SetLockedPixel(data, bytes, x, dy2, index);
            }
          }
          dY += zone.Height;
        }
        y += zone.Height;
      }
      UnlockBits(bmp, ref data);
      return bmp;
    }

    private BitmapData LockBits(Bitmap Bmp, out byte[] Bytes)
    {
      var data = Bmp.LockBits(new Rectangle(0, 0, Bmp.Width, Bmp.Height),
          ImageLockMode.WriteOnly, Bmp.PixelFormat);
      Bytes = new byte[data.Height * data.Stride];
      return data;
    }

    private byte GetLockedPixel(BitmapData Data, byte[] Bytes, int X, int Y)
    {
      Marshal.Copy(Data.Scan0, Bytes, 0, Bytes.Length);
      return Bytes[Y * Data.Stride + X];
    }

    private void SetLockedPixel(BitmapData Data, byte[] Bytes, int X, int Y, byte PaletteIndex)
    {
      Marshal.Copy(Data.Scan0, Bytes, 0, Bytes.Length);
      Bytes[Y * Data.Stride + X] = PaletteIndex;
      Marshal.Copy(Bytes, 0, Data.Scan0, Bytes.Length);
    }

    private void UnlockBits(Bitmap Bmp, ref BitmapData Data)
    {
      Bmp.UnlockBits(Data);
    }

    public void SetCLUTFromBitmap(Bitmap Bmp, int CLUTid)
    {
      var clut = this.Palette.CLUTs[CLUTid];
      var oldPal = new Dictionary<Color, int>();
      var oldPal2 = new Dictionary<int, Color>();
      int i = 0;
      foreach (var item in Bmp.Palette.Entries)
      {
        if (!oldPal.ContainsKey(item))
        {
          oldPal.Add(item, i);
          oldPal2.Add(i, item);
        }
        i++;
      }
      var newPal = new Dictionary<Color, int>();
      var newPal2 = new Dictionary<int, Color>();
      int newIndex = 0;
      byte[] bytes;
      var data = LockBits(Bmp, out bytes);
      for (int y = 0; y < Bmp.Height; y++)
      {
        for (int x = 0; x < Bmp.Width; x++)
        {
          var ix = GetLockedPixel(data, bytes, x, y);
          var col = oldPal2[ix];
          int newix;
          if (newPal.ContainsKey(col))
            newix = newPal[col];
          else
          {
            newix = newIndex;
            newPal.Add(col, newIndex);
            newPal2.Add(newIndex, col);
            newIndex++;
          }
          SetLockedPixel(data, bytes, x, y, Convert.ToByte(newix));
        }
      }
      UnlockBits(Bmp, ref data);

      var pal = Bmp.Palette;
      for (int n = 0; n < pal.Entries.Length; n++)
      {
        if (newPal2.ContainsKey(n))
          pal.Entries[n] = newPal2[n];
        else
          pal.Entries[n] = Color.Black;
      }
      Bmp.Palette = pal;

      for (int p = 0; p < 16; p++)
        clut.Colours[p].OriginalRGB = pal.Entries[p];
      clut.OriginalColourCount = newPal.Count;
    }
  }
}
