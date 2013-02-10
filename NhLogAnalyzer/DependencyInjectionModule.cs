using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Ninject.Modules;

namespace NhLogAnalyzer
{
	public class DependencyInjectionModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IEventAggregator>().To<EventAggregator>();
			Bind<IWindowManager>().To<WindowManager>();

			Bind<IConnectionFactory>().To<SQLiteConnectionFactory>();
			Bind<IOpenFileDialog>().To<OpenFileDialog>();
			Bind<IStatementLog>().To<StatementLog>();
			Bind<IStatementReader>().To<StatementReader>();
		}
	}
}
