namespace WhereClause.Expressions
{
    public class Always : IExpression
    {
        public bool Result { get; set; }
        public Always(bool result = false) => Result = result;

        public bool Eval(IExpressionContext context)
        {
            return this.Result;
        }
    }
}

