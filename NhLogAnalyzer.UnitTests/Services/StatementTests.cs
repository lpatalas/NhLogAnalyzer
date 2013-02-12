using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NhLogAnalyzer.UnitTests
{
	public class StatementTests
	{
		public class SingleLineSqlTextProperty
		{
			private static Statement CreateStatement(string sqlText)
			{
				return new Statement(1, sqlText, string.Empty, DateTime.Now);
			}

			[Fact]
			public void Should_remove_leading_and_trailing_whitespace_from_SqlText()
			{
				// Arrange
				var statement = CreateStatement(" \t\r\nABC\t \r\n ");

				// Act
				var result = statement.SingleLineSqlText;

				// Assert
				Assert.Equal("ABC", result);
			}

			[Fact]
			public void Should_replace_all_line_breaks_with_single_space()
			{
				// Arrange
				var statement = CreateStatement("A\r\nB\nC");

				// Act
				var result = statement.SingleLineSqlText;

				// Assert
				Assert.Equal("A B C", result);
			}

			[Fact]
			public void Should_replace_multiple_consecutive_white_space_characters_with_single_space()
			{
				// Arrange
				var statement = CreateStatement("A\n \tB\t\t \tC\r\n\r\nD");

				// Act
				var result = statement.SingleLineSqlText;

				// Assert
				Assert.Equal("A B C D", result);
			}
		}
	}
}
