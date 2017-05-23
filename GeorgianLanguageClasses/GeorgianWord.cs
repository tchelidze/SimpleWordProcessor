using System;
using System.Linq;

namespace GeorgianLanguageClasses
{
    public static class GeorgianWord
    {
        public static bool IsGeorgianWord(string word)
        {
            return ((word.Length > 1 ? 1 : 0) & (ConsistsOfGeorgianCharactersAnd(word, new char[1]
                    {
                        '-'
                    })
                        ? 1
                        : 0) & (!IncludesTwoSameConsonantsFollowing(word) ? 1 : 0) &
                    (!IncludesFourSameVowelsFollowing(word) ? 1 : 0)) != 0;
        }

        public static bool ConsistsOfGeorgianCharactersAnd(string word, char[] charr)
        {
            foreach (var ch in word)
                if (!charr.Contains(ch) && (ch < 4304) | (ch > 4336))
                    return false;
            return true;
        }

        public static bool IncludesTwoSameConsonantsFollowing(string word)
        {
            if (word.Length > 2)
                for (var index = 1; index < word.Length; ++index)
                    if (GeorgianAlphabet.Tanxmovnebi.Contains(word.ElementAt(index)) &
                        (word.ElementAt(index) == word.ElementAt(index - 1)))
                        return true;
            return false;
        }

        public static bool IncludesFourSameVowelsFollowing(string word)
        {
            if (word.Length > 4)
                try
                {
                    for (var index = 1; index < word.Length; ++index)
                        if (GeorgianAlphabet.Xmovnebi.Contains(word.ElementAt(index)) &
                            (word.ElementAt(index) == word.ElementAt(index - 1)) &
                            (word.ElementAt(index) == word.ElementAt(index - 2)) &
                            (word.ElementAt(index) == word.ElementAt(index - 3)))
                            return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            return false;
        }

        public static bool IsGeorgianPhrase(string phrase)
        {
            return ConsistsOfGeorgianCharactersAnd(phrase, new char[2]
            {
                '-',
                ' '
            }) & !IncludesTwoSameConsonantsFollowing(phrase) & !IncludesFourSameVowelsFollowing(phrase);
        }

        public static bool ConsistsOfGeorgianCharactersAndSpace(string word)
        {
            foreach (var ch in word)
                if (ch != 32 && (ch < 4304) | (ch > 4336))
                    return false;
            return true;
        }
    }
}