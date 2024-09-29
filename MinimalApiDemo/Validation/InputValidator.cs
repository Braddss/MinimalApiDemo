using MinimalApiDemo.Validation.Interfaces;

namespace MinimalApiDemo.Validation
{
    internal class InputValidator : IInputValidator
    {
        public bool CheckHasDuplicates(IEnumerable<string> inputStrings)
        {
            var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var input in inputStrings)
            {
                if (!set.Add(input))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
