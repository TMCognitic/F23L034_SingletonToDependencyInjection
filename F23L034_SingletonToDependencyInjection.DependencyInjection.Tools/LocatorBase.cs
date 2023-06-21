
namespace F23L034_SingletonToDependencyInjection.Tools
{
    public abstract class LocatorBase
    {
        private ISimpleIOC _container;

        public ISimpleIOC Container
        {
            get
            {
                return _container;
            }
        }

        protected LocatorBase()
        {
            _container = new SimpleIOC();
            ConfigureLocator(_container);
        }

        protected abstract void ConfigureLocator(ISimpleIOC container);
    }
}
