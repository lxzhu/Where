//
//  Copyright 2022  
//
//
using System;
namespace WhereClause.Tests
{
	[TestClass]
	public class ArrayUtilsTests
	{
		[TestMethod]
		public void ParseEmptyString()
        {
			var result = ArrayUtils.ParseArrayText(null);
			result.Should().BeEmpty();

			result = ArrayUtils.ParseArrayText(string.Empty);
			result.Should().BeEmpty();

			result = ArrayUtils.ParseArrayText(" ");
			result.Should().BeEmpty();
        }

		[TestMethod]
		[DataRow("[]")]
		[DataRow("[ ]")]
		[DataRow(" [ ]")]
		[DataRow(" [ ] ")]
		public void ParseEmptyArray(string input)
        {
			var result = ArrayUtils.ParseArrayText(input);
			result.Should().BeEmpty();
        }

		[TestMethod]
		[DataRow("[5]","5")]
		[DataRow("['wow']","wow")]
		[DataRow("['2022-07-01']","2022-07-01")]
		[DataRow("['[]']","[]")]
		public void ParseSingleElement(string input,string expected)
        {
			var result = ArrayUtils.ParseArrayText(input);
			result.Should().ContainSingle();
			result.Should().Contain(expected);
        }

		[TestMethod]
		[DataRow("[5,6]", "5","6")]
		[DataRow("['wow',54]", "wow","54")]
		[DataRow("['2022-07-01','a@b.com']", "2022-07-01","a@b.com")]
		[DataRow("['[]','[5]']", "[]","[5]")]
		public void ParseTwoElements(string input, string expected1,string expected2)
		{
			var result = ArrayUtils.ParseArrayText(input);
			result.Should().BeEquivalentTo(new string[] {expected1,expected2});
		}

		[TestMethod]
		[DataRow("[5,6,7]", "5", "6","7")]
		[DataRow("['wow',54,43]", "wow", "54","43")]
		[DataRow("['2022-07-01','a@b.com','google']", "2022-07-01", "a@b.com","google")]
		[DataRow("['[]','[5]','\'']", "[]", "[5]","'")]
		public void ParseThreeElements(string input, string expected1, string expected2,string expected3)
		{
			var result = ArrayUtils.ParseArrayText(input);
			result.Should().BeEquivalentTo(new string[] { expected1, expected2,expected3 });
		}
	}
}

