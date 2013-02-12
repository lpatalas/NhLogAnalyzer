using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace NhLogAnalyzer.Infrastructure
{
	public class StatementReader : IStatementReader
	{
		private readonly IConnectionFactory connectionFactory;
		private readonly IStatementMapper statementMapper;

		public StatementReader(IConnectionFactory connectionFactory, IStatementMapper statementMapper)
		{
			if (connectionFactory == null)
				throw new ArgumentNullException("connectionFactory");
			if (statementMapper == null)
				throw new ArgumentNullException("statementMapper");

			this.connectionFactory = connectionFactory;
			this.statementMapper = statementMapper;
		}

		public IEnumerable<Statement> Read(string fileName)
		{
			using (var connection = connectionFactory.CreateConnection(fileName))
			{
				if (connection.State != ConnectionState.Open)
					connection.Open();

				var querySql = "SELECT Id, Timestamp, SqlText, StackTrace FROM Statement";
				var statements = connection.Query<StatementRow>(querySql)
					.Select(row => statementMapper.Map(row))
					.ToList()
					.AsReadOnly();

				return statements;
			}
		}
	}
}
