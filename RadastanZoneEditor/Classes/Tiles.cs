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
    public bool ShowCurrent { get; set; }
    public bool ShowOthers { get; set; }

    public Tiles()
    {
      Sets = new List<Tile>();
    }
  }
}
