namespace MinimalApiDemo.Validation.Interfaces
{
    internal interface IInputValidator
    {
        public bool CheckHasDuplicates(IEnumerable<string> inputStrings);
    }
}
