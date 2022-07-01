using WhereClause.Functions;

namespace WhereClause.Expressions
{
    public class ExpressionContext : IExpressionContext
    {
        public IAttributeReader Attributes { get ; set ; }
        public IFunctionFactory Functions { get ; set ; }
    }
}

