
namespace BLL.ExpressionValidationTask.Abstract.Rules
{
    public interface IBalancedBracketsRule : IRule
    {
        BracketsType BracketsType { get; set; }
    }

    public enum BracketsType { Round, Square, Curly, Corner }
}
