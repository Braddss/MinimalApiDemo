namespace BenchmarkMinApi.Models
{
    public class CharCountModel : BaseModel
    {
        public required char[] CharsToCount { get; set; }
    }
}
