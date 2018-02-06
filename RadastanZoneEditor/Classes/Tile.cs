using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadastanZoneEditor.Classes
{
  public class Tile
  {
    private Tiles _parent;
    public int Width { get; set; }
    public int Height { get; set; }
    public int VCount { get; set; }
    public int HCount { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public string Name { get; set; }

    private Tile()
    {
    }

    public Tile(Tiles Parent)
    {
      _parent = Parent;
      Width = Height = 8;
      VCount = HCount = 1;
      X = Y = 0;
      Name = "";
    }

    internal void Reparent(Tiles Parent)
    {
      _parent = Parent;
    }

    public string Sort
    {
      get
      {
        return Width.ToString("X2") + Height.ToString("X2");
      }
    }
  }
}
