

using BLL.ExpressionValidationTask.Abstract.Rules;
using System.Text.RegularExpressions;

namespace BLL.ExpressionValidationTask.Rules.Concrete
{
    public class RegexRule : IRegexRule
    {
        public string RegexPattern { get; set; }

        public RegexRule(string regexPattern, string name, string errorMessage)
        {
            Name = name;
            RegexPattern = regexPattern;
            ErrorMessage = errorMessage;
        }

        public string Name { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsComplied(string input)
        {
            return Regex.IsMatch(input, RegexPattern);
        }
    }

}
