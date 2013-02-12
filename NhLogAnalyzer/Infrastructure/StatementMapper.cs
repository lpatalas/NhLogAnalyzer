using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Infrastructure
{
	public class StatementMapper : IStatementMapper
	{
		private readonly ISqlFormatter fullSqlFormatter;
		private readonly ISqlFormatter shortSqlFormatter;
		private readonly IStackTraceParser stackTraceParser;

		public StatementMapper(
			ISqlFormatter fullSqlFormatter,
			ISqlFormatter shortSqlFormatter,
			IStackTraceParser stackTraceParser)
		{
			if (fullSqlFormatter == null)
				throw new ArgumentNullException("fullSqlFormatter");
			if (shortSqlFormatter == null)
				throw new ArgumentNullException("shortSqlFormatter");
			if (stackTraceParser == null)
				throw new ArgumentNullException("stackTraceParser");

			this.fullSqlFormatter = fullSqlFormatter;
			this.shortSqlFormatter = shortSqlFormatter;
			this.stackTraceParser = stackTraceParser;
		}

		public Statement Map(StatementRow row)
		{
			return new Statement(
				row.Id,
				fullSqlFormatter.Format(row.SqlText),
				shortSqlFormatter.Format(row.SqlText),
				row.Timestamp,
				stackTraceParser.Parse(row.StackTrace));
		}
	}
}
