using BLL.ExpressionValidationTask.Abstract.Rules;
using System.Collections.Generic;

namespace BLL.ExpressionValidationTask.Rules.Concrete
{
    public class CorrectlyPositionedBrackets : IRule
    {
        public CorrectlyPositionedBrackets(string name, string errorMessage)
        {
            Name = name;
            ErrorMessage = errorMessage;
        }

        public BracketsType BracketsType { get; set; }

        public string ErrorMessage { get; }

        public string Name { get; }


        private static char GetOpenBracket(char item)
        {
            switch (item)
            {
                case ')':
                    return '(';
                case '}':
                    return '{';
                case ']':
                    return '[';
                default:
                    return ' ';
            }
        }
        public bool IsComplied(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (var item in input)
            {
                if (item == '(' || item == '{' || item == '[' || item == '<')
                {
                    stack.Push(item);
                }
                else if (item == ')' || item == '}' || item == ']' || item == '>')
                {
                    if (stack.Count == 0) return true;
                    if (stack.Pop() != GetOpenBracket(item))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

}
