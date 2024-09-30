namespace BenchmarkMinApi.Models
{
    public class WordContainsModel : BaseModel
    {
        public required string[] WordsToCheck { get; set; }
    }
}
