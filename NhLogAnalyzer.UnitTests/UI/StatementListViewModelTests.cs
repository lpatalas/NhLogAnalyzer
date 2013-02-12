using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Services;
using NhLogAnalyzer.UI;
using NhLogAnalyzer.UnitTests.Fakes;
using Xunit;

namespace NhLogAnalyzer.UnitTests.UI
{
	public class StatementListViewModelTests
	{
		public class SelectedStatement
		{
			[Fact]
			public void Should_raise_PropertyChanged_event_when_value_changes()
			{
				// Arrange
				var statementLog = new MockStatementLog();
				statementLog.Statements = new[]
				{
					new Statement(1, "First", string.Empty, DateTime.Now),
					new Statement(2, "Second", string.Empty, DateTime.Now),
				};
				var viewModel = new StatementListViewModel(statementLog);

				var changedProperties = new List<string>();
				viewModel.PropertyChanged += (sender, e) => { changedProperties.Add(e.PropertyName); }; 

				// Act
				viewModel.SelectedStatement = statementLog.Statements[1];

				// Assert
				Assert.Equal(1, changedProperties.Count);
				Assert.Equal("SelectedStatement", changedProperties[0]);
			}
		}

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
