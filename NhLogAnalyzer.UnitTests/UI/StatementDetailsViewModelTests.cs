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
	public class StatementDetailsViewModelTests
	{
		public class DocumentProperty
		{
			[Fact]
			public void Should_have_Text_equal_to_SqlText_in_selected_statement()
			{
				// Arrange
				var statement = new Statement(1, "Test", string.Empty, DateTime.Now);
				var statementList = new MockStatementList { SelectedStatement = statement };
				var viewModel = new StatementDetailsViewModel(statementList);

				// Act
				var document = viewModel.Document;

				// Assert
				Assert.Equal(statement.SqlText, document.Text);
			}

			[Fact]
			public void Should_have_actual_text_when_selected_statement_changes()
			{
				// Arrange
				var initialStatement = new Statement(1, "First", string.Empty, DateTime.Now);
				var newStatement = new Statement(1, "Second", string.Empty, DateTime.Now);
				var statementList = new MockStatementList { SelectedStatement = initialStatement };
				var viewModel = new StatementDetailsViewModel(statementList);

				// Act
				statementList.SelectedStatement = newStatement;

				// Assert
				Assert.Equal(newStatement.SqlText, viewModel.Document.Text);
			}
		}

		public class StatementProperty
		{
			[Fact]
			public void Should_return_statement_selected_in_statement_list()
			{
				// Arrange
				var selectedStatement = new Statement(1, "Test", string.Empty, DateTime.Now);
				var statementList = new MockStatementList { SelectedStatement = selectedStatement };
				var viewModel = new StatementDetailsViewModel(statementList);

				// Act
				var statement = viewModel.Statement;

				// Assert
				Assert.Same(statementList.SelectedStatement, statement);
			}

			[Fact]
			public void Should_be_updated_when_selected_statement_changes()
			{
				// Arrange
				var initialStatement = new Statement(1, "First", string.Empty, DateTime.Now);
				var newStatement = new Statement(1, "Second", string.Empty, DateTime.Now);
				var statementList = new MockStatementList { SelectedStatement = initialStatement };
				var viewModel = new StatementDetailsViewModel(statementList);

				// Act
				statementList.SelectedStatement = newStatement;

				// Assert
				Assert.Equal(statementList.SelectedStatement, viewModel.Statement);
			}

			[Fact]
			public void Should_raise_property_changed_event_when_selected_statement_changes()
			{
				// Arrange
				var initialStatement = new Statement(1, "First", string.Empty, DateTime.Now);
				var newStatement = new Statement(1, "Second", string.Empty, DateTime.Now);
				var statementList = new MockStatementList { SelectedStatement = initialStatement };
				var viewModel = new StatementDetailsViewModel(statementList);

				var changedProperties = new List<string>();
				viewModel.PropertyChanged += (sender, e) => { changedProperties.Add(e.PropertyName); };

				// Act
				statementList.SelectedStatement = newStatement;

				// Assert
				Assert.Equal(1, changedProperties.Count);
				Assert.Equal("Statement", changedProperties[0]);
			}
		}
	}
}
