using System;
using GeorgianLanguageClasses;
using WordProcessor.Base;

namespace RemoveStopWords.Core
{
    public class NonGeorgianWordsProcessor : ConditionalTrimmerStringProcessorBase
    {
        protected override Func<string, bool> RemoveCondition => it => !GeorgianWord.IsGeorgianWord(it);
    }
}