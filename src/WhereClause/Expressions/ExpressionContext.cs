using WhereClause.AttributeReaders;
using WhereClause.Functions;

namespace WhereClause.Expressions
{
    public class ExpressionContext : IExpressionContext
    {
        public ExpressionContext()
        {
            this.Attributes = new DictionaryAttributeReader();
            this.Literals = new DictionaryAttributeGuesser();
            var defaultFunctionFactory = new FunctionFactory();
            defaultFunctionFactory.RegisterBuiltin();
            this.Functions = defaultFunctionFactory;
        }
        public IAttributeReader Attributes { get ; set ; }
        public IAttributeGuesser Literals { get; set; }
        public IFunctionFactory Functions { get ; set ; }
    }
}

