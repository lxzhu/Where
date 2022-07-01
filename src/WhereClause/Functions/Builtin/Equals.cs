using System;
using System.Collections.Generic;

namespace WhereClause.Functions.Builtin
{
    [Function("==")]
    public class Equals : IFunction
    {
        public bool Eval(List<object> operands)
        {
            if (operands == null)
                throw new Exception($"Function {nameof(Equals)} require two operands.");
            if (operands.Count != 2)
                throw new Exception($"Function {nameof(Equals)} requires two operands.");
            var t = this.CastOperandT2(operands);
            return Compare.CompareObjects(t.Item1, t.Item2) == 0;
        }
    }

}

