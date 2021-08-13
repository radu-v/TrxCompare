using System;
using System.Xml.Serialization;

namespace TrxCompare
{
   [Serializable]
   public class TestMethod
   {
      [XmlAttribute("codeBase")]
      public string? CodeBase;

      [XmlAttribute("adapterTypeName")]
      public string? AdapterTypeName;

      [XmlAttribute("className")]
      public string? ClassName;

      [XmlAttribute("name")]
      public string? Name;
   }
}