using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.UnitTests.Fakes;
using Xunit;

namespace NhLogAnalyzer.UnitTests
{
	public class StatementLogTests
	{
		public class ResetMethod
		{
			private const string logFileName = @"X:\files.txt";

			[Fact]
			public void Should_read_statements_from_log_file_using_StatementReader()
			{
				// Arrange
				var statements = new[]
				{
					new Statement(),
					new Statement()
				};

				var statementReader = new MockStatementReader();
				statementReader.ReadImpl = fileName => statements;
				var statementLog = new StatementLog(statementReader);

				// Act
				statementLog.Reset(logFileName);

				// Assert
				Assert.Equal(statements.AsEnumerable(), statementLog.Statements.AsEnumerable());
			}
		}
	}
}
