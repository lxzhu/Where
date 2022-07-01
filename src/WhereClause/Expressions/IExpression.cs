using System;

namespace WhereClause.Expressions
{
    public interface IExpression
	{
		bool Eval(IExpressionContext context);
	}
}

