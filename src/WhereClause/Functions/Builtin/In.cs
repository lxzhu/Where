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
            var t = this.CastOperandAsArrayT2(operands);
            return CollectionUtils.In(t.Item1, t.Item2);
        }
    }

}

