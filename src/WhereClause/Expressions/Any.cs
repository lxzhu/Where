using System.Collections.Generic;
using System.Linq;

namespace WhereClause.Expressions
{
    public class Any : List<IExpression>, IExpression
    {
        

        public bool Eval(IExpressionContext context)
        {
            return this.Any(expr => expr.Eval(context));
        }
    }
}

