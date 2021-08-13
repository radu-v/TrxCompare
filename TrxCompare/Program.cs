using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace TrxCompare
{
   class Program
   {
      static void Main(string[] args)
      {
         string sampleTrx = args[0];

         var serializer = new XmlSerializer(typeof(TestRun));
         using var reader = new StreamReader(sampleTrx);
         var testRun = (TestRun?)serializer.Deserialize(reader);

         var unitTests = testRun?.TestDefinitions.ToDictionary(
            x => x.Id,
            x => $"{x.TestMethod?.ClassName}.{x.TestMethod?.Name}"
         );

         foreach (var test in unitTests)
         {
            var outcome = testRun.Results
                  .Where(r => r.TestId == test.Key)
                  .Select(r => r.Outcome)
                  .SingleOrDefault();
            
            Console.WriteLine($"{test.Value} [{outcome}]");
         }
      }
   }
}