using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Infrastructure;
using Xunit;

namespace NhLogAnalyzer.UnitTests.Infrastructure
{
	public class StatementMapperTests
	{
		public class MapMethod
		{
			private readonly MockSqlFormatter dummySqlFormatter = new MockSqlFormatter();

			[Fact]
			public void Should_copy_Id_and_Timestamp_properties_to_returned_row()
			{
				// Arrange
				var input = new StatementRow(1, string.Empty, string.Empty, new DateTime(2013, 2, 12));
				var statementMapper = new StatementMapper(dummySqlFormatter, dummySqlFormatter);

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
				var shortSqlFormatter = new MockSqlFormatter();
				shortSqlFormatter.FormatImpl = input => "Short" + input;
				var statementMapper = new StatementMapper(dummySqlFormatter, shortSqlFormatter);

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
				var fullSqlFormatter = new MockSqlFormatter();
				fullSqlFormatter.FormatImpl = input => "Full" + input;
				var statementMapper = new StatementMapper(fullSqlFormatter, dummySqlFormatter);

				// Act
				var output = statementMapper.Map(inputRow);

				// Assert
				Assert.Equal("FullSQL", output.FullSql);
			}
		}
	}
}
