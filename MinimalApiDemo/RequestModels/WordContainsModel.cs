namespace MinimalApiDemo.RequestModels
{
    public class WordContainsModel
    {
        public required string Text { get; set; }

        public required string[] WordsToCheck { get; set; }
    }
}
