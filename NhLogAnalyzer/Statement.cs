using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer
{
	public class Statement
	{
		private readonly int id;
		public int Id
		{
			get { return id; }
		}

		private readonly string sqlText;
		public string SqlText
		{
			get { return sqlText; }
		}

		private readonly string stackTrace;
		public string StackTrace
		{
			get { return stackTrace; }
		}

		private readonly DateTime timestamp;
		public DateTime Timestamp
		{
			get { return timestamp; }
		}

		public Statement(int id, string sqlText, string stackTrace, DateTime timestamp)
		{
			this.id = id;
			this.sqlText = sqlText;
			this.stackTrace = stackTrace;
			this.timestamp = timestamp;
		}
	}
}
