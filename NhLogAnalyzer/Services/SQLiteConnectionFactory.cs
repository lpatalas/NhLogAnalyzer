using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer
{
	public class SQLiteConnectionFactory : IConnectionFactory
	{
		public IDbConnection CreateConnection(string fileName)
		{
			var connectionString = string.Format("Data Source={0};Version=3", fileName);
			return new SQLiteConnection(connectionString);
		}
	}
}
