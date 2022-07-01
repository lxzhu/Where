using System;

namespace WhereClause.Functions
{
    public static class IFunctionFactoryExtensions
    {
        public static void Register<TFunction, TOperand>(
            this IFunctionFactory factory)
           where TFunction : IFunction, new()
        {
            factory.Register(typeof(TFunction), typeof(TOperand));
        }

        public static void Register(this IFunctionFactory factory, Type functionType, Type operandType)
        {
            var functionNames = FunctionAttribute.GetFunctionNames(functionType);
            foreach (var name in functionNames)
            {
                factory.Register(name, functionType, operandType);
            }
        }

        public static void Register<TFunction, TOperand>(this IFunctionFactory factory, string name)
            where TFunction : IFunction, new()
        {
            factory.Register(name, typeof(TFunction), typeof(TOperand));
        }

    }
}

