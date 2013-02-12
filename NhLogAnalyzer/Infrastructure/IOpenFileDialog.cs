using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Infrastructure
{
	public interface IOpenFileDialog
	{
		OpenFileResult Show();
	}
}
