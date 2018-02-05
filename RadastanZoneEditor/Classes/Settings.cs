using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RadastanZoneEditor.Classes
{
  public class Settings
  {
    public List<string> Recent { get; set; }
    public Tiles Tiles { get; set; }

    public Settings()
    {
      Recent = new List<string>();
      Tiles = new Tiles();
    }

    public static Settings Load()
    {
      var settings = new Settings();
      var fn = Settings.FileName;
      if (File.Exists(fn))
      {
        string xml = File.ReadAllText(fn);
        settings = FromXML(xml);
      }
      settings.Save();
      return settings;
    }

    public bool Save()
    {
      bool success = true;
      try
      {
        var fn = Settings.FileName;
        string xml = ToXML();
        File.WriteAllText(fn, xml);
      }
      catch (Exception ex)
      {
        success = false;
      }
      return success;
    }

    public void AddRecentFile(string FileName)
    {
      if (string.IsNullOrWhiteSpace(FileName))
        return;
      while (Recent.Contains(FileName))
        Recent.Remove(FileName);
      Recent = Recent.Take(9).ToList();
      Recent.Insert(0, FileName);
    }

    private string ToXML()
    {
      XmlSerializer serializer = new XmlSerializer(typeof(Settings));
      StringWriter writer = new StringWriter();
      using (writer)
      {
        serializer.Serialize(writer, this);
        writer.Close();
        return writer.ToString().Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"");
      }
    }

    private static Settings FromXML(string Xml)
    {
      Settings settings;
      try
      {
        StringReader reader = new StringReader(Xml);
        using (reader)
        {
          XmlSerializer serializer = new XmlSerializer(typeof(Settings));
          settings = (Settings)serializer.Deserialize(reader);
          reader.Close();
        }
      }
      catch
      {
        settings = new Settings();
      }
      return settings;
    }

    private static string _fileName;
    private static string FileName
    {
      get
      {
        if (_fileName == null)
        {
          string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
          path = Path.Combine(path, "SevenFFF");
          path = Path.Combine(path, "RadastanZoneEditor");
          if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
          _fileName = Path.Combine(path, "RadastanZoneEditor.settings");
        }
        return _fileName;
      }
    }

    [DllImport("shlwapi.dll", CharSet = CharSet.Auto)]
    private static extern bool PathCompactPathEx([Out] StringBuilder pszOut, string szPath, int cchMax, int dwFlags);

    public static string ShortenPath(string path, int length)
    {
      StringBuilder sb = new StringBuilder(260);
      PathCompactPathEx(sb, path, length, 0);
      return sb.ToString();
    }
  }
}
