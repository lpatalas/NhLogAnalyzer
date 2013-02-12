using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Infrastructure;
using Xunit;

namespace NhLogAnalyzer.UnitTests.Infrastructure
{
	public class ShortSqlFormatterTests
	{
		public class FormatMethod
		{
			private readonly ShortSqlFormatter formatter = new ShortSqlFormatter();

			[Fact]
			public void Should_remove_leading_and_trailing_whitespace_from_SqlText()
			{
				// Arrange
				var input = " \t\r\nABC\t \r\n ";

				// Act
				var output = formatter.Format(input);

				// Assert
				Assert.Equal("ABC", output);
			}

			[Fact]
			public void Should_replace_all_line_breaks_with_single_space()
			{
				// Arrange
				var input = "A\r\nB\nC";

				// Act
				var output = formatter.Format(input);

				// Assert
				Assert.Equal("A B C", output);
			}

			[Fact]
			public void Should_replace_multiple_consecutive_white_space_characters_with_single_space()
			{
				// Arrange
				var input = "A\n \tB\t\t \tC\r\n\r\nD";

				// Act
				var output = formatter.Format(input);

				// Assert
				Assert.Equal("A B C D", output);
			}
		}
	}
}
