using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Infrastructure;

namespace NhLogAnalyzer.UnitTests
{
	public abstract class InMemoryDatabaseTest : IDisposable
	{
		private readonly IDbConnection connection;
		protected IDbConnection Connection
		{
			get { return connection; }
		}

		public InMemoryDatabaseTest()
		{
			connection = new SQLiteConnection("data source=:memory:");
			connection.Open();
			ExecuteNonQuery("CREATE TABLE Statement(Id integer primary key autoincrement, Timestamp datetime, SqlText text, StackTrace text)");
		}

		~InMemoryDatabaseTest()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				connection.Dispose();
			}
		}

		protected void ExecuteNonQuery(string commandText)
		{
			var command = connection.CreateCommand();
			command.CommandText = commandText;
			command.CommandType = CommandType.Text;
			command.ExecuteNonQuery();
		}

		protected void InsertStatements(IEnumerable<Statement> statements)
		{
			foreach (var statement in statements)
				InsertStatement(statement.Timestamp, statement.SqlText, statement.StackTrace);
		}

		protected void InsertStatement(DateTime timestamp, string sqlText, string stackTrace)
		{
			var commandText = string.Format(
				"INSERT INTO Statement(Timestamp, SqlText, StackTrace) VALUES ('{0}', '{1}', '{2}')",
				timestamp,
				sqlText,
				stackTrace);

			ExecuteNonQuery(commandText);
		}
	}
}
