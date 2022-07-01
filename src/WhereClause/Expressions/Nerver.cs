namespace WhereClause.Expressions
{
    public class Nerver : IExpression
    {
        public bool Result { get; set; }

        public Nerver(bool result = false) => Result = result;

        public bool Eval(IExpressionContext context)
        {
            return !this.Result;
        }
    }
}

