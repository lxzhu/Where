using System;
using System.Collections.Generic;
using System.Linq;

namespace WhereClause.Functions.Builtin
{
    [Function(">", "gt", "greatThan")]
    public class GreatThan : IFunction
    {
        public bool Eval(List<object> operands)
        {
            if (operands == null)
                throw new Exception($"Function {nameof(GreatThan)} require two operands.");
            if (operands.Count != 2)
                throw new Exception($"Function {nameof(GreatThan)} requires two operands.");
            var t = this.CastOperandT2(operands);
            return Compare.CompareObjects(t.Item1, t.Item2) > 0;
        }
    }

}

