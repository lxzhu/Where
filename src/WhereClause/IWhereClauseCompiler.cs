namespace WhereClause
{
    public interface IWhereClauseCompiler
    {
        IWhereClause Compile(string expr);
    }
}


