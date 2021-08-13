using System;
using System.Xml.Serialization;

namespace TrxCompare
{
   [Serializable]
   public class UnitTest
   {
      [XmlAttribute("name")]
      public string? Name;

      [XmlAttribute("storage")]
      public string? Storage;

      [XmlAttribute("id")]
      public Guid Id;

      [XmlElement("Execution")]
      public Execution? Execution;

      [XmlElement("TestMethod")]
      public TestMethod? TestMethod;
   }
}