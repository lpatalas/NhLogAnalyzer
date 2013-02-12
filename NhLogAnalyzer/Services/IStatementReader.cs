using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Services
{
	public interface IStatementReader
	{
		IEnumerable<Statement> Read(string fileName);
	}
}
