using WhereClause.Functions;

namespace WhereClause.Expressions
{
    public interface IExpressionContext
    {
		IAttributeReader Attributes { get; set; }
        IAttributeGuesser Literals { get; set; }
        IFunctionFactory Functions { get; set; }
    }
}

