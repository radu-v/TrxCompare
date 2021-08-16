using System;

namespace TrxCompare
{
   public class TestRunResult
   {
      public Guid Id;
      public string? Class;
      public string? Name;
      public UnitTestOutcome Outcome;

      public string FullName => $"{Class}.{Name}";
   }
}