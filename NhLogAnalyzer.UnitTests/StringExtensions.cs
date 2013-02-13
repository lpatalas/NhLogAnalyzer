using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.UnitTests
{
	public static class StringExtensions
	{
		public static string ToEscapedString(this string input)
		{
			return input
				.Replace("\r", "\\r")
				.Replace("\n", "\\n")
				.Replace("\t", "\\t");
		}
	}
}
