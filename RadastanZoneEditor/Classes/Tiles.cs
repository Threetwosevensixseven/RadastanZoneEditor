using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadastanZoneEditor.Classes
{
  public class Tiles
  {
    public List<Tile> Sets { get; set; }
    public int CurrentSet { get; set; }
    public int StartIndex { get; set; }
    public bool ShowCurrent { get; set; }
    public bool ShowOthers { get; set; }

    public Tiles()
    {
      Sets = new List<Tile>();
    }

    public List<string> Sizes
    {
      get
      {
        return Sets.Select(t => t.Sort).Distinct().OrderBy(t => t).ToList();
      }
    }

    public List<Tile> GetTilesForSize(string Size)
    {
      return Sets.Where(t => t.Sort == Size).ToList();
    }

    public static string GetDescription(string Size)
    {
      int x = int.Parse(Size.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
      int y = int.Parse(Size.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
      return "RTiles" + x + "x" + y;
    }

    public static string GetHeader(string Size)
    {
      var sb = new StringBuilder();
      sb.Append("  ;   ");
      int x = int.Parse(Size.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
      int y = int.Parse(Size.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
      for (int i = 0; i < y; i++)
      {
        sb.Append("<-Row");
        sb.Append(i + 1);
        if ((i + 1).ToString().Length == 1)
          sb.Append("-");
        sb.Append(">");
      }
      sb.Append("  Index  Item");
      return sb.ToString();
    }

    public static int GetLength(string Size)
    {
      int x = int.Parse(Size.Substring(0, 2), System.Globalization.NumberStyles.HexNumber) / 2;
      int y = int.Parse(Size.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
      return x * y;
    }
  }
}
