using System.Collections.Generic;

namespace WhereClause.Functions.Builtin
{
    [Function("contains")]
    public class StringContains : IFunction
    {
        public bool Eval(List<object> operands)
        {
            this.CheckOperandCount(2, operands);
            var a = operands[0] as string;
            var b = operands[1] as string;
            if (a is null || b is null) return false;
            return a.Contains(b);
        }
    }

}

