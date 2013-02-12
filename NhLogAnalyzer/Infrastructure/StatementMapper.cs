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

		public StatementMapper(ISqlFormatter fullSqlFormatter, ISqlFormatter shortSqlFormatter)
		{
			if (fullSqlFormatter == null)
				throw new ArgumentNullException("fullSqlFormatter");
			if (shortSqlFormatter == null)
				throw new ArgumentNullException("shortSqlFormatter");

			this.fullSqlFormatter = fullSqlFormatter;
			this.shortSqlFormatter = shortSqlFormatter;
		}

		public Statement Map(StatementRow row)
		{
			return new Statement(
				row.Id,
				fullSqlFormatter.Format(row.SqlText),
				shortSqlFormatter.Format(row.SqlText),
				row.Timestamp);
		}
	}
}
