using WhereClause;
using WhereClause.Expressions;
using WhereClause.Functions;

namespace WhereClause.Tests;

[TestClass]
public class FunctionExpressionTests
{
    private IFunctionFactory CreateFunctionFactory()
    {
        var factory = new FunctionFactory();
        factory.RegisterBuiltinFunctions();
        return factory;
    }

    private void RunTest(
        string fn,
        object attributeValue,
        string testValue,
        bool expected)
    {
        var attributeName = "someAttribute";

        var attributesMock = new Mock<IAttributeReader>();
        attributesMock.Setup(x => x.Read(
                It.Is<string>(x => x == attributeName)))
            .Returns(new Attribute(attributeName, attributeValue));

        var context = new ExpressionContext()
        {
            Attributes = attributesMock.Object,
            Functions = CreateFunctionFactory(),
        };
        var expr = new FunctionExpression(fn, attributeName, testValue);
        var result = expr.Eval(context);
        result.Should().Be(expected);
    }

    [TestMethod]
    [DataRow(10, "20", true)]
    [DataRow(20, "16", false)]
    [DataRow(10.0f, "20", true)]
    [DataRow(20.0f, "16", false)]
    [DataRow(10.0, "20", true)]
    [DataRow(20.0, "16", false)]
    public void TestLessThan(
        object attributeValue,
        string testValue,
        bool expected)
    {
        RunTest("lessThan", attributeValue, testValue, expected);
    }

    [TestMethod]
    [DataRow("2022-10-03", "2022-10-11", true)]
    [DataRow("2022-10-03", "2022-10-01", false)]
    public void TestLessThanDateTime(string a, string b, bool expected)
    {
        RunTest("lessThan", DateTime.Parse(a), b, expected);
    }

    [TestMethod]
    [DataRow("Abcdef", "b", true)]
    [DataRow("Abcdef", "H", false)]
    public void TestContainsString(
            string attributeValue,
            string testValue,
            bool expected)
    {
        RunTest("contains", attributeValue, testValue, expected);
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
        RunTest("contains", items, testValue, expected);
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
        RunTest("contains", items, testValue, expected);
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
        Action test = () => RunTest("contains", items, testValue, expected);
        var message = $"Can not convert '{testValue}' to {nameof(Int32)}";
        test.Should().Throw<Exception>().WithMessage(message);
    }

    [TestMethod]
    [DataRow(1, "[1,2,3]", true)]
    [DataRow(4, "[1,2,3]", false)]
    public void TestInInt32(
        int attributeValue,
        string testValues,
        bool expected)
    {
        RunTest("in", attributeValue, testValues, expected);
    }
}
