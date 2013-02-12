using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Services;
using NhLogAnalyzer.UnitTests.Fakes;
using Xunit;

namespace NhLogAnalyzer.UnitTests.Services
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
					new Statement(1, "SQL1", "STACK1", DateTime.Now),
					new Statement(2, "SQL2", "STACK2", DateTime.Now.AddDays(1)),
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
