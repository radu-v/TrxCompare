using System;
using System.Xml.Serialization;

namespace TrxCompare
{
   [Serializable]
   public class UnitTestResultOutput
   {
      [XmlElement("ErrorInfo")]
      public ErrorInfo? ErrorInfo;
   }
}