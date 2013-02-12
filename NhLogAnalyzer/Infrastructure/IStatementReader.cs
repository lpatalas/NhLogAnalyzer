﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Infrastructure
{
	public interface IStatementReader
	{
		IEnumerable<Statement> Read(string fileName);
	}
}
