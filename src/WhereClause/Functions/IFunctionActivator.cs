namespace WhereClause.Functions
{
    public interface IFunctionActivator
    {
        IFunction CreateFunction(FunctionKey key);
    }
}

