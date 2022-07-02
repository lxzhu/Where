//
//  Copyright 2022  
//
//
namespace WhereClause.Tests.ExpressionTests
{
    [TestClass]
    public class InTests: ExpressionTestBase
    {
        [TestMethod]
        [DataRow(1, "[1,2,3]", true)]
        [DataRow(4, "[1,2,3]", false)]
        public void TestInInt32Array(
        int attributeValue,
        string testValues,
        bool expected)
        {
            RunExpression("in", attributeValue, testValues, expected);
        }

        [TestMethod]
        [DataRow("Norway", "['Norway','Finland','Sweden']", true)]
        [DataRow("Germany", "['Norway','Finland','Sweden']", false)]
        public void TestInStringArray(
        string attributeValue,
        string testValues,
        bool expected)
        {
            RunExpression("in", attributeValue, testValues, expected);
        }
    }
}

