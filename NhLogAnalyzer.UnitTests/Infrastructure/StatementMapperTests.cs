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
			[Fact]
			public void Should_copy_Id_and_Timestamp_properties_to_returned_row()
			{
				// Arrange
				var input = new StatementRow(1, string.Empty, string.Empty, new DateTime(2013, 2, 12));
				var statementMapper = new StatementMapper();

				// Act
				var output = statementMapper.Map(input);

				// Assert
				Assert.Equal(input.Id, output.Id);
				Assert.Equal(input.Timestamp, output.Timestamp);
			}
		}
	}
}
