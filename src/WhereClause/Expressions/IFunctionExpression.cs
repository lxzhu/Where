using System.Collections.Generic;

namespace WhereClause.Expressions
{
    public interface IFunctionExpression:IExpression
    {
        List<string> OperandTexts { get; set; }
    }
}

