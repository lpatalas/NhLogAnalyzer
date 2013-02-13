using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Infrastructure;
using Xunit;

namespace NhLogAnalyzer.UnitTests.Infrastructure
{
	public class FullSqlFormatterTests
	{
		public class FormatMethod
		{
			private readonly FullSqlFormatter formatter = new FullSqlFormatter();

			[Fact]
			public void Should_return_input_string()
			{
				// Arrange
				var input = "SQL";

				// Act
				var output = formatter.Format(input);

				// Assert
				Assert.Equal(input, output);
			}

			[Fact]
			public void Should_not_remove_trailing_line_break_if_present()
			{
				// Arrange
				var input = "SQL" + Environment.NewLine;

				// Act
				var output = formatter.Format(input);

				// Assert
				Assert.Equal(input, output);
			}

			[Fact]
			public void Should_remove_any_unnecessary_tabulation_to_align_code_to_the_left_margin()
			{
				// Arrange
				var input = new StringBuilder()
					.AppendLine("\tA")
					.AppendLine("\t\tB")
					.AppendLine("\t\t\tC")
					.AppendLine("\t\tD")
					.ToString();

				// Act
				var output = formatter.Format(input);

				// Assert
				var expectedOutput = new StringBuilder()
					.AppendLine("A")
					.AppendLine("\tB")
					.AppendLine("\t\tC")
					.AppendLine("\tD")
					.ToString();

				Assert.Equal(expectedOutput, output);
			}

			[Fact]
			public void Should_remove_any_unnecessary_leading_spaces_to_align_code_to_the_left_margin()
			{
				// Arrange
				var input = new StringBuilder()
					.AppendLine("  A")
					.AppendLine("    B")
					.AppendLine("      C")
					.AppendLine("    D")
					.ToString();

				// Act
				var output = formatter.Format(input);

				// Assert
				var expectedOutput = new StringBuilder()
					.AppendLine("A")
					.AppendLine("  B")
					.AppendLine("    C")
					.AppendLine("  D")
					.ToString();

				Assert.Equal(expectedOutput, output);
			}

			[Fact]
			public void Should_ignore_empty_lines_when_aligning_code_to_the_left_margin()
			{
				// Arrange
				var input = new StringBuilder()
					.AppendLine("  A")
					.AppendLine()
					.AppendLine("    B")
					.AppendLine("   ")
					.AppendLine("      C")
					.AppendLine("    D")
					.ToString();

				// Act
				var output = formatter.Format(input);

				// Assert
				var expectedOutput = new StringBuilder()
					.AppendLine("A")
					.AppendLine()
					.AppendLine("  B")
					.AppendLine("   ")
					.AppendLine("    C")
					.AppendLine("  D")
					.ToString();

				Assert.Equal(expectedOutput, output);
			}

			[Fact]
			public void Should_remove_leading_blank_lines()
			{
				// Arrange
				var input = new StringBuilder()
					.AppendLine("  ")
					.AppendLine()
					.AppendLine("    ")
					.AppendLine("A")
					.ToString();

				// Act
				var output = formatter.Format(input);

				// Assert
				var expectedOutput = new StringBuilder()
					.AppendLine("A")
					.ToString();

				Assert.Equal(expectedOutput, output);
			}
		}
	}
}
