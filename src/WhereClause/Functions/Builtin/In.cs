using System;
using System.Collections.Generic;

namespace WhereClause.Functions.Builtin
{
    [Function("in")]
    public class In : IFunction
    {
        public bool Eval(List<object> operands)
        {
            if (operands == null)
                throw new Exception($"Function {nameof(In)} require two operands.");
            if (operands.Count != 2)
                throw new Exception($"Function {nameof(In)} requires two operands.");
            return CollectionUtils.In(operands[0], operands[1]); 
        }
    }
    
}

