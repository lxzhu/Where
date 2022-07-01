//
//  Copyright 2022  
//
//
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WhereClause.Functions.Builtin
{
    [Function("match","matches")]
    public class RegexMatch : IFunction
    {
        public bool Eval(List<object> operands)
        {
            this.CheckOperandCount(2, operands);
            var input = operands[0]?.ToString();
            if (input is null)
                input = string.Empty;

            var pattern = operands[1]?.ToString();
            if (pattern is null)
                throw new Exception($"regex pattern can not be null.");
            
            var regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
    }
}

