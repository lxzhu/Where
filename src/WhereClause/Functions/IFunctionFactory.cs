using System;
using System.Collections.Generic;

namespace WhereClause.Functions
{
    public interface IFunctionFactory
    {
        IFunctionGroup GetFunctionGroup(string name);
    }

    public interface IFunctionGroup:IDictionary<Type,IFunctionActivator>
    {
         string Name { get; set; }

         int OperandCount { get; set; }
    }
}

