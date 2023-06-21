using F23L034_SingletonToDependencyInjection.Tools;
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

        protected override void ConfigureLocator(ISimpleIOC container)
        {
            container.AddSingleton<IDbConnection>(() => new SqlConnection("Data Source=DESKTOP-BRIAREO\\SQL2019DEV;Initial Catalog=DbSlide;Integrated Security=True"));
            container.AddSingleton<IService1, Service1>();
            container.AddSingleton<IService2, Service2>();
            container.AddSingleton<Service3>();
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
