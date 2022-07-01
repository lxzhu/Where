using System;
using System.Collections.Generic;
using System.Linq;
using WhereClause.Functions;
namespace WhereClause.Functions.Builtin
{
    [Function("is null")]
	public class IsNull:IFunction
	{
        public bool Eval(List<object> operands)
        {
            if (operands == null || operands.Count!=1)
                throw new Exception($"Function {nameof(IsNull)} requires one operand.");

            var firstOperand = operands.First();
            return firstOperand is null;
        }
    }

}

