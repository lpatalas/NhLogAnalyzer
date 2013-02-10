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
		private readonly IStatementLog statementLoader;

		private readonly StatementListViewModel statementList;
		public StatementListViewModel StatementList
		{
			get { return statementList; }
		}

		public ShellViewModel(IOpenFileDialog openFileDialog, IStatementLog statementLoader)
		{
			this.openFileDialog = openFileDialog;
			this.statementLoader = statementLoader;

			var connectionFactory = new SQLiteConnectionFactory();
			var statementReader = new StatementReader(connectionFactory);
			var statementLog = new StatementLog(statementReader);
			this.statementList = new StatementListViewModel(statementLog);
		}

		public void OpenFile()
		{
			var result = openFileDialog.Show();
			if (result.WasConfirmed)
				statementLoader.Reset(result.FileName);
		}
	}
}
