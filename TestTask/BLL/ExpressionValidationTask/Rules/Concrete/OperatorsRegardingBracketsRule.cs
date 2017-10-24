using BLL.ExpressionValidationTask.Abstract.Rules;
 
using System.Collections.Generic;
 

namespace BLL.ExpressionValidationTask.Rules.Concrete
{
    public class OperatorsRegardingBracketsRule : IRule
    {
        public OperatorsRegardingBracketsRule(string name, string errorMessage)
        {
            Name = name;
            ErrorMessage = errorMessage;
        }

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

            string operators = "*/";
            string pattern = "";

            foreach (var item in input)
            {
                if (item == '(' || item == '{' || item == '[' || item == '<')
                {
                    foreach (var ch in operators)
                    {
                        pattern = $"{item}{ch}";

                        if (input.Contains(pattern))
                        {
                            return true;
                        }
                    }

                }
                else if (item == ')' || item == '}' || item == ']' || item == '>')
                {
                    foreach (var ch in operators)
                    {
                        pattern = $"{ch}{item}";

                        if (input.Contains(pattern))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
