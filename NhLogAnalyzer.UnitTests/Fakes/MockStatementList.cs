using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace NhLogAnalyzer.UnitTests.Fakes
{
	public class MockStatementList : PropertyChangedBase, IStatementList
	{
		private Statement selectedStatement;
		public Statement SelectedStatement
		{
			get { return selectedStatement; }
			set
			{
				selectedStatement = value;
				NotifyOfPropertyChange(() => SelectedStatement);
			}
		}
	}
}
