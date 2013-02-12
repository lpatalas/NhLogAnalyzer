using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Infrastructure;

namespace NhLogAnalyzer.UnitTests.Fakes
{
	public class MockStatementMapper : IStatementMapper
	{
		public Func<StatementRow, Statement> MapImpl = row => null;

		public Statement Map(StatementRow row)
		{
			return MapImpl(row);
		}
	}
}
