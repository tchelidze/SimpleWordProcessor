using System;

namespace RemoveStopWords.Base
{
    public abstract class ConditionalTrimmerStringProcessorBase : StringProcessorBase
    {
        protected abstract Func<string, bool> RemoveCondition { get; }

        public override (string Output, int RemovedEntries) Process(string what)
        {
            var words = what.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var removedEntries = 0;
            var output = "";
            foreach (var word in words)
            {
                if (!RemoveCondition(word))
                    output = output + " " + word;
                else
                    ++removedEntries;
            }
            return (output, removedEntries);
        }
    }
}