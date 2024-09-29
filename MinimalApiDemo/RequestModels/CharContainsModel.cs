namespace MinimalApiDemo.RequestModels
{
    public class CharContainsModel : BaseModel
    {
        public required char[] CharsToCheck { get; set; }
    }
}
