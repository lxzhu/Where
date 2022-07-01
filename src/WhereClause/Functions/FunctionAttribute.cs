using System;
using System.Collections.Generic;
using System.Linq;

namespace WhereClause.Functions
{
	public class FunctionAttribute:System.Attribute
	{
		public  List<string> FunctionNames { get; private set; }

		public FunctionAttribute(params string[] names)
		{
			this.FunctionNames = new List<string>();
			if (names != null)
				this.FunctionNames.AddRange(names);
		}

		public static List<string> GetFunctionNames(Type functionType)
        {
			if (!typeof(IFunction).IsAssignableFrom(functionType))
				throw new Exception($"Type {functionType} does not implement {nameof(IFunction)}");

			var functionNames=functionType.GetCustomAttributes(typeof(FunctionAttribute), false)
				.Select(x => x as FunctionAttribute)
				.Where(x => x != null)
				.SelectMany(x => x.FunctionNames)
				.ToList();
			if (!functionNames.Any())
				functionNames.Add(functionType.Name);
			return functionNames;
        }
	}
}

