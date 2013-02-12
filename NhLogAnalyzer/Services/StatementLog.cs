using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace NhLogAnalyzer.Services
{
	public class StatementLog : IStatementLog
	{
		private readonly IStatementReader statementReader;

		private readonly BindableCollection<Statement> statements = new BindableCollection<Statement>();
		public IList<Statement> Statements
		{
			get { return statements; }
		}

		public StatementLog(IStatementReader statementReader)
		{
			if (statementReader == null)
				throw new ArgumentNullException("statementReader");

			this.statementReader = statementReader;
		}

		public void Reset(string fileName)
		{
			statements.Clear();
			statements.AddRange(statementReader.Read(fileName));
		}
	}
}
