using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Infrastructure;
using NhLogAnalyzer.UnitTests.Fakes;
using Xunit;

namespace NhLogAnalyzer.UnitTests.Infrastructure
{
	public class StatementReaderTests
	{
		public class ReadMethod : InMemoryDatabaseTest
		{
			private const string logFileName = @"X:\files.txt";

			private readonly MockConnectionFactory connectionFactory = new MockConnectionFactory();
			private readonly MockStatementMapper statementMapper = new MockStatementMapper();
			private readonly StatementReader statementReader;

			public ReadMethod()
			{
				connectionFactory.CreateConnectionImpl = fileName => this.Connection;
				statementReader = new StatementReader(connectionFactory, statementMapper);
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
			public void Should_map_row_to_statement_using_StatementMapper()
			{
				// Arrange
				var inputRows = new[]
				{
					new StatementRow(1, "SQL1", "STACK1", DateTime.Now),
					new StatementRow(2, "SQL2", "STACK2", DateTime.Now.AddDays(1)),
					new StatementRow(3, "SQL3", "STACK3", DateTime.Now.AddDays(2)),
				};

				InsertStatements(inputRows);

				var mappedRows = new List<StatementRow>();
				statementMapper.MapImpl = row =>
				{
					mappedRows.Add(row);
					return null;
				};

				// Act
				statementReader.Read(logFileName);

				// Assert
				Assert.Equal(inputRows, mappedRows);
			}
		}
	}
}
