using System;
using System.Collections.Generic;

namespace WhereClause.Functions.Builtin
{
    [Function("in")]
    public class In : IFunction
    {
        public bool Eval(List<object> operands)
        {
            this.CheckOperandCount(2, operands);
            var t = this.CastOperandAsArrayT2(operands);
            return CollectionUtils.In(t.Item1, t.Item2);
        }
    }

}

