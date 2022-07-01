using System;
using System.Collections.Generic;
using WhereClause.Functions;
using WhereClause.Functions.Builtin;

namespace WhereClause.Functions
{
    public class FunctionFactory : IFunctionFactory
    {
        public  readonly Dictionary<string, IFunctionGroup> FunctionGroups;

        public  FunctionFactory()
        {
            FunctionGroups = new Dictionary<string, IFunctionGroup>();

            
        }
        public void RegisterBuiltinFunctions()
        {
            RegisterFunction<IsNull, AnyType>();
            RegisterFunction<Equals, AnyType>();
            RegisterFunction<GreatThan, AnyType>();
            RegisterFunction<LessThan, AnyType>();
            RegisterFunction<Contains, AnyType>();
        }

        public IFunctionGroup GetFunctionGroup(string name)
        {
            return FunctionGroups[name];
        }
        #region RegisterFunction
        public  void RegisterFunction<TFunction, TOperand>()
            where TFunction : IFunction, new()
        {
            
            RegisterFunction(typeof(TFunction), typeof(TOperand));
        }

        public  void RegisterFunction(Type functionType,  Type operandType)
        {
            var functionNames = FunctionAttribute.GetFunctionNames(functionType);
            foreach(var name in functionNames)
            {
                RegisterFunction(functionType, operandType, name);
            }
        }

        public  void RegisterFunction<TFunction, TOperand>(string name)
            where TFunction :  IFunction,new()
        {
            RegisterFunction(typeof(TFunction),  typeof(TOperand),name);
        }

        public  void RegisterFunction(Type functionType, Type operandType, string name)
        {
            if (!FunctionGroups.ContainsKey(name))
            {
                FunctionGroups[name] = new FunctionGroup();
            }
            var group = FunctionGroups[name];
            group[operandType] = new FunctionActivator((k) => Activator.CreateInstance(functionType) as IFunction);
        }
        #endregion

    }
}

