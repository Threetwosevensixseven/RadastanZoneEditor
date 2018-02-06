using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadastanZoneEditor.Classes
{
  public static class ListByteExtensions
  {
    public static byte GetRadastanByte(this List<Byte> Bytes, int X, int Y)
    {
      return Bytes[(Y * 64) + (X / 2)];
    }
  }
}
