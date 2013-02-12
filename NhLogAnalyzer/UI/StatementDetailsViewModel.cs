using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;

namespace NhLogAnalyzer
{
	public class StatementDetailsViewModel : PropertyChangedBase
	{
		private IStatementList statementList;

		private TextDocument document = new TextDocument();
		public TextDocument Document
		{
			get { return document; }
		}

		public Statement Statement
		{
			get { return statementList.SelectedStatement; }
		}

		public StatementDetailsViewModel(IStatementList statementList)
		{
			if (statementList == null)
				throw new ArgumentNullException("statementList");

			this.statementList = statementList;
			statementList.PropertyChanged += statementList_PropertyChanged;
			UpdateDocument();
		}

		void statementList_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName.Equals("SelectedStatement", StringComparison.Ordinal))
			{
				UpdateDocument();
				NotifyOfPropertyChange(() => Statement);
			}
		}

		private void UpdateDocument()
		{
			if (statementList.SelectedStatement != null)
				Document.Text = statementList.SelectedStatement.SqlText;
			else
				Document.Text = string.Empty;
		}
	}
}
