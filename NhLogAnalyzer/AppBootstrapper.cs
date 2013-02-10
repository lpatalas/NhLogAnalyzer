using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Ninject;

namespace NhLogAnalyzer
{
	public class AppBootstrapper : Bootstrapper<ShellViewModel>
	{
		private IKernel kernel;

		protected override void BuildUp(object instance)
		{
			kernel.Inject(instance);
		}

		protected override void Configure()
		{
			base.Configure();
			kernel = new StandardKernel(new DependencyInjectionModule());
		}

		protected override IEnumerable<object> GetAllInstances(Type service)
		{
			return kernel.GetAll(service);
		}

		protected override object GetInstance(Type service, string key)
		{
			return kernel.Get(service);
		}
	}
}
