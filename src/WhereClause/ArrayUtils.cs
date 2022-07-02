//
//  Copyright 2022  
//
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WhereClause
{
	public class ArrayUtils
	{
		//regex positive lookahead
		//it means a comma followed by matched quoting when escaped quotings are excluded..
		public const string SeparatorPattern = ",(?=([^']*[^\\]?'[^']*')*[^']*$)";
		public static readonly Regex SeparatorRegex = new Regex(SeparatorPattern);
		

		public static string[] ParseArrayText(
			string input,
			bool throwException=false)
        {
			//1. special case (and not an error)
			if (string.IsNullOrWhiteSpace(input))
				return new string[] { };

			//2. remove [ and ]
			var attempt = input.Trim();

			if (!attempt.StartsWith("[") || !attempt.EndsWith("]"))
			{
				if(throwException)
                {
					throw new Exception($"{input} is not enclosed inside '[' and ']'");
                }
				return new string[] { };
			}
			// 3. empty array
			attempt = attempt.Substring(1, attempt.Length - 2).Trim();
			if (string.IsNullOrWhiteSpace(attempt))
				return new string[] { };

			attempt = SeparatorRegex.Replace(attempt,"\uFFFF");
			var result=attempt.Split('\uFFFF');
			Func<string, string> trim = (x) =>
			 {
				 if (x.StartsWith("'") && x.EndsWith("'"))
					 x = x.Substring(1, x.Length - 2);
				 return x;
			 };
			result = result.Select(x => trim(x)).ToArray();
            return result;
		}
	}
}

