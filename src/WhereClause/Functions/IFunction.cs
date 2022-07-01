using System.Collections.Generic;

namespace WhereClause.Functions
{
    public interface IFunction
    {
        bool Eval(List<object> operands);
    }
}

