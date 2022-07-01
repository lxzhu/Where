using System.Collections.Generic;
using System.Linq;
using WhereClause.Functions;

namespace WhereClause.Expressions
{
    public class FunctionExpression : IFunctionExpression
    {
        public List<string> OperandTexts { get; set; } = new List<string>();

        protected List<object> Operands { get; set; }

        protected IExpressionContext Context { get; set; }

        public FunctionExpression() { }
        public FunctionExpression(params string[] operands)
        {
            if (operands != null)
                this.OperandTexts.AddRange(operands);
        }

        public bool Eval(IExpressionContext context)
        {
            this.Context = context;
            var functionName = this.OperandTexts[0];
            var attributeName = this.OperandTexts[1];
            var otherOperands = this.OperandTexts
                .Skip(2).ToList();

            var attribute = this.Context.Attributes.Read(attributeName);
            if (attribute is null)
            {
                throw new System.Exception($"Fail to solve attribute {attributeName}");
            }

            var function = this.Context.Functions.Resolve(
                functionName, attribute.Type);

            var arguments = new List<object>() { attribute.Value };
            arguments.AddRange(otherOperands);

            return function.Eval(arguments);
        }
    }
}

