using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer
{
	public class ShellViewModel
	{
		private readonly IOpenFileDialog openFileDialog;
		private readonly IStatementLog statementLog;

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
		}

		public void OpenFile()
		{
			var result = openFileDialog.Show();
			if (result.WasConfirmed)
				statementLog.Reset(result.FileName);
		}
	}
}
