using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.UnitTests.Fakes
{
	public class MockDbConnection : IDbConnection
	{
		public MockDbCommand MockCommand { get; set; }
		public bool WasClosed { get; private set; }
		public bool WasDisposed { get; private set; }
		public bool WasOpened { get; private set; }

		public MockDbConnection()
		{
			MockCommand = new MockDbCommand();
		}

		public void Close()
		{
			WasClosed = true;
		}

		public void Open()
		{
			WasOpened = true;
		}

		public void Dispose()
		{
			WasDisposed = true;
		}

		public IDbCommand CreateCommand()
		{
			return MockCommand;
		}

		#region Not implemented members
		public IDbTransaction BeginTransaction(IsolationLevel il)
		{
			throw new NotImplementedException();
		}

		public IDbTransaction BeginTransaction()
		{
			throw new NotImplementedException();
		}

		public void ChangeDatabase(string databaseName)
		{
			throw new NotImplementedException();
		}

		public string ConnectionString
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public int ConnectionTimeout
		{
			get { throw new NotImplementedException(); }
		}

		public string Database
		{
			get { throw new NotImplementedException(); }
		}

		public ConnectionState State
		{
			get { throw new NotImplementedException(); }
		}
		#endregion
	}
}
