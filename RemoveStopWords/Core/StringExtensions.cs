using System.Collections.Generic;
using System.Linq;

namespace RemoveStopWords.Core
{
    public static class StringExtensions
    {
        public static IEnumerable<string> DiscardSpacesAndGetUnique(this string input)
            => input.Split(' ').Distinct();
    }
}