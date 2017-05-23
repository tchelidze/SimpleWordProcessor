namespace WordProcessor.Base
{
    public abstract class StringProcessorBase
    {
        public abstract (string Output, int RemovedEntries) Process(string what);
    }
}