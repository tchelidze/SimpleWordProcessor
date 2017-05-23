namespace RemoveStopWords.Base
{
    public abstract class StringProcessorBase
    {
        public abstract (string Output, int RemovedEntries) Process(string what);
    }
}