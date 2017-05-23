using System.Collections.Generic;
using RemoveStopWords.Base;

namespace RemoveStopWords.Core
{
    public class StopwordProcessor : TrimmerProcessorBase
    {
        protected override List<string> Set => new List<string>
        {
            "და",
            "რომ",
            "თუ",
            "არა",
            "რათა",
            "რაკი",
            "ვიდრე",
            "ვინც",
            "რაც",
            "რომელიც",
            "როგორიც",
            "სადაც",
            "საიდანაც",
            "საითკენაც",
            "როდესაც",
            "მაგრამ",
            "ხოლო",
            "თორემ",
            "ან",
            "ანუ"
        };
    }
}