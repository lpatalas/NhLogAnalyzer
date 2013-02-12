using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using NhLogAnalyzer.Services;

namespace NhLogAnalyzer.UI
{
	public class StatementListViewModel : PropertyChangedBase, IStatementList
	{
		private readonly IStatementLog statementLog;

		private Statement selectedStatement;
		public Statement SelectedStatement
		{
			get { return selectedStatement; }
			set
			{
				if (selectedStatement != value)
				{
					selectedStatement = value;
					NotifyOfPropertyChange(() => SelectedStatement);
				}
			}
		}

		public IList<Statement> Statements
		{
			get { return statementLog.Statements; }
		}

		public StatementListViewModel(IStatementLog statementLog)
		{
			if (statementLog == null)
				throw new ArgumentNullException("statementLog");

			this.statementLog = statementLog;
		}
	}
}
