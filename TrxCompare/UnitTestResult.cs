using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrxCompare
{
   [Serializable]
   public class UnitTestResult
   {
      [XmlAttribute("executionId")]
      public Guid ExecutionId;

      [XmlAttribute("testId")]
      public Guid TestId;

      [XmlAttribute("testName")]
      public string? TestName;

      [XmlAttribute("computerName")]
      public string? ComputerName;

      [XmlAttribute("duration")]
      public string? Duration;

      [XmlAttribute("startTime")]
      public DateTime StartTime;

      [XmlAttribute("endTime")]
      public DateTime EndTime;

      [XmlAttribute("testType")]
      public Guid TestType;

      [XmlAttribute("outcome")]
      public UnitTestOutcome Outcome;

      [XmlAttribute("testListId")]
      public Guid TestListId;

      [XmlAttribute("relativeResultsDirectory")]
      public Guid RelativeResultsDirectory;

      [XmlArray("ResultFiles")]
      [XmlArrayItem("ResultFile", typeof(ResultFile))]
      public List<ResultFile>? ResultFiles;

      [XmlElement("Output", IsNullable = true)]
      public UnitTestResultOutput? Output;
   }
}