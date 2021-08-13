using System;
using System.Xml.Serialization;

namespace TrxCompare
{
   [Serializable]
   public class ResultFile
   {
      [XmlAttribute("path")]
      public string? Path;
   }
}