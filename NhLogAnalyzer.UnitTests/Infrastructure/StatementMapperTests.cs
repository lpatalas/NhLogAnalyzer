using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Infrastructure;
using Xunit;

namespace NhLogAnalyzer.UnitTests.Fakes
{
	public class StatementMapperTests
	{
		public class MapMethod
		{
			private readonly MockSqlFormatter fullSqlFormatter = new MockSqlFormatter();
			private readonly MockSqlFormatter shortSqlFormatter = new MockSqlFormatter();
			private readonly MockStackTraceParser stackTraceParser = new MockStackTraceParser();
			private readonly StatementMapper statementMapper;

			public MapMethod()
			{
				statementMapper = new StatementMapper(fullSqlFormatter, shortSqlFormatter, stackTraceParser);
			}

			[Fact]
			public void Should_copy_Id_and_Timestamp_properties_to_returned_row()
			{
				// Arrange
				var input = new StatementRow(1, string.Empty, string.Empty, new DateTime(2013, 2, 12));

				// Act
				var output = statementMapper.Map(input);

				// Assert
				Assert.Equal(input.Id, output.Id);
				Assert.Equal(input.Timestamp, output.Timestamp);
			}

			[Fact]
			public void Should_use_shortSqlFormatter_to_set_ShortSqlText_property()
			{
				// Arrange
				var inputRow = new StatementRow(1, "SQL", string.Empty, DateTime.Now);
				shortSqlFormatter.FormatImpl = input => "Short" + input;

				// Act
				var output = statementMapper.Map(inputRow);

				// Assert
				Assert.Equal("ShortSQL", output.ShortSql);
			}

			[Fact]
			public void Should_use_fullSqlFormatter_to_format_FullSql_property()
			{
				// Arrange
				var inputRow = new StatementRow(1, "SQL", string.Empty, DateTime.Now);
				fullSqlFormatter.FormatImpl = input => "Full" + input;

				// Act
				var output = statementMapper.Map(inputRow);

				// Assert
				Assert.Equal("FullSQL", output.FullSql);
			}

			[Fact]
			public void Should_use_stack_trace_parser_to_extract_stack_frames_from_StrackTrace_column()
			{
				// Arrange
				stackTraceParser.ParseImpl = input =>
				{
					return new[]
					{
						new StackFrame(input + "Method", input + "File", 0, 0),
					};
				};

				var inputRow = new StatementRow { StackTrace = "Stack" };

				// Act
				var output = statementMapper.Map(inputRow);

				// Assert
				Assert.Equal(1, output.StackFrames.Count);
				Assert.Equal("StackMethod", output.StackFrames[0].MethodName);
				Assert.Equal("StackFile", output.StackFrames[0].FileName);
			}
		}
	}
}
