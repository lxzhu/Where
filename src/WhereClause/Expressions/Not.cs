namespace WhereClause.Expressions
{
    public class Not : IExpression
    {
        public IExpression InnerExpression { get; set; }
        
        public bool Eval(IExpressionContext context)
        {
            return !InnerExpression.Eval(context);
        }
    }
}

