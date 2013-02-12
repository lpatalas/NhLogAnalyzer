using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Infrastructure
{
	public class StatementMapper : IStatementMapper
	{
		private readonly ISqlFormatter shortSqlFormatter;

		public StatementMapper(ISqlFormatter shortSqlFormatter)
		{
			if (shortSqlFormatter == null)
				throw new ArgumentNullException("shortSqlFormatter");

			this.shortSqlFormatter = shortSqlFormatter;
		}

		public Statement Map(StatementRow row)
		{
			return new Statement(
				row.Id,
				shortSqlFormatter.Format(row.SqlText),
				row.Timestamp);
		}
	}
}
