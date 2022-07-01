using System;

namespace WhereClause.Functions
{
    public class FunctionActivator : IFunctionActivator
    {
        private Func<FunctionKey, IFunction> func;
        public FunctionActivator(Func<FunctionKey, IFunction> func) => this.func = func;
        public IFunction CreateFunction(FunctionKey key)
        {
            return this.func(key);
        }
    }
}

