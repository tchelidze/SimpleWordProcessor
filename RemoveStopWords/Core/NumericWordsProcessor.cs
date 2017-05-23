using System.Collections.Generic;
using WordProcessor.Base;

namespace RemoveStopWords.Core
{
    public class NumericWordsProcessor : TrimmerProcessorBase
    {
        protected override List<string> Set => new List<string>
        {
            "ერთი",
            "ორი",
            "სამი",
            "ოთხი",
            "ხუთი",
            "ექვსი",
            "შვიდი",
            "რვა",
            "ცხრა",
            "ათი",
            "თერთმეტი",
            "თორმეტი",
            "ცამეტი",
            "თოთხმეტი",
            "თხუთმეტი",
            "თექვსმეტი",
            "ჩვიდმეტი",
            "თვრამეტი",
            "ცხრამეტი",
            "ოცი"
        };
    }
}