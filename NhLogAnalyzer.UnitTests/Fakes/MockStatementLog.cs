using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.UnitTests.Fakes
{
	public class MockStatementLog : IStatementLog
	{
		public Action<string> ResetImpl = fileName => { };

		public void Reset(string fileName)
		{
			ResetImpl(fileName);
		}
	}
}
