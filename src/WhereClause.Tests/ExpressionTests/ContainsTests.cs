//
//  Copyright 2022  
//
//
namespace WhereClause.Tests.ExpressionTests
{
    [TestClass]
    public class ContainsTests: ExpressionTestBase
    {
        [TestMethod]
        [DataRow("Abcdef", "b", true)]
        [DataRow("Abcdef", "H", false)]
        public void TestContainsString(
            string attributeValue,
            string testValue,
            bool expected)
        {
            RunExpression("contains", attributeValue, testValue, expected);
        }

        [TestMethod]
        [DataRow("Sweden, Norway, Finland, Danmark", "Norway", true)]
        [DataRow("Sweden, Norway, Finland, Danmark", "Germany", false)]
        public void TestContainsStringArray(
            string attributeValues,
            string testValue,
            bool expected)
        {
            var items = attributeValues.Split(",")
                .Select(x => x.Trim()).ToArray();
            RunExpression("contains", items, testValue, expected);
        }

        [TestMethod]
        [DataRow("1, 3, 5, 7", "3", true)]
        [DataRow("1, 3, 5, 7", "6", false)]
        public void TestContainsInt32Array(
            string attributeValues,
            string testValue,
            bool expected)
        {
            var items = attributeValues.Split(",")
                .Select(x => x.Trim())
                .Select(x => Int32.Parse(x))
                .ToArray();
            RunExpression("contains", items, testValue, expected);
        }

        [TestMethod]
        [DataRow("1,2", "we", false)]
        public void TestContainsInt32ConvertException(
            string attributeValues,
            string testValue,
            bool expected)
        {
            var items = attributeValues.Split(",")
                .Select(x => x.Trim())
                .Select(x => Int32.Parse(x))
                .ToArray();
            Action test = () => RunExpression("contains", items, testValue, expected);
            var message = $"Can not convert '{testValue}' to {nameof(Int32)}";
            test.Should().Throw<Exception>().WithMessage(message);
        }

    }
}

