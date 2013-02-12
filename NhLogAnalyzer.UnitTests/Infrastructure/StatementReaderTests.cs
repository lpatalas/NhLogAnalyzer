using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Services;
using NhLogAnalyzer.UnitTests.Fakes;
using Xunit;

namespace NhLogAnalyzer.UnitTests.Services
{
	public class StatementReaderTests
	{
		public class ReadMethod : InMemoryDatabaseTest
		{
			private const string logFileName = @"X:\files.txt";

			private readonly MockConnectionFactory connectionFactory = new MockConnectionFactory();
			private readonly StatementReader statementReader;

			public ReadMethod()
			{
				connectionFactory.CreateConnectionImpl = fileName => this.Connection;
				statementReader = new StatementReader(connectionFactory);
			}

			[Fact]
			public void Should_create_connection_using_ConnectionFactory()
			{
				// Arrange
				var openedFileName = "";
				connectionFactory.CreateConnectionImpl = fileName => { openedFileName = fileName; return this.Connection; };

				// Act
				statementReader.Read(logFileName);

				// Assert
				Assert.Equal(logFileName, openedFileName);
			}

			[Fact]
			public void Should_dispose_connection_returned_by_ConnectionFactory()
			{
				// Arrange

				// Act
				statementReader.Read(logFileName);
				
				// Assert
				Assert.Throws<ObjectDisposedException>(() => Connection.State);
			}

			[Fact]
			public void Should_read_all_rows_from_Statement_table()
			{
				// Arrange
				var expectedStatements = new[]
				{
					new Statement(1, "SQL1", "STACK1", DateTime.Now),
					new Statement(2, "SQL2", "STACK2", DateTime.Now.AddDays(1)),
					new Statement(3, "SQL3", "STACK3", DateTime.Now.AddDays(2)),
				};

				InsertStatements(expectedStatements);

				// Act
				var statements = statementReader.Read(logFileName);

				// Assert
				var pairs = statements.Zip(expectedStatements, (actual, expected) => new { actual, expected });
				foreach (var pair in pairs)
				{
					Assert.Equal(pair.expected.Id, pair.actual.Id);
					Assert.Equal(pair.expected.SqlText, pair.actual.SqlText);
					Assert.Equal(pair.expected.StackTrace, pair.actual.StackTrace);
					Assert.Equal(pair.expected.Timestamp.ToString(), pair.actual.Timestamp.ToString()); // TODO: Fix date comparison
				}
			}
		}
	}
}
