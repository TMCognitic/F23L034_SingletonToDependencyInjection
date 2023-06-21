using F23L034_SingletonToDependencyInjection.Models;

namespace F23L034_SingletonToDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IService service1a = Locator.Instance.Service1;
            IService service1b = Locator.Instance.Service1;

            Console.WriteLine(ReferenceEquals(service1a, service1b));

            IService service2a = Locator.Instance.Service2;
            IService service2b = Locator.Instance.Service2;

            Console.WriteLine(ReferenceEquals(service2a, service2b));
        }


    }
}