
namespace BLL.ExpressionValidationTask.Abstract.Rules
{
    public interface IRule
    {
        string Name { get; }
        string ErrorMessage { get; }
        bool IsComplied(string input);
    }
}
