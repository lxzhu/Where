using System.Collections.Generic;
using System.Linq;
using WhereClause.Functions;

namespace WhereClause.Expressions
{
    public class FunctionExpression : IFunctionExpression
    {
        public string FunctionName { get; set; } = string.Empty;
        
        public List<string> OperandTexts { get; set; } = new List<string>();

        protected IExpressionContext Context { get; set; }

        public FunctionExpression() { }
        
        public FunctionExpression(
            string functionName,
            params string[] operands)
        {
            this.FunctionName = functionName;
            if (operands != null)
                this.OperandTexts.AddRange(operands);
        }

        public static FunctionExpression Svo(
            string subject,
            string function,
            params object[] values)
        {
            if (values == null)
                values = new object[] { };
            var operands = values
                .Select(x => x!=null?x.ToString():(string)null)
                .ToList();
            operands.Insert(0, subject);
            return new FunctionExpression(function,operands.ToArray());
        }

        public virtual bool Eval(IExpressionContext context)
        {
            this.Context = context;

            var attributes = this.OperandTexts.Select(x =>
            {
                Attribute attribute = null;
                
                if (x.StartsWith("$"))
                { 
                    attribute=this.Context.Attributes.Read(x);
                }
                else
                {
                    var literal = x;
                    if (x.StartsWith("\\$"))
                        literal = x.Substring(1);
                    attribute = this.Context.Literals.Guess(literal);
                }
                return attribute ?? new Attribute(x, x);
            }).ToList();

            var firstAttributeType = attributes.Select(x => x.Type)
                .FirstOrDefault();
            var function = this.Context.Functions.Resolve(
                this.FunctionName, firstAttributeType ?? typeof(AnyType));

            var arguments = attributes.Select(x => x.Value).ToList();
            return function.Eval(arguments);
        }
    }
}

