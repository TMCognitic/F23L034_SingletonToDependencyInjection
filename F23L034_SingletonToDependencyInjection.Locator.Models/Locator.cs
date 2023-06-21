using F23L034_SingletonToDependencyInjection.Models;


namespace F23L034_SingletonToDependencyInjection.Models
{
    public class Locator
    {
        public static readonly Locator Instance = new Locator();

        private Locator()
        {
            
        }

        private IService? _service1, _service2;

        public IService Service1
        {
            get
            {
                return _service1 ??= new Service1();
            }
        }

        public IService Service2
        {
            get
            {
                return _service2 ??= new Service2();
            }
        }
    }
}
