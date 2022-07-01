using WhereClause.Functions;

namespace WhereClause.Expressions
{
    public interface IExpressionContext
    {
		IAttributeReader Attributes { get; set; }
		IFunctionFactory Functions { get; set; }
    }
}

