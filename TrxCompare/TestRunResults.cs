using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TrxCompare
{
   public class TestRunResults : IDictionary<Guid, TestRunResult>
   {
      readonly IDictionary<Guid, TestRunResult> _testRunResults;

      public TestRunResults(TestRunResults other)
      {
         _testRunResults = new Dictionary<Guid, TestRunResult>(other);
      }

      public TestRunResults(IEnumerable<KeyValuePair<Guid, TestRunResult>> enumerable)
      {
         _testRunResults = enumerable.ToDictionary(x => x.Key, x => x.Value);
      }

      public TestRunResults(TestRun testRun)
      {
         var resultDict = testRun.Results.ToDictionary(x => x.TestId, x => x.Outcome);

         _testRunResults = testRun.TestDefinitions
            .Where(x => x.Name != null)
            .ToDictionary(x => x.Id, x =>
            {
               resultDict.TryGetValue(x.Id, out var outcome);
               return new TestRunResult { Id = x.Id, Class = x.TestMethod?.ClassName, Name = x.Name, Outcome = outcome };
            });
      }
      
      IEnumerator<KeyValuePair<Guid, TestRunResult>> IEnumerable<KeyValuePair<Guid, TestRunResult>>.GetEnumerator() => _testRunResults.GetEnumerator();

      public void Add(KeyValuePair<Guid, TestRunResult> item) => throw new ReadOnlyException();

      public void Clear() => throw new ReadOnlyException();

      public bool Contains(KeyValuePair<Guid, TestRunResult> item) => _testRunResults.Contains(item);

      public void CopyTo(KeyValuePair<Guid, TestRunResult>[] array, int arrayIndex) => _testRunResults.CopyTo(array, arrayIndex);

      public bool Remove(KeyValuePair<Guid, TestRunResult> item) => throw new ReadOnlyException();

      public int Count => _testRunResults.Count;

      public bool IsReadOnly => true;

      public void Add(Guid key, TestRunResult value) => throw new ReadOnlyException();

      public bool ContainsKey(Guid key) => _testRunResults.ContainsKey(key);

      public bool Remove(Guid key) => throw new ReadOnlyException();

      public bool TryGetValue(Guid key, out TestRunResult value) => _testRunResults.TryGetValue(key, out value);

      public TestRunResult this[Guid key]
      {
         get => _testRunResults[key];
         set => _testRunResults[key] = value;
      }

      public ICollection<Guid> Keys => _testRunResults.Keys;

      public ICollection<TestRunResult> Values => _testRunResults.Values;

      public IEnumerator GetEnumerator() => _testRunResults.GetEnumerator();
   }
}