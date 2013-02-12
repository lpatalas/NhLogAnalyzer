using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Infrastructure;

namespace NhLogAnalyzer.UnitTests.Fakes
{
	public class MockStackTraceParser : IStackTraceParser
	{
		public Func<string, IList<StackFrame>> ParseImpl = input => new List<StackFrame>();
		public IList<StackFrame> Parse(string stackTrace)
		{
			return ParseImpl(stackTrace);
		}
	}
}
