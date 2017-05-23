using System.Collections.Generic;
using RemoveStopWords.Base;

namespace RemoveStopWords.Core
{
    public class DelimiterProcessor : TrimmerProcessorBase
    {
        protected override List<string> Set => new List<string>
        {
            " ",
            ",",
            ";",
            "."
        };
    }
}