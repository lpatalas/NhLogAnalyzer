using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.UnitTests.Fakes;
using Xunit;

namespace NhLogAnalyzer.UnitTests
{
	public class StatementListViewModelTests
	{
		public class StatementsProperty
		{
			private const string logFileName = @"X:\files.txt";

			[Fact]
			public void Should_return_items_from_StatementLog_Statements_collection()
			{
				// Arrange
				var inputStatements = new[]
				{
					new Statement(1, "SQL1", "STACK1", DateTime.Now),
					new Statement(2, "SQL2", "STACK2", DateTime.Now.AddDays(1)),
				};

				var statementReader = new MockStatementReader();
				statementReader.ReadImpl = fileName => inputStatements;

				var statementLog = new StatementLog(statementReader);
				var viewModel = new StatementListViewModel(statementLog);

				statementLog.Reset(logFileName);

				// Act
				var statements = viewModel.Statements;

				// Assert
				Assert.Equal(statements.AsEnumerable(), inputStatements.AsEnumerable());
			}
		}
	}
}
