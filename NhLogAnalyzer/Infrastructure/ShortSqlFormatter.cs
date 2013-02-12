using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Infrastructure
{
	public class ShortSqlFormatter : ISqlFormatter
	{
		private static readonly Regex whitespaceRegex = new Regex(@"[\r\n\t ]+");

		public string Format(string input)
		{
			var trimmedInput = input.Trim();
			return whitespaceRegex.Replace(trimmedInput, " ");
		}
	}
}
