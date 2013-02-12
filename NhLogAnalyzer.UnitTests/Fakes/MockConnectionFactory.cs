using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Infrastructure;

namespace NhLogAnalyzer.UnitTests.Fakes
{
	public class MockConnectionFactory : IConnectionFactory
	{
		public Func<string, IDbConnection> CreateConnectionImpl;

		public MockConnectionFactory()
		{
			CreateConnectionImpl = CreateDefault;
		}

		public IDbConnection CreateConnection(string fileName)
		{
			return CreateConnectionImpl(fileName);
		}

		public IDbConnection CreateDefault(string fileName = null)
		{
			return new SQLiteConnection("data source=:memory:");
		}
	}
}
