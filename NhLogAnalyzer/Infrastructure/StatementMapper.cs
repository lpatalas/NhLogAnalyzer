using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Infrastructure
{
	public class StatementMapper : IStatementMapper
	{
		public Statement Map(StatementRow row)
		{
			return new Statement(row.Id, row.SqlText, row.StackTrace, row.Timestamp);
		}
	}
}
