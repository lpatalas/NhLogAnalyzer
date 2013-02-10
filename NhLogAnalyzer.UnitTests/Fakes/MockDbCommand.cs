using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.UnitTests.Fakes
{
	public class MockDbCommand : IDbCommand
	{
		public string CommandText { get; set; }
		public int CommandTimeout { get; set; }
		public CommandType CommandType { get; set; }

		public Func<IDataReader> ExecuteReaderImpl = () => null;

		public IDataReader ExecuteReader()
		{
			return ExecuteReaderImpl();
		}

		#region Not implemented members
		public void Cancel()
		{
			throw new NotImplementedException();
		}

		public IDbConnection Connection
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

		public IDbDataParameter CreateParameter()
		{
			throw new NotImplementedException();
		}

		public int ExecuteNonQuery()
		{
			throw new NotImplementedException();
		}

		public IDataReader ExecuteReader(CommandBehavior behavior)
		{
			throw new NotImplementedException();
		}

		public object ExecuteScalar()
		{
			throw new NotImplementedException();
		}

		public IDataParameterCollection Parameters
		{
			get { throw new NotImplementedException(); }
		}

		public void Prepare()
		{
			throw new NotImplementedException();
		}

		public IDbTransaction Transaction
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

		public UpdateRowSource UpdatedRowSource
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

		public void Dispose()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
