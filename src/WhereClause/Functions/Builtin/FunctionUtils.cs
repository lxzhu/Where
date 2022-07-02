//
//  Copyright 2022  
//
//
using System;
using System.Collections.Generic;
using System.Linq;

namespace WhereClause.Functions.Builtin
{
    public static class FunctionUtils
    {
        public static void CheckOperandCount(this IFunction fn, int expectedCount, List<object> operands)
        {
            if (operands == null || operands.Count != expectedCount)
                throw new Exception($"Function {fn.GetType().Name} requires {expectedCount} operand(s).");
        }

        public static Tuple<object, object> CastOperandT2(this IFunction func, List<object> operands)
        {
            var a = operands[0];
            var b1 = operands[1];
            var b2 = Convert.ConvertText(b1, a.GetType());
            return new Tuple<object, object>(a, b2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        /// <param name="operands"></param>
        /// <returns></returns>
        public static Tuple<object, object> CastOperandAsElementT2(this IFunction func, List<object> operands)
        {
            var a = operands[0];
            var b1 = operands[1];
            var b2 = Convert.ConvertText(b1, a.GetType().GetElementType());
            return new Tuple<object, object>(a, b2);
        }

        public static Tuple<object, object> CastOperandAsArrayT2(
            this IFunction func, List<object> operands)
        {
            var a = operands[0];
            var b1 = ArrayUtils.ParseArrayText(operands[1] as string);
            var b2 = b1.Select(x => Convert.ConvertText(x, a.GetType()))
                .ToArray();
            return new Tuple<object, object>(a, b2);
        }
    }
}

