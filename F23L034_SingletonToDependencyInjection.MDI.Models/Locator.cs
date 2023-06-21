using F23L034_SingletonToDependencyInjection.Tools;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace F23L034_SingletonToDependencyInjection.Models
{
    public class Locator : LocatorBase
    {
        public static readonly Locator Instance = new Locator();

        private Locator()
        {
            
        }

        protected override void ConfigureLocator(IServiceCollection container)
        {
            container.AddSingleton<IDbConnection>(sp => new SqlConnection("Data Source=DESKTOP-BRIAREO\\SQL2019DEV;Initial Catalog=DbSlide;Integrated Security=True"));
            container.AddTransient<IService1, Service1>();
            container.AddScoped<IService2, Service2>();
            container.AddSingleton(sp => Service3.Instance);
        }

        public IService1 Service1
        {
            get { return Container.GetService<IService1>(); }
        }

        public IService2 Service2
        {
            get { return Container.GetService<IService2>(); }
        }

        public Service3 Service3
        {
            get { return Container.GetService<Service3>(); }
        }
    }
}
