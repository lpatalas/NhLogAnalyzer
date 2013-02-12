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
	public class ShellViewModelTests
	{
		public class OpenFileMethod
		{
			private readonly MockOpenFileDialog openFileDialog = new MockOpenFileDialog();
			private readonly MockStatementLog statementLog = new MockStatementLog();
			private readonly ShellViewModel shellViewModel;

			public OpenFileMethod()
			{
				shellViewModel = new ShellViewModel(openFileDialog, statementLog);
			}

			[Fact]
			public void Should_display_open_file_dialog()
			{
				// Arrange
				var showCallCount = 0;
				openFileDialog.ShowImpl = () => { showCallCount++; return OpenFileResult.Cancelled; };

				// Act
				shellViewModel.OpenFile();

				// Assert
				Assert.Equal(1, showCallCount);
			}

			[Fact]
			public void Should_pass_fileName_selected_in_dialog_to_StatementLog_Reset_method()
			{
				// Arrange
				var openedFileName = @"X:\files.txt";
				openFileDialog.ShowImpl = () => new OpenFileResult(openedFileName);

				var loadedFileName = "";
				statementLog.ResetImpl = fileName => { loadedFileName = fileName; };

				// Act
				shellViewModel.OpenFile();

				// Assert
				Assert.Equal(openedFileName, loadedFileName);
			}

			[Fact]
			public void Should_not_call_StatementLog_when_open_file_dialog_is_cancelled()
			{
				// Arrange
				openFileDialog.ShowImpl = () => OpenFileResult.Cancelled;

				var wasLoadCalled = false;
				statementLog.ResetImpl = fileName => { wasLoadCalled = true; };

				// Act
				shellViewModel.OpenFile();

				// Assert
				Assert.False(wasLoadCalled);
			}
		}
	}
}
