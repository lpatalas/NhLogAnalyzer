using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Services
{
	public interface IStatementList : INotifyPropertyChanged
	{
		Statement SelectedStatement { get; set; }
	}
}
