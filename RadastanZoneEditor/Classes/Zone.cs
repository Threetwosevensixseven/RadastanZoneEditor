using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadastanZoneEditor.Classes
{
  public class Zone
  {
    private int _height;
    private Zones _parent;
    public int CLUT { get; set; }

    private Zone()
    {
    }

    public Zone(Zones Parent)
    {
      _parent = Parent;
    }

    internal void Reparent(Zones Zones)
    {
      _parent = Zones;
    }

    public int Height
    {
      get
      {
        if (_parent.Items.Count == 1)
          return 96;
        if (!IsLastZone)
          return _height;
        var others = _parent.Items.Where(z => z != this).Select(z => z.Height).Sum();
        var thisH = 96 - others;
        if (thisH == 0)
          thisH = 1;
        var total = others + thisH;
        if (total > 96)
          _parent.Items[0].Height = _parent.Items[0].Height - (total - 96);
        return thisH;
      }
      set
      {
        _height = value;
      }
    }

    public bool IsLastZone
    {
      get
      {
        return this == _parent.Items[_parent.Items.Count - 1];
      }
    }

    public int Index
    {
      get
      {
        for (int i = 0; i < _parent.Items.Count; i++)
        {
          if (_parent.Items[i] == this)
            return i;
        }
        throw new Exception("Zone is not in parent.");
      }
    }

    public int DefaultCLUT
    {
      get
      {
        return Math.Max(Math.Min(Index, 3), 0);
      }
    }

    public int IndexToCLUT(int Index)
    {
      if (Index >= 4)
        return -1;
      return Index;
    }

    public int CLUTToIndex(int CLUT)
    {
      if (CLUT < 0)
        return 4;
      return Index;
    }
  }
}
