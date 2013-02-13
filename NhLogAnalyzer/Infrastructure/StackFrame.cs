using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Infrastructure
{
	public class StackFrame
	{
		private readonly int column;
		public int Column
		{
			get { return column; }
		}

		private readonly string fileName;
		public string FileName
		{
			get { return fileName; }
		}

		private readonly int line;
		public int Line
		{
			get { return line; }
		}

		private readonly string methodName;
		public string MethodName
		{
			get { return methodName; }
		}

		public StackFrame(string methodName, string fileName, int line, int column)
		{
			this.methodName = methodName;
			this.fileName = fileName;
			this.line = line;
			this.column = column;
		}
	}
}
