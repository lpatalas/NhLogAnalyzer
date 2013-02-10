using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				connection.Open();

				var command = connection.CreateCommand();
				command.CommandText = "SELECT Id, Timestamp, SqlText, StackTrace FROM Statement";
				command.CommandType = System.Data.CommandType.Text;
				command.ExecuteReader();

				return Enumerable.Empty<Statement>();
			}
		}
	}
}
