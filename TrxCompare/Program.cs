using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TrxCompare
{
   class Program
   {
      static void Main(string[] args)
      {
         if (args.Length < 2)
         {
            ShowUsage();
            return;
         }
         
         var trxLeft = args[0];
         var trxRight = args[1];

         var testRunLeft = new TestRunResults(LoadTestRun(trxLeft));
         var testRunRight = new TestRunResults(LoadTestRun(trxRight));

         var inLeftButNotRight = new TestRunResults(testRunLeft.Where(x => !testRunRight.Keys.Contains(x.Key)));
         var inRightButNotLeft = new TestRunResults(testRunRight.Where(x => !testRunLeft.Keys.Contains(x.Key)));
         var inBoth = testRunLeft.Where(x => testRunRight.Keys.Contains(x.Key)).Select(x => x.Key);
         
         Console.WriteLine(@$"""Comparing:"",""{trxLeft}"",""{trxRight}""");

         Console.WriteLine("Tests removed:");
         foreach (var (_, test) in  inLeftButNotRight)
         {
            Console.WriteLine($"\"{test.FullName}\", \"{test.Outcome}\"");
         }
            
         Console.WriteLine("Tests added:");
         foreach (var (_, test) in inRightButNotLeft)
         {
            Console.WriteLine($"\"{test.FullName}\", \"{test.Outcome}\"");
         }

         Console.WriteLine("Tests changed outcome:");
         foreach (var testId in inBoth)
         {
            var left = testRunLeft[testId];
            var right = testRunRight[testId];
            if (left.Outcome == right.Outcome) continue;
            
            Console.WriteLine($"\"{left.FullName}\",\"{left.Outcome}\",\"{right.Outcome}\"");
         }
      }

      private static void ShowUsage()
      {
         Console.WriteLine("Usage: TrxCompare.exe left.trx right.trx");
         Console.WriteLine();
      }

      private static TestRun LoadTestRun(string trxFilePath)
      {
         var serializer = new XmlSerializer(typeof(TestRun));
         using var reader = new StreamReader(trxFilePath);
         return (TestRun)(serializer.Deserialize(reader) ?? throw new SerializationException());
      }
   }
}