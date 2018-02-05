using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using RadastanZoneEditor.Controls;

namespace RadastanZoneEditor.Classes
{
  public class Zones 
  {
    [XmlIgnore]
    public Palette Palette { get; set; }
    public List<Zone> Items { get; set; }
    public int CurrentZone { get; set; }
    public bool Optimized { get; set; }
    public Tiles Tiles { get; set; }

    private Zones()
      : base()
    {
      Palette = new Palette();
      Items = new List<Zone>();
      Tiles = new Tiles();
    }

    public Zones(bool CreateWithFirstZone) : this()
    {
      var zone = new Zone(this);
      zone.Height = 96;
      zone.CLUT = 0;
      Items.Add(zone);
      CurrentZone = 1;
    }

    private void Reparent()
    {
      if (Items == null)
        Items = new List<Zone>();
      if (Palette == null)
        Palette = new Palette();
      if (Items.Count < 1)
      {
        var zone = new Zone(this);
        zone.Height = 96;
        zone.CLUT = 0;
        Items.Add(zone);
        CurrentZone = 1;
      }
      foreach (var zone in Items)
        zone.Reparent(this);
      if (CurrentZone < 1)
        CurrentZone = 1;
      if (CurrentZone > Items.Count)
        CurrentZone = Items.Count;

      foreach (var tile in Tiles.Sets)
        tile.Reparent(Tiles);
      if (Tiles.CurrentSet < 1)
        Tiles.CurrentSet = 1;
      if (Tiles.CurrentSet > Tiles.Sets.Count)
        Tiles.CurrentSet = Tiles.Sets.Count;

      //RecalculateHeights();
    }

    public void RecalculateHeights()
    {
      int each = Items.Count == 0 ? 96 :  (96 / Items.Count);
      var add = 96 - (each * Items.Count);
      Zone last = null;
      foreach (var item in Items)
      {
        item.Height = each;
        last = item;
      }
      if (last != null)
        last.Height = last.Height + add;
     }

    public List<Zone> GetZonesForCLUT(int CLUTid)
    {
      return Items.Where(t => t.CLUT == CLUTid).ToList();
    }

    public string GetZoneDescription(int CLUTid)
    {
      int count = GetZonesForCLUT(CLUTid).Count;
      if (count == 0)
        return "no zones";
      else if (count == 1)
      {
        for (int i = 0; i < Items.Count; i++)
          if (Items[i].CLUT == CLUTid)
            return "zone " + i;
        throw new Exception("Unexpected zone description.");
      }
      else
      {
        var list = new List<int>();
        for (int i = 0; i < Items.Count; i++)
          if (Items[i].CLUT == CLUTid)
            list.Add(i);
        string desc = "";
        string join = "";
        for (int i = 0; i < list.Count - 1; i++)
        {
          desc += join + list[i];
          join = ", ";
        }
        return "zones " + desc + " and " + list[list.Count - 1];
      }
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
      foreach (var zone in Items)
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
        int black = Color.Black.ToArgb();
        if (!oldPal.ContainsKey(item))
        {
          oldPal.Add(item, i);
          oldPal2.Add(i, item);
        }
        i++;
      }

      var newPal = new Dictionary<Color, int>();
      var newPal2 = new Dictionary<int, Color>();
      newPal.Add(Color.Black, 0);
      newPal2.Add(0, Color.Black);
      int newIndex = 1;
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

    private string ToXML()
    {
      XmlSerializer serializer = new XmlSerializer(typeof(Zones));
      StringWriter writer = new StringWriter();
      using (writer)
      {
        serializer.Serialize(writer, this);
        writer.Close();
        return writer.ToString().Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"");
      }
    }

    public static Zones FromXML(string Xml)
    {
      Zones zones;
      try
      {
        StringReader reader = new StringReader(Xml);
        using (reader)
        {
          XmlSerializer serializer = new XmlSerializer(typeof(Zones));
          zones = (Zones)serializer.Deserialize(reader);
          zones.Reparent();
          reader.Close();
        }
      }
      catch
      {
        zones = new Zones(true);
      }
      return zones;
    }

    public static Zones Open(string FileName, RadastanPictureBox Editor)
    {
      try
      {
        var fn = (FileName ?? "").Trim();
        if (!File.Exists(FileName))
          throw new InvalidOperationException("File \"" + fn + "\" does not exist.");
        if (Path.GetExtension(fn.ToLower()) != ".png")
          throw new InvalidOperationException("File \"" + fn + "\" is not a PNG.");
        Editor.Load(fn);
        var projFileName = FileName.Replace(".png", ".radzone");
        Zones zones;
        if (File.Exists(projFileName))
        {
          var xml = File.ReadAllText(projFileName);
          //MessageBox.Show(xml);
          zones = Zones.FromXML(xml);
          if (zones == null || zones.Items.Count < 1)
            zones = new Zones(true);
          zones.Reparent();
        }
        else
        {
          zones = new Zones(true);
        }
        Editor.Zones = zones;
        return zones;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Radastan Zone Editor", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        return null;
      }
    }

    public bool Save(string FileName)
    {
      try
      {
        var xml = ToXML();
        //MessageBox.Show(xml);
        string fn = FileName.Replace(".png", ".radzone");
        var dir = Path.GetDirectoryName(fn);
        if (!Directory.Exists(dir))
          Directory.CreateDirectory(dir);
        File.WriteAllText(fn, xml);
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}
