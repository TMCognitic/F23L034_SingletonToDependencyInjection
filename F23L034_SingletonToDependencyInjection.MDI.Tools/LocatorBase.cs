
using Microsoft.Extensions.DependencyInjection;

namespace F23L034_SingletonToDependencyInjection.Tools
{
    public abstract class LocatorBase
    {
        private IServiceProvider _container;

        public IServiceProvider Container
        {
            get
            {
                return _container;
            }
        }

        protected LocatorBase()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureLocator(services);
            _container = services.BuildServiceProvider();
        }

        protected abstract void ConfigureLocator(IServiceCollection services);

        public IServiceProvider CreateScope()
        {
            return Container.CreateScope().ServiceProvider;
        }
    }
}
