using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer
{
	public class ShellViewModel
	{
		private readonly IOpenFileDialog openFileDialog;
		private readonly IStatementLog statementLoader;

		public string TitleText { get; set; }

		public ShellViewModel(IOpenFileDialog openFileDialog, IStatementLog statementLoader)
		{
			TitleText = "ShellView";
			this.openFileDialog = openFileDialog;
			this.statementLoader = statementLoader;
		}

		public void OpenFile()
		{
			var result = openFileDialog.Show();
			if (result.WasConfirmed)
				statementLoader.Reset(result.FileName);
		}
	}
}
