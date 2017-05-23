using System;
using System.Collections.Generic;
using System.Linq;

namespace GeorgianLanguageClasses
{
    public class GeorgianTextParser
    {
        static readonly string[] splittersForWords = new string[9]
        {
            "\t",
            "\r\n",
            ">",
            "<",
            ".",
            ",",
            "?",
            "!",
            " "
        };

        static readonly string[] splittersForPhrases = new string[8]
        {
            "\t",
            "\r\n",
            ">",
            "<",
            ".",
            ",",
            "?",
            "!"
        };

        static readonly char[] trimmers = new char[15]
        {
            '>',
            '<',
            ' ',
            '/',
            ',',
            '.',
            ':',
            '!',
            '?',
            '=',
            '\\',
            '"',
            '-',
            '_',
            ';'
        };

        public static List<string> ParseWords(string html)
        {
            var source = new List<string>();
            if (html != null)
            {
                var list = html.Split(splittersForWords, StringSplitOptions.None).ToList();
                source.Count();
                foreach (var str in list)
                {
                    var word = str.Trim(trimmers);
                    if ((word.Length > 1) & GeorgianWord.IsGeorgianWord(word))
                        source.Add(word);
                }
            }
            return source;
        }

        public static List<string> ParsePhrases(string html)
        {
            var stringList = new List<string>();
            if (html != null)
                foreach (var str in html.Split(splittersForPhrases, StringSplitOptions.None).ToList())
                {
                    var phrase = str.Trim(trimmers);
                    if (phrase.Length > 1 && GeorgianWord.IsGeorgianPhrase(phrase))
                        stringList.Add(phrase);
                }
            return stringList;
        }
    }
}