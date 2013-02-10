using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.UnitTests.Fakes;
using Xunit;

namespace NhLogAnalyzer.UnitTests
{
	public class StatementReaderTests
	{
		public class ReadMethod
		{
			private const string logFileName = @"X:\files.txt";

			private readonly MockDbConnection mockConnection = new MockDbConnection();
			private readonly MockConnectionFactory connectionFactory = new MockConnectionFactory();
			private readonly StatementReader statementReader;

			public ReadMethod()
			{
				connectionFactory.CreateConnectionImpl = fileName => mockConnection;
				statementReader = new StatementReader(connectionFactory);
			}

			[Fact]
			public void Should_create_connection_using_ConnectionFactory()
			{
				// Arrange
				var openedFileName = "";
				connectionFactory.CreateConnectionImpl = fileName => { openedFileName = fileName; return mockConnection; };

				// Act
				statementReader.Read(logFileName);

				// Assert
				Assert.Equal(logFileName, openedFileName);
			}

			[Fact]
			public void Should_open_connection_returned_by_ConnectionFactory()
			{
				// Arrange

				// Act
				statementReader.Read(logFileName);

				// Assert
				Assert.True(mockConnection.WasOpened);
			}

			[Fact]
			public void Should_dispose_connection_returned_by_ConnectionFactory()
			{
				// Arrange

				// Act
				statementReader.Read(logFileName);

				// Assert
				Assert.True(mockConnection.WasDisposed);
			}

			[Fact]
			public void Should_correctly_set_up_command_used_to_read_rows_from_database()
			{
				// Arrange
				var wasExecuteReaderCalled = false;
				string commandText = null;
				CommandType? commandType = null;

				mockConnection.MockCommand.ExecuteReaderImpl = () =>
				{
					wasExecuteReaderCalled = true;
					commandText = mockConnection.MockCommand.CommandText;
					commandType = mockConnection.MockCommand.CommandType;
					return null;
				};

				// Act
				statementReader.Read(logFileName);

				// Assert
				Assert.True(wasExecuteReaderCalled);
				Assert.Equal("SELECT Id, Timestamp, SqlText, StackTrace FROM Statement", commandText);
				Assert.Equal(CommandType.Text, commandType);
			}
		}
	}
}
