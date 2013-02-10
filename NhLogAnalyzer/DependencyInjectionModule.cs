using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace NhLogAnalyzer
{
	public class DependencyInjectionModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IConnectionFactory>().To<SQLiteConnectionFactory>();
			Bind<IStatementLog>().To<StatementLog>();
			Bind<IStatementReader>().To<StatementReader>();
		}
	}
}
