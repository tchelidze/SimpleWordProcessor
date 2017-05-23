using RemoveStopWords.Base;

namespace RemoveStopWords.Core
{
    public class ReturnCarriageProcessor : StringProcessorBase
    {
        public override (string Output, int RemovedEntries) Process(string what)
        {
            const string pattern = "\r\n";
            const string replacement = " ";
            var newValue = what.Replace(pattern, replacement);

            return (newValue, (what.Length - newValue.Length) / (pattern.Length - replacement.Length));
        }
    }
}