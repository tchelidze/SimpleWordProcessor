using System.Collections.Generic;
using System.Linq;

namespace RemoveStopWords.Core
{
    public static class RegexUtils
    {
        public static string ToMatcherRegex(this IEnumerable<string> what)
            => what.Aggregate("", (acc, cur) => $@"{acc}|(?<=[\s]){cur}(?=[\s])").Remove(0, 1);
    }
}