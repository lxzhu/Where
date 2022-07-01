using System;
using System.Collections.Generic;

namespace WhereClause.Functions
{
    public interface IFunctionFactory
    {
        void Register(string name, Type functionType, Type operandType);
        IFunction Resolve(string name, Type operandType);
    }
}

