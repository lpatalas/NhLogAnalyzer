using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Infrastructure
{
	public class FullSqlFormatter : ISqlFormatter
	{
		public string Format(string input)
		{
			return input;
		}
	}
}
