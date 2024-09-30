namespace BenchmarkMinApi.Models
{
    public class WordCountModel : BaseModel
    {
        public required string[] WordsToCount { get; set; }
    }
}
