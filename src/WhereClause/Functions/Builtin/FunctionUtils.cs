//
//  Copyright 2022  
//
//
using System;
using System.Collections.Generic;

namespace WhereClause.Functions.Builtin
{
	public static class FunctionUtils
	{
		public static void CheckOperandCount(this IFunction fn,int expectedCount, List<object> operands)
        {
			if (operands == null || operands.Count != expectedCount)
				throw new Exception($"Function {fn.GetType().Name} requires {expectedCount} operand(s).");
        }
	}
}

