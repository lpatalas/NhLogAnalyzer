using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Services
{
	public class OpenFileDialog : IOpenFileDialog
	{
		private readonly Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog
		{
			CheckFileExists = true,
			Filter = "SQLite database (*.db)|*.db",
			Title = "Open log file"
		};

		public OpenFileResult Show()
		{
			var result = dialog.ShowDialog();
			if (result == true)
				return new OpenFileResult(dialog.FileName);
			else
				return OpenFileResult.Cancelled;
		}
	}
}
