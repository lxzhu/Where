//
//  Copyright 2022  
//
//
namespace WhereClause.Tests.ExpressionTests
{
    [TestClass]
    public class RegexMatchesTests: ExpressionTestBase
    {
        [TestMethod]
        [DataRow("allowedVariableName_34","^[a-zA-Z][a-zA-Z0-9_]*$",true)]
        [DataRow("disallowedVariableName-34", "^[a-zA-Z][a-zA-Z0-9_]*$", false)]
        [DataRow("34DisallowedVariableName", "^[a-zA-Z][a-zA-Z0-9_]*$", false)]

        public void TestRegex(string attributeValue, string regex, bool expected)
        {
            RunExpression("matches", attributeValue, regex, expected);
        }
    }
}

