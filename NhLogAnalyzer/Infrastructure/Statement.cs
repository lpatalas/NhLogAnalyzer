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

		public string SqlText
		{
			get { return string.Empty; }
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

		public string SingleLineSqlText
		{
			get { return string.Empty; }
		}

		public Statement(int id, string fullSql, string shortSql, DateTime timestamp)
		{
			this.id = id;
			this.fullSql = fullSql;
			this.shortSql = shortSql;
			this.timestamp = timestamp;
		}

		private static readonly Regex whitespaceRegex = new Regex(@"[ \t\r\n]+");

		private static string CreateSingleLineSqlText(string sqlText)
		{
			var trimmedSql = sqlText.Trim();
			return whitespaceRegex.Replace(trimmedSql, " ");
		}
	}
}
