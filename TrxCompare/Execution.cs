using System;
using System.Xml.Serialization;

namespace TrxCompare
{
   [Serializable]
   public class Execution
   {
      [XmlAttribute("id")]
      public Guid Id;
   }
}