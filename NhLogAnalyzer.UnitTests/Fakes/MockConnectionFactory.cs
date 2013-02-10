using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.UnitTests.Fakes
{
	public class MockConnectionFactory : IConnectionFactory
	{
		public Func<string, IDbConnection> CreateConnectionImpl = fileName => null;

		public IDbConnection CreateConnection(string fileName)
		{
			return CreateConnectionImpl(fileName);
		}
	}
}
