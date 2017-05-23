using System;
using System.Collections.Generic;
using System.Linq;

namespace GeorgianLanguageClasses
{
    public static class GeoWordMatcher
    {
        static char[][] foneticMatrix = new char[28][];

        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize).Select(i => str.Substring(i * chunkSize, chunkSize));
        }

        public static void UpdateFonetics()
        {
            var str1 =
                "5322100021211002010000200020052110201101100023000010003000501101010210000100002000200005100122002000010000000010000050000103110001000030001000000500010001101000220000000000005000100020202000001000000000051000000000000000000000000000520110010000000000000000000005011000000000000000000000000050002000000000000000000000000510000000001000300000000000005000020000100210000000000000050000031300000100000000000000500000000200000000000000000005200001000100000000000000000050001000020100000000000000000510001001100000000000000000005000000000000000000000000000053100110100000000000000000000500021000000000000000000000005021101000000000000000000000051002000000000000000000000000520000000000000000000000000005000000000000000000000000000050000000000000000000000000000500000000000000000000000000005";
            var chArray = new char[28][];
            var index = 0;
            foreach (var str2 in Split(str1, 28).ToList())
            {
                chArray[index] = str2.ToCharArray();
                ++index;
            }
            foneticMatrix = chArray;
        }

        public static double HowMatchStrings(string str1, string str2)
        {
            return 0.0 +
                   HowMatchStringsWithConsonants(Reverse(str1.TrimEnd(GeorgianAlphabet.Tanxmovnebi.ToCharArray())),
                       Reverse(str2.TrimEnd(GeorgianAlphabet.Tanxmovnebi.ToCharArray()))) +
                   HowMatchStringsWithVowels(Reverse(str1.TrimEnd(GeorgianAlphabet.Tanxmovnebi.ToCharArray())),
                       Reverse(str2.TrimEnd(GeorgianAlphabet.Tanxmovnebi.ToCharArray()))) + HowMatchStringsCharByChar(
                       Reverse(str1.TrimEnd(GeorgianAlphabet.Tanxmovnebi.ToCharArray())),
                       Reverse(str2.TrimEnd(GeorgianAlphabet.Tanxmovnebi.ToCharArray())));
        }

        public static double HowMatchCVPatterns(string str1, string str2)
        {
            var num1 = 0.0;
            var num2 = str1.Length < str2.Length ? str1.Length : str2.Length;
            for (var index = 0; index < num2; ++index)
                if ((GeorgianAlphabet.Xmovnebi.Contains(str1[index]) &
                     GeorgianAlphabet.Xmovnebi.Contains(str1[index])) |
                    (GeorgianAlphabet.Tanxmovnebi.Contains(str1[index]) &
                     GeorgianAlphabet.Tanxmovnebi.Contains(str2[index])))
                    ++num1;
            return num1;
        }

        public static double HowMatchStringsCharByChar(string str1, string str2)
        {
            var num1 = 0.0;
            var num2 = str1.Length < str2.Length ? str1.Length : str2.Length;
            for (var index = 0; index < num2; ++index)
                if (str1[index] == str2[index])
                    num1 += 10.0 / Math.Pow(index + 1, 2.0);
            return num1;
        }

        public static double HowMatchStringsWithVowels(string str1, string str2)
        {
            var num1 = 0.0;
            var source1 = VovelsFromString(str1);
            var source2 = VovelsFromString(str2);
            var num2 = source1.Length < source2.Length ? source1.Length : source2.Length;
            for (var index = 0; index < num2; ++index)
                if (source1.ElementAt(index) == source2.ElementAt(index))
                    num1 += 10 - index * 2;
            return num1;
        }

        public static double HowMatchStringsWithConsonants(string str1, string str2)
        {
            var source1 = ConsonantsFromString(str1);
            var source2 = ConsonantsFromString(str2);
            var num1 = 0.0;
            var num2 = source1.Length < source2.Length ? source1.Length : source2.Length;
            for (var index = 0; index < num2; ++index)
                num1 += 2 * HowMatchConstraintsPhonetically(source2.ElementAt(index), source1.ElementAt(index)) /
                        Math.Pow(index + 1, 2.0);
            return num1;
        }

        public static int HowMatchConstraintsPhonetically(char c, char d)
        {
            var ch1 = c;
            var ch2 = d;
            if (ch1 > ch2)
            {
                var ch3 = ch1;
                ch1 = ch2;
                ch2 = ch3;
            }
            var index1 = GeorgianAlphabet.Tanxmovnebi.IndexOf(ch1);
            var index2 = GeorgianAlphabet.Tanxmovnebi.IndexOf(ch2);
            return Convert.ToInt32(foneticMatrix.ElementAt(index1).ElementAt(index2)) - 48;
        }

        public static int SyllableCounter(string sit)
        {
            return VovelsFromString(sit).Length;
        }

        public static string VovelsFromString(string sit)
        {
            var str = "";
            foreach (var ch in sit)
                if (GeorgianAlphabet.Xmovnebi.Contains(ch))
                    str += ch.ToString();
            return str;
        }

        public static string ConsonantsFromString(string sit)
        {
            var str = "";
            foreach (var ch in sit)
                if (GeorgianAlphabet.Tanxmovnebi.Contains(ch))
                    str += ch.ToString();
            return str;
        }

        public static string Reverse(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}