using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrxCompare
{
   [XmlRoot(Namespace = @"http://microsoft.com/schemas/VisualStudio/TeamTest/2010", ElementName = "TestRun")]
   public class TestRun
   {
      [XmlArray(ElementName = "Results")]
      [XmlArrayItem("UnitTestResult", Type = typeof(UnitTestResult))]
      public List<UnitTestResult> Results = new();

      [XmlArray(ElementName = "TestDefinitions")]
      [XmlArrayItem("UnitTest", typeof(UnitTest))]
      public List<UnitTest> TestDefinitions = new();
   }
}