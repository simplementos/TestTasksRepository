
namespace BLL.ExpressionValidationTask.Abstract.Rules
{
    public interface IRegexRule : IRule
    {
        string RegexPattern { get; }
    }
}
