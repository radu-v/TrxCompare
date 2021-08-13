using System;
using System.Xml.Serialization;

namespace TrxCompare
{
   [Serializable]
   public class ErrorInfo
   {
      [XmlElement("Message", Type = typeof(string))]
      public string? Message;
      
      [XmlElement("StackTrace", Type = typeof(string))]
      public string? StackTrace;
   }
}