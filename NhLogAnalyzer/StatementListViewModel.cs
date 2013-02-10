using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer
{
	public class StatementListViewModel
	{
		private readonly IStatementLog statementLog;

		public IEnumerable<Statement> Statements
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
