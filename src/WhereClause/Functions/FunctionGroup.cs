using System;
using System.Collections.Generic;

namespace WhereClause.Functions
{
    public class FunctionGroup : Dictionary<Type, IFunctionActivator>
    {
        public string Name { get; set; }
        public int OperandCount { get; set; }
    }
}

