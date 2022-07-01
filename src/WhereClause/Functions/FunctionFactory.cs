using System;
using System.Collections.Generic;
using WhereClause;
using WhereClause.Functions.Builtin;

namespace WhereClause.Functions
{
    public class FunctionFactory : IFunctionFactory
    {
        protected readonly Dictionary<string, FunctionGroup> funcGroups
                 = new Dictionary<string, FunctionGroup>();
        public FunctionFactory() { }

        public void RegisterBuiltinFunctions()
        {
            this.Register<IsNull, AnyType>();
            this.Register<Equals, AnyType>();
            this.Register<GreatThan, AnyType>();
            this.Register<LessThan, AnyType>();
            this.Register<Contains, AnyType[]>();
            this.Register<StringContains, string>();
            this.Register<In, AnyType>();
        }

        #region RegisterFunction

        public void Register(string name, Type functionType, Type operandType)
        {
            if (!funcGroups.ContainsKey(name))
            {
                funcGroups[name] = new FunctionGroup();
            }
            var group = funcGroups[name];
            group[operandType] = new FunctionActivator((k) => Activator.CreateInstance(functionType) as IFunction);
        }
        #endregion

        #region Resolve
        public IFunction Resolve(string functionName, Type operandType)
        {
            var originalType = operandType;
            var attemptType = operandType;
            if (!this.funcGroups.ContainsKey(functionName))
            {
                throw new Exception($"Function {functionName} is not registered.");
            }

            var functionGroup = this.funcGroups[functionName];
            IFunctionActivator functionActivator = null;

            // 1. try originalType
            if (originalType != null && functionGroup.ContainsKey(originalType))
            {
                functionActivator = functionGroup[originalType];
            }

            // 2. try AnyType
            if (functionActivator is null
                && functionGroup.ContainsKey(typeof(AnyType)))
            {
                functionActivator = functionGroup[typeof(AnyType)];
                attemptType = typeof(AnyType);
            }

            // 3. try AnyType[]
            if (functionActivator is null
                && functionGroup.ContainsKey(typeof(AnyType[]))
                && originalType.IsArray)
            {
                functionActivator = functionGroup[typeof(AnyType[])];
                attemptType = typeof(AnyType);
            }
            // 3. report failure
            if (functionActivator is null)
            {
                var typeName = originalType.Name ?? attemptType.Name;
                throw new System.Exception($"Failed to solve function {functionName} for type {typeName}");
            }

            var functionKey = new FunctionKey()
            {
                Name = functionName,
                OperandType = originalType ?? attemptType
            };

            var function = functionActivator.CreateFunction(functionKey);
            return function;
        }
        #endregion
    }
}

