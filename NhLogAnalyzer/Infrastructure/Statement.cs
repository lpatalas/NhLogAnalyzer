using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Infrastructure
{
	public class Statement
	{
		private readonly int id;
		public int Id
		{
			get { return id; }
		}

		private readonly string fullSql;
		public string FullSql
		{
			get { return fullSql; }
		}

		private readonly string shortSql;
		public string ShortSql
		{
			get { return shortSql; }
		}

		private readonly IList<StackFrame> stackFrames;
		public IList<StackFrame> StackFrames
		{
			get { return stackFrames; }
		}

		public string StackTrace
		{
			get { return string.Empty; }
		}

		private readonly DateTime timestamp;
		public DateTime Timestamp
		{
			get { return timestamp; }
		}

		public Statement(int id, string fullSql, string shortSql, DateTime timestamp)
			: this(id, fullSql, shortSql, timestamp, new List<StackFrame>())
		{
		}

		public Statement(int id, string fullSql, string shortSql, DateTime timestamp, IList<StackFrame> stackFrames)
		{
			this.id = id;
			this.fullSql = fullSql;
			this.shortSql = shortSql;
			this.stackFrames = stackFrames;
			this.timestamp = timestamp;
		}
	}
}
