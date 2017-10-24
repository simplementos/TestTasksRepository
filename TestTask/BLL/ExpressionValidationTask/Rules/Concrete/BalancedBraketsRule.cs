

using BLL.ExpressionValidationTask.Abstract.Rules;

namespace BLL.ExpressionValidationTask.Rules.Concrete
{
    public class BalancedBracketsRule : IBalancedBracketsRule
    {
        public BalancedBracketsRule(string name, string errorMessage, BracketsType bracketsType)
        {
            BracketsType = bracketsType;
            Name = name;
            ErrorMessage = errorMessage;
        }

        public BracketsType BracketsType { get; set; }

        public string ErrorMessage { get; }

        public string Name { get; }

        public bool IsComplied(string input)
        {
            bool result = false;

            char leftBracket = '\0';
            char rightBracket = '\0';

            switch (BracketsType)
            {
                case BracketsType.Curly:
                    //leftBracketPattern = @"[{]";
                    //rightBracketPattern = @"[}]";
                    leftBracket = '{';
                    rightBracket = '}';
                    break;
                case BracketsType.Round:
                    //leftBracketPattern = @"[(]";
                    //rightBracketPattern = @"[)]";
                    leftBracket = '(';
                    rightBracket = ')';
                    break;
                case BracketsType.Square:
                    //leftBracketPattern = @"[[]";
                    //rightBracketPattern = @"[]]";
                    leftBracket = '[';
                    rightBracket = ']';
                    break;
                case BracketsType.Corner:
                    //leftBracketPattern = @"[<]";
                    //rightBracketPattern = @"[>]";
                    leftBracket = '<';
                    rightBracket = '>';
                    break;
            }

            int count = 0;

            foreach (var item in input)
            {
                if (item == leftBracket)
                {
                    count++;
                }
                if (item == rightBracket)
                {
                    count--;
                }
                if (count < 0)
                {
                    result = true;
                }
            }
            if (count > 0)
            {
                result = true;
            }

            return result;
        }
    }
}
