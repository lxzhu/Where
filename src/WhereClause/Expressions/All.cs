using System.Collections.Generic;
using System.Linq;

namespace WhereClause.Expressions
{
    public class All :  List<IExpression>, IExpression
    {
        
        public bool Eval(IExpressionContext context)
        {
            return this.All(expr => expr.Eval(context));
        }
    }
}

