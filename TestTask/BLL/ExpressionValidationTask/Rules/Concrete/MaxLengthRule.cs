

using BLL.ExpressionValidationTask.Abstract.Rules;

namespace BLL.ExpressionValidationTask.Rules.Concrete
{
    public class MaxLengthRule : IRule
    {
        public int MaxLength { get; set; }

        public MaxLengthRule(string name, string errorMessage, int maxLength)
        {
            MaxLength = maxLength;
            Name = name;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; set; }

        public string Name { get; set; }

        public bool IsComplied(string input)
        {
            if (input.Length > MaxLength)
            {
                return true;
            }
            return false;
        }
    }
}
