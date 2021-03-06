using System;
using System.Collections.Generic;

namespace WhereClause.Functions.Builtin
{
    [Function("contains")]
    public class Contains : IFunction
    {
        public virtual bool Eval(List<object> operands)
        {
            this.CheckOperandCount(2, operands);
            var t = this.CastOperandAsElementT2(operands);
            return CollectionUtils.Contains(t.Item1, t.Item2);
        }
    }

}

