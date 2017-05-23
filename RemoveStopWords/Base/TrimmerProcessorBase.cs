using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using RemoveStopWords.Core;

namespace WordProcessor.Base
{
    public abstract class TrimmerProcessorBase
    {
        protected abstract List<string> Set { get; }

        public (string Output, int RemovedEntries) Process(string what)
        {
            what = " " + what + " ";
            var pattern = Set.Select(it => it.ToString()).ToMatcherRegex();
            var matches = Regex.Matches(what, pattern).Count;
            var processed = Regex.Replace(what, pattern, " ");
            return (processed, matches);
        }
    }
}