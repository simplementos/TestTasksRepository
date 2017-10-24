
using BLL.ExpressionValidationTask.Abstract.Rules;
using BLL.ExpressionValidationTask.Rules.Concrete;
using System.Collections.Generic;

namespace BLL.ExpressionValidationTask
{       
   
  

   
    public class ExpressionValidator
    {
        private Dictionary<int, IRule> _rules;

        private string _expression;

        public bool IsValid { get; protected set; }

        public ExpressionValidator(string expression)
        {
            _expression = expression;
            _rules = new Dictionary<int, IRule>();

            Forbid(new RegexRule(@"\p{L}", "letters", "Letters are not allowed"), 1);  
            Forbid(new RegexRule(@"[_!@#$%^&=|?><`~'""]", "special symbols", "These _!@#$%^&=|?><`~'\" are not allowed"), 2);
            Forbid(new BalancedBracketsRule("balancedRoundBrackets", "Not balanced round brackets", BracketsType.Round), 3);
            Forbid(new BalancedBracketsRule("balancedSquareBrackets", "Not balanced square brackets", BracketsType.Square), 4);
            Forbid(new MaxLengthRule("maxLengthRule", "Exceeding the maximum length of input", 20), 5);
            Forbid(new CorrectlyPositionedBrackets("correctlyPositionedBrackets", "Brackets are wrong positioned"), 6);
        }

        public void Forbid(IRule rule, int id)
        {
            _rules.Add(id, rule);
        }

        public void Allow(int id)
        {           
            _rules.Remove(id);
        }
       
        public Dictionary<int, IRule> GetAllRules()
        {
            return _rules;
        }

        public Dictionary<int, IRule> GetFailedRules()
        {
            var failedRules = new Dictionary<int, IRule>();

            bool complied = false;
            foreach(var rule in _rules)
            {
                if(rule.Value.IsComplied(_expression))
                {
                    complied = true;
                    failedRules.Add(rule.Key, rule.Value);                 
                }

            }
            IsValid = !complied;

            return failedRules;
        }
    }
}
