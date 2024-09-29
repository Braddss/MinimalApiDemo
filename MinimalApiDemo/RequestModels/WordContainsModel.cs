namespace MinimalApiDemo.RequestModels
{
    public class WordContainsModel : BaseModel
    {
        public required string[] WordsToCheck { get; set; }
    }
}
