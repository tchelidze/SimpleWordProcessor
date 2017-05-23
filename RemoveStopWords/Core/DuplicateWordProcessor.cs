using System;
using System.Linq;
using WordProcessor.Base;

namespace RemoveStopWords.Core
{
    public class DuplicateWordProcessor : StringProcessorBase
    {
        public override (string Output, int RemovedEntries) Process(string what)
        {
            var all = what.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var unique = all.Distinct().ToList();
            return (unique.Aggregate("", (acc, cur) => $"{acc} {cur}"), all.Length - unique.Count);
        }
    }
}