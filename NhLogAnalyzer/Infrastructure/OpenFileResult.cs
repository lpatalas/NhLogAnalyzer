using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Services
{
	public class OpenFileResult
	{
		private readonly string fileName;
		public string FileName
		{
			get { return fileName; }
		}

		private readonly bool wasConfirmed;
		public bool WasConfirmed
		{
			get { return wasConfirmed; }
		}

		public static OpenFileResult Cancelled
		{
			get { return new OpenFileResult(false); }
		}

		public OpenFileResult(string fileName)
			: this(true)
		{
			if (string.IsNullOrEmpty(fileName))
				throw new ArgumentNullException("fileName");

			this.fileName = fileName;
		}

		private OpenFileResult(bool wasConfirmed)
		{
			this.wasConfirmed = wasConfirmed;
		}
	}
}
