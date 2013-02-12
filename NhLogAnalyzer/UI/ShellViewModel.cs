using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.UI
{
	public class ShellViewModel
	{
		private readonly IOpenFileDialog openFileDialog;
		private readonly IStatementLog statementLog;

		private readonly StatementDetailsViewModel statementDetails;
		public StatementDetailsViewModel StatementDetails
		{
			get { return statementDetails; }
		}

		private readonly StatementListViewModel statementList;
		public StatementListViewModel StatementList
		{
			get { return statementList; }
		}

		public ShellViewModel(IOpenFileDialog openFileDialog, IStatementLog statementLog)
		{
			this.openFileDialog = openFileDialog;
			this.statementLog = statementLog;
			this.statementList = new StatementListViewModel(statementLog);
			this.statementDetails = new StatementDetailsViewModel(statementList);
		}

		public void OpenFile()
		{
			var result = openFileDialog.Show();
			if (result.WasConfirmed)
				statementLog.Reset(result.FileName);
		}
	}
}
