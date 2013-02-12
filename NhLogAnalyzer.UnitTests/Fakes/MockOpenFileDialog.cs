using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhLogAnalyzer.Services;

namespace NhLogAnalyzer.UnitTests.Fakes
{
	public class MockOpenFileDialog : IOpenFileDialog
	{
		public Func<OpenFileResult> ShowImpl = () => OpenFileResult.Cancelled;

		public OpenFileResult Show()
		{
			return ShowImpl();
		}
	}
}
