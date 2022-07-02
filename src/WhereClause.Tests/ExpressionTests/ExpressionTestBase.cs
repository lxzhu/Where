//
//  Copyright 2022  
//
//
using System;
using WhereClause.AttributeReaders;
using WhereClause.Expressions;
using WhereClause.Functions;

namespace WhereClause.Tests.ExpressionTests
{
	public class ExpressionTestBase
	{
        protected FunctionFactory Functions { get; set; } = new FunctionFactory();
        protected DictionaryAttributeReader Attributs { get; set; } = new DictionaryAttributeReader();
        protected ExpressionContext ExpressionContext { get; set; } = new ExpressionContext();

        [TestInitialize]
        public virtual void Setup()
        {
            this.Functions = new FunctionFactory();
            this.Functions.RegisterBuiltin();
            this.Attributs = new DictionaryAttributeReader();
            this.ExpressionContext = new ExpressionContext()
            {
                Functions = this.Functions,
                Attributes = this.Attributs
            };
        }

        

        protected  void RunExpression(
            string fn,
            object attributeValue,
            string testValue,
            bool expected)
        {
            var attributeName = "$someAttribute";
            this.Attributs[attributeName] = attributeValue;
            var expr = new FunctionExpression(fn, attributeName, testValue);
            var result = expr.Eval(this.ExpressionContext);
            result.Should().Be(expected);
        }
    }
}

