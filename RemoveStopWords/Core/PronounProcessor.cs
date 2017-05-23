﻿using System.Collections.Generic;
using RemoveStopWords.Base;

namespace RemoveStopWords.Core
{
    public class PronounProcessor : TrimmerProcessorBase
    {
        protected override List<string> Set => new List<string>
        {
            "მე",
            "ჩვენ",
            "შენ",
            "თქვენ",
            "ის",
            "ისინი",
            "ეს",
            "ეგ",
            "ის",
            "ასეთი",
            "ეგეთი",
            "ისეთი",
            "ამნაირი",
            "მაგნაირი",
            "იმნაირი",
            "ამისთანა",
            "მაგისთანა",
            "იმისთანა",
            "ამდენი",
            "მაგდენი",
            "იმდენი",
            "ჩემი",
            "ჩვენი",
            "შენი",
            "თქვენი",
            "მისი",
            "მათი",
            "ვინ",
            "რა",
            "როგორი",
            "რანაირი",
            "რამდენი",
            "სადაური",
            "როდინდელი",
            "ვისი",
            "რისი",
            "ვინც",
            "რაც",
            "რომელიც",
            "როგორიც",
            "რამდენიც",
            "რანაირიც",
            "ვისიც",
            "რისიც",
            "სადაურიც",
            "როდინდელიც",
            "თქვენი",
            "არავინ",
            "ვერავინ",
            "ნურავინ",
            "არაფერი",
            "ვერაფერი",
            "ნურაფერი",
            "არარა",
            "ვერა",
            "ნურა",
            "ვიღაც",
            "რაღაც",
            "რომელიღაც",
            "როგორიღაც",
            "ვინმე",
            "რამე",
            "რომელიმე",
            "როგორიმე",
            "ერთი",
            "კაცი",
            "ზოგი",
            "ზოგიერთი",
            "თვით",
            "თვითონ",
            "თითოეული",
            "ყოველი",
            "ყველა",
            "თქვენი"
        };
    }
}