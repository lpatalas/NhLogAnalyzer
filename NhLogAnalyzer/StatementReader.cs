using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace NhLogAnalyzer
{
	public class StatementReader : IStatementReader
	{
		private readonly IConnectionFactory connectionFactory;

		public StatementReader(IConnectionFactory connectionFactory)
		{
			if (connectionFactory == null)
				throw new ArgumentNullException("connectionFactory");

			this.connectionFactory = connectionFactory;
		}

		public IEnumerable<Statement> Read(string fileName)
		{
			using (var connection = connectionFactory.CreateConnection(fileName))
			{
				if (connection.State != ConnectionState.Open)
					connection.Open();

				var querySql = "SELECT Id, Timestamp, SqlText, StackTrace FROM Statement";
				var statements = connection.Query(querySql)
					.Select(row => new Statement((int)row.Id, (string)row.SqlText, (string)row.StackTrace, (DateTime)row.Timestamp))
					.ToList()
					.AsReadOnly();

				return statements;
			}
		}
	}
}
