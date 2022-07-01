using System;

namespace WhereClause
{
    public interface IWhereClause
    {
        bool Eval(object model);
    }
}