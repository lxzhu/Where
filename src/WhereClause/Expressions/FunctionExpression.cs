using System.Collections.Generic;
using System.Linq;
using WhereClause.Functions;

namespace WhereClause.Expressions
{
    public  class FunctionExpression : IFunctionExpression
    {
        public List<string> OperandTexts { get; set; } = new List<string>();

        protected List<object> Operands { get; set; }

        protected IExpressionContext Context { get; set; }

        public FunctionExpression() {  }
        public FunctionExpression(params string[] operands)
        {
            if(operands!=null)
             this.OperandTexts.AddRange(operands);
        }

        public bool Eval(IExpressionContext context)
        {
            this.Context = context;
            var functionName = this.OperandTexts[0];
            var functionGroup = this.Context.Functions.GetFunctionGroup(functionName);
            var attributeName = this.OperandTexts[1];
            var attribute = this.Context.Attributes.Read(attributeName);

            if(attribute is null)
            {
                throw new System.Exception($"Fail to solve attribute {attributeName}");
            }

            var attributeType = attribute.Type;
            
            IFunctionActivator functionActivator = null;

            if (attributeType!=null && functionGroup.ContainsKey(attribute.Type))
            {
                functionActivator = functionGroup[attribute.Type];
            }

            if(functionActivator is null && functionGroup.ContainsKey(typeof(AnyType))){
                functionActivator = functionGroup[typeof(AnyType)];
                attributeType = typeof(AnyType);
            }

            if (functionActivator is null)
                throw new System.Exception($"Failed to solve function {functionName} for type {attribute.Type?.Name ?? attributeType.Name}");

            var functionKey = new FunctionKey() { Name = functionName, OperandType = attribute.Type ?? attributeType };

            var function = functionActivator.CreateFunction(functionKey);
            var otherOperands = this.OperandTexts
                .Skip(2)
                .Select(x => Convert.ConvertText(x, attribute.Type??attributeType))
                .ToList();
            var arguments = new List<object>() { attribute.Value };
            arguments.AddRange(otherOperands);

            return function.Eval(arguments);
        }
    }
}

