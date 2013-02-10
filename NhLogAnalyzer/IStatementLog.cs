using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer
{
	public interface IStatementLog
	{
		IList<Statement> Statements { get; }
		void Reset(string fileName);
	}
}
