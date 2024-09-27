namespace MinimalApiDemo.RequestModels
{
    public class WordCountRequest
    {
        public required string Text { get; set; }

        public required string[] WordsToCount { get; set; }
    }
}
