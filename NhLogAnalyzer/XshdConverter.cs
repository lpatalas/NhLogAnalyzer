using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;

namespace NhLogAnalyzer
{
	public class XshdConverter : IValueConverter
	{
		private static readonly XshdConverter defaultConverter = new XshdConverter();
		public static XshdConverter Default
		{
			get { return defaultConverter; }
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var reader = OpenXmlResource(value + ".xshd");
			return HighlightingLoader.Load(reader, HighlightingManager.Instance);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}

		private XmlReader OpenXmlResource(string resourceName)
		{
			var resourcePath = "NhLogAnalyzer.Resources." + resourceName;
			var resourceStream = GetType().Assembly.GetManifestResourceStream(resourcePath);
			return new XmlTextReader(resourceStream);
		}
	}
}
