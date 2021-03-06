﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Infrastructure;

namespace NhLogAnalyzer.UnitTests.Fakes
{
	public class MockStatementLog : IStatementLog
	{
		public Action<string> ResetImpl = fileName => { };

		public IList<Statement> Statements
		{
			get;
			set;
		}

		public MockStatementLog()
		{
			Statements = new List<Statement>();
		}

		public void Reset(string fileName)
		{
			ResetImpl(fileName);
		}
	}
}
