//
//  Copyright 2022  
//
//
using System;
using WhereClause.Expressions;

namespace WhereClause.Tests.ExpressionTests
{
	[TestClass]
	public class ComplexExpressionTests:ExpressionTestBase
	{
		[TestMethod]
		public void ComplexExpression()
        {
			this.Attributs["$age"] = 20;
			this.Attributs["$last1d/successAmount"] = 100;
			var root = new All();
			root.Add( FunctionExpression.Svo("$age", "greatThan", "18"));
			root.Add( FunctionExpression.Svo( "$last1d/successAmount", "lessThan", "200"));
			var actual = root.Eval(this.ExpressionContext);
			actual.Should().BeTrue();
        }
	}
}

