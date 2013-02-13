using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Infrastructure
{
	public class StackTraceParser : IStackTraceParser
	{
		public IList<StackFrame> Parse(string stackTrace)
		{
			if (string.IsNullOrEmpty(stackTrace))
				return new List<StackFrame>();

			var stackFrames = new List<StackFrame>();
			var reader = new StringReader(stackTrace);
			var line = reader.ReadLine();
			
			while (line != null)
			{
				var stackFrameParts = line.Split(' ');
				var methodName = stackFrameParts[0];
				var fileName = string.Empty;
				var offset = new FileOffset();

				if (stackFrameParts.Length > 1)
					fileName = stackFrameParts[1];
				if (stackFrameParts.Length > 2)
					offset = ParseOffset(stackFrameParts[2]);

				stackFrames.Add(new StackFrame(
					methodName,
					fileName,
					offset.Line,
					offset.Column));

				line = reader.ReadLine();
			}

			return stackFrames.AsReadOnly();
		}

		private FileOffset ParseOffset(string input)
		{
			var result = new FileOffset();

			var lineAndColumn = input.Split(':');
			if (lineAndColumn.Length == 2)
			{
				int.TryParse(lineAndColumn[0], out result.Line);
				int.TryParse(lineAndColumn[1], out result.Column);
			}

			return result;
		}

		private string ParseMethodName(string line)
		{
			var spaceIndex = line.IndexOf(' ');
			if (spaceIndex > 0)
				return line.Substring(0, spaceIndex);

			return line;
		}

		private SourceFileInfo ParseSourceFileInfo(string line)
		{
			var result = new SourceFileInfo { FileName = string.Empty };

			var startIndex = line.IndexOf(' ');
			if (startIndex > 0)
			{
				var locationIndex = line.IndexOf(':', startIndex);
				if (locationIndex > 0)
				{
					result.FileName = line.Substring(startIndex + 1, locationIndex - startIndex - 1);
					result.Offset = ParseFileOffset(line.Substring(locationIndex + 1));
				}
				else
				{
					result.FileName = line.Substring(startIndex + 1);
				}
			}

			return result;
		}

		private FileOffset ParseFileOffset(string lineAndColumn)
		{
			var offset = new FileOffset();
			var parts = lineAndColumn.Split(':');
			int.TryParse(parts[0], out offset.Line);
			int.TryParse(parts[1], out offset.Column);
			return offset;
		}

		private struct SourceFileInfo
		{
			public string FileName;
			public FileOffset Offset;
		}

		private struct FileOffset
		{
			public int Line;
			public int Column;
		}
	}
}
