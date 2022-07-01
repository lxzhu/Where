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
    [TestMethod]
    [DataRow(10, "20",true)]
    [DataRow(20, "16", false)]
    [DataRow(10.0f, "20", true)]
    [DataRow(20.0f, "16", false)]
    [DataRow(10.0, "20", true)]
    [DataRow(20.0, "16", false)]
    public void SingleExpression_LessThan(object a, string b, bool expected)
    {
        var attributesMock = new Mock<IAttributeReader>();
        attributesMock.Setup(x => x.Read(It.Is<string>(x => x == "age")))
            .Returns(new Attribute("age", a));
        var context = new ExpressionContext()
        {
            Attributes = attributesMock.Object,
            Functions = CreateFunctionFactory(),
        };
        var expr = new FunctionExpression("lessThan", "age", b);
        var result = expr.Eval(context);
        result.Should().Be(expected);

    }
    [TestMethod]
    [DataRow("2022-10-03","2022-10-11",true)]
    [DataRow("2022-10-03", "2022-10-01", false)]
    public void SingleExpression_LessThanDateTime(string a, string b, bool expected)
    {
        SingleExpression_LessThan(DateTime.Parse(a), b, expected);
    }
}
