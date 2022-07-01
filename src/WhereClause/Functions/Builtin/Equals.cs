using System;
using System.Collections.Generic;

namespace WhereClause.Functions.Builtin
{
    [Function("==")]
    public class Equals : IFunction
    {
        public bool Eval(List<object> operands)
        {
            if(operands == null)
                throw new Exception($"Function {nameof(Equals)} require two operands.");
            if (operands.Count != 2)
                throw new Exception($"Function {nameof(Equals)} requires two operands.");

            return Compare.CompareObjects(operands[0], operands[1]) == 0;
        }
    }

}

