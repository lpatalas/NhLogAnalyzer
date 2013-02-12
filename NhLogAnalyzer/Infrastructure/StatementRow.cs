using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Infrastructure
{
	public class StatementRow : IEquatable<StatementRow>
	{
		public int Id { get; set; }
		public string SqlText { get; set; }
		public string StackTrace { get; set; }
		public DateTime Timestamp { get; set; }

		public StatementRow()
		{
		}

		public StatementRow(int id, string sqlText, string stackTrace, DateTime timestamp)
		{
			this.Id = id;
			this.SqlText = sqlText;
			this.StackTrace = stackTrace;
			this.Timestamp = timestamp;
		}

		public override bool Equals(object obj)
		{
			var other = obj as StatementRow;
			return this.Equals(other);
		}

		public bool Equals(StatementRow other)
		{
			return other != null
				&& this.Id == other.Id
				&& string.Equals(this.SqlText, other.SqlText, StringComparison.Ordinal)
				&& string.Equals(this.StackTrace, other.StackTrace, StringComparison.Ordinal)
				&& this.Timestamp == other.Timestamp;

		}

		private static bool DateTimeEqualsWithSecondPrecision(DateTime first, DateTime second)
		{
			return RoundToSeconds(first) == RoundToSeconds(second);
		}

		private static DateTime RoundToSeconds(DateTime dateTime)
		{
			return new DateTime(dateTime.Ticks / 10000000);
		}
	}
}
