namespace BenchmarkMinApi.Models
{
    public class CharContainsModel : BaseModel
    {
        public required char[] CharsToCheck { get; set; }
    }
}
