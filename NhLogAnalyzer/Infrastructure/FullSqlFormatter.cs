using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Infrastructure
{
	public class FullSqlFormatter : ISqlFormatter
	{
		public string Format(string input)
		{
			var outputLines = new List<string>();
			var inputReader = new StringReader(input);
			var line = inputReader.ReadLine();

			while (line != null)
			{
				outputLines.Add(line);
				line = inputReader.ReadLine();
			}

			AlignLinesToLeftMargin(outputLines);

			var output = string.Join(
				Environment.NewLine,
				outputLines.SkipWhile(string.IsNullOrWhiteSpace));

			if (input.EndsWith(Environment.NewLine))
				output += Environment.NewLine;

			return output;
		}

		private void AlignLinesToLeftMargin(IList<string> lines)
		{
			var indentationLength = FindCommonIndentLength(lines);
			if (indentationLength > 0)
				RemovePrefixFromNonBlankLines(lines, indentationLength);
		}

		private int FindCommonIndentLength(IList<string> lines)
		{
			var commonIndent = FindCommonIndent(lines);
			return commonIndent.Length;
		}

		private string FindCommonIndent(IList<string> lines)
		{
			string currentIndent = null;

			foreach (var line in lines.Where(x => !string.IsNullOrWhiteSpace(x)))
			{
				var indent = GetIndent(line);
				if (currentIndent != null)
					currentIndent = CommonPrefix(currentIndent, indent);
				else
					currentIndent = indent;
			}

			return currentIndent ?? string.Empty;
		}

		private string GetIndent(string line)
		{
			var indentLength = line.TakeWhile(char.IsWhiteSpace).Count();
			if (indentLength > 0)
				return line.Substring(0, indentLength);
			else
				return string.Empty;
		}

		private string CommonPrefix(string first, string second)
		{
			var commonPrefixLength = first
				.Zip(second, (firstChar, secondChar) => new { firstChar, secondChar })
				.TakeWhile(pair => pair.firstChar == pair.secondChar)
				.Count();

			if (commonPrefixLength > 0)
				return first.Substring(0, commonPrefixLength);
			else
				return string.Empty;
		}

		private void RemovePrefixFromNonBlankLines(IList<string> lines, int prefixLength)
		{
			for (int i = 0; i < lines.Count; i++)
			{
				if (!string.IsNullOrWhiteSpace(lines[i]))
					lines[i] = lines[i].Substring(prefixLength);
			}
		}
	}
}
