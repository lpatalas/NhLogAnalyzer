using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Infrastructure;
using Xunit;
using Xunit.Extensions;

namespace NhLogAnalyzer.UnitTests.Infrastructure
{
	public class StackTraceParserTests
	{
		public class ParseMethod
		{
			private readonly StackTraceParser stackTraceParser = new StackTraceParser();

			[Theory]
			[InlineData(null)]
			[InlineData("")]
			public void Should_return_empty_list_when_stackTrace_is_null_or_empty(
				string input)
			{
				// Arrange

				// Act
				var output = stackTraceParser.Parse(input);

				// Assert
				Assert.NotNull(output);
				Assert.Equal(0, output.Count);
			}

			[Fact]
			public void Should_treat_each_line_as_single_stack_frame()
			{
				// Arrange
				var input
					= "ABC ABC:1:1\r\n"
					+ "DEF DEF:1:1\n"
					+ "GHI GHI:1:1";

				// Act
				var output = stackTraceParser.Parse(input);

				// Assert
				Assert.Equal(3, output.Count);
			}

			[Fact]
			public void Should_interpret_characters_before_first_space_as_method_name()
			{
				// Arrange
				var input = "method file:1:2";

				// Act
				var output = stackTraceParser.Parse(input);

				// Assert
				Assert.Equal("method", output[0].Method);
			}

			[Fact]
			public void Should_interpret_characters_between_first_space_and_first_following_colon_as_file_name()
			{
				// Arrange
				var input = "method file:1:2";

				// Act
				var output = stackTraceParser.Parse(input);

				// Assert
				Assert.Equal("file", output[0].FileName);
			}

			[Fact]
			public void Should_set_file_name_to_empty_string_when_line_does_not_consist_of_two_parts_separated_by_space()
			{
				// Arrange
				var input = "method";

				// Act
				var output = stackTraceParser.Parse(input);

				// Assert
				Assert.Equal("method", output[0].Method);
			}

			[Fact]
			public void Should_parse_line_and_column_number_from_last_two_digits_separated_by_colons()
			{
				// Arrange
				var input = "method file:11:22";

				// Act
				var output = stackTraceParser.Parse(input);

				// Assert
				Assert.Equal(11, output[0].Line);
				Assert.Equal(22, output[0].Column);
			}
		}
	}
}
