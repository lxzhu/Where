using System;
using System.Collections.Generic;

namespace WhereClause.Functions.Builtin
{
    [Function("==")]
    public class Equals : IFunction
    {
        public bool Eval(List<object> operands)
        {
            this.CheckOperandCount(2, operands);
            var t = this.CastOperandT2(operands);
            return Compare.CompareObjects(t.Item1, t.Item2) == 0;
        }
    }

}

