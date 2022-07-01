using System.Collections.Generic;

namespace WhereClause.Expressions
{
    public interface IFunctionExpression
    {
        List<string> OperandTexts { get; set; }
    }
}

