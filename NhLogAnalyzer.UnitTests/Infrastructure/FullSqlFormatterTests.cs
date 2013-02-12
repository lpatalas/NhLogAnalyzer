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
			[Fact]
			public void Should_return_input_string()
			{
				// Arrange
				var input = "SQL";
				var formatter = new FullSqlFormatter();

				// Act
				var output = formatter.Format(input);

				// Assert
				Assert.Equal(input, output);
			}
		}
	}
}
