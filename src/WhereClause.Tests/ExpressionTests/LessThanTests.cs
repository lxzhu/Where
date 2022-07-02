//
//  Copyright 2022  
//
//
using System;
namespace WhereClause.Tests.ExpressionTests
{
    [TestClass]
	public class LessThanTests: ExpressionTestBase
    {
        [TestMethod]
        [DataRow(10, "20", true)]
        [DataRow(20, "16", false)]
        [DataRow(10.0f, "21", true)]
        [DataRow(20.0f, "17", false)]
        [DataRow(10.0, "22", true)]
        [DataRow(20.0, "18", false)]
        public void TestLessThan(object attributeValue,string testValue,bool expected)
        {
            RunExpression("lessThan", attributeValue, testValue, expected);
        }

        [TestMethod]
        [DataRow("2022-10-03", "2022-10-11", true)]
        [DataRow("2022-10-03", "2022-10-01", false)]
        public void TestLessThanDateTime(string a, string b, bool expected)
        {
            RunExpression("lessThan", DateTime.Parse(a), b, expected);
        }

    }
}

