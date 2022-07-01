using System.Collections.Generic;
using System;

namespace WhereClause.Functions.Builtin
{
    [Function("<","lt","lessThan")]
    public class LessThan : IFunction
    {
        public bool Eval(List<object> operands)
        {
            if (operands == null)
                throw new Exception($"Function {nameof(LessThan)} require two operands.");
            if (operands.Count != 2)
                throw new Exception($"Function {nameof(LessThan)} requires two operands.");

            return Compare.CompareObjects(operands[0], operands[1]) < 0;
        }

        
    }

}

