using System;
using System.Collections.Generic;

namespace WhereClause.Functions.Builtin
{
    [Function("contains")]
    public class Contains : IFunction
    {
        public virtual bool Eval(List<object> operands)
        {
            if (operands == null)
                throw new Exception($"Function {nameof(Contains)} require two operands.");
            if (operands.Count != 2)
                throw new Exception($"Function {nameof(Contains)} requires two operands.");
            
            return CollectionUtils.Contains(operands[0],operands[1]);
        }
        

    }
    
}

