namespace MinimalApiDemo.RequestModels
{
    public class CharCountModel : BaseModel
    {
        public required char[] CharsToCount { get; set; }
    }
}
