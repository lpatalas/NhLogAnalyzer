﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Infrastructure
{
	public interface IStatementList : INotifyPropertyChanged
	{
		Statement SelectedStatement { get; set; }
	}
}
