using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Infrastructure;

namespace NhLogAnalyzer.UnitTests.Fakes
{
	public class MockStatementReader : IStatementReader
	{
		public Func<string, IEnumerable<Statement>> ReadImpl = fileName => Enumerable.Empty<Statement>();

		public IEnumerable<Statement> Read(string fileName)
		{
			return ReadImpl(fileName);
		}
	}
}
