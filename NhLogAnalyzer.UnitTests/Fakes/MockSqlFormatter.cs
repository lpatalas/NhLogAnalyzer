using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Infrastructure;

namespace NhLogAnalyzer.UnitTests.Fakes
{
	public class MockSqlFormatter : ISqlFormatter
	{
		public Func<string, string> FormatImpl = input => input;
		public string Format(string input)
		{
			return FormatImpl(input);
		}
	}
}
