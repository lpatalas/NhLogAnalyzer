using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using NhLogAnalyzer.Infrastructure;
using Ninject.Modules;

namespace NhLogAnalyzer
{
	public class DependencyInjectionModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
			Bind<IWindowManager>().To<WindowManager>().InSingletonScope();

			Bind<IConnectionFactory>().To<SQLiteConnectionFactory>();
			Bind<IOpenFileDialog>().To<OpenFileDialog>();
			Bind<IStatementLog>().To<StatementLog>().InSingletonScope();
			Bind<IStatementMapper>().To<StatementMapper>()
				.WithConstructorArgument("fullSqlFormatter", context => new FullSqlFormatter())
				.WithConstructorArgument("shortSqlFormatter", context => new ShortSqlFormatter());
			Bind<IStatementReader>().To<StatementReader>();
		}
	}
}
