using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhLogAnalyzer.Services
{
	public interface IConnectionFactory
	{
		IDbConnection CreateConnection(string fileName);
	}
}
