namespace MinimalApiDemo.RequestModels
{
    public class WordCountModel : BaseModel
    {
        public required string[] WordsToCount { get; set; }
    }
}
