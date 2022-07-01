using System.Collections.Generic;

namespace WhereClause.Functions.Builtin
{
    [Function("contains any")]
    public class ContainsAny : IFunction
    {
        public virtual bool Eval(List<object> operands)
        {
            this.CheckOperandCount(2, operands);
            var t = this.CastOperandAsElementT2(operands);
            return CollectionUtils.ContainsAny(t.Item1, t.Item2);
        }
    }

}

