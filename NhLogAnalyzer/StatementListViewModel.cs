﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace NhLogAnalyzer
{
	public class StatementListViewModel
	{
		private readonly IStatementLog statementLog;

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
