namespace MinimalApiDemo.RequestModels
{
    public class WordCountModel
    {
        public required string Text { get; set; }

        public required string[] WordsToCount { get; set; }
    }
}
