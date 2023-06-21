using F23L034_SingletonToDependencyInjection.Models;

namespace F23L034_SingletonToDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IService1 service1a = Locator.Instance.Service1;
            IService1 service1b = Locator.Instance.Service1;

            Console.WriteLine(ReferenceEquals(service1a, service1b));

            IService2 service2a = Locator.Instance.Service2;
            IService2 service2b = Locator.Instance.Service2;

            Console.WriteLine(ReferenceEquals(service2a, service2b));

            Service3 service3a = Locator.Instance.Service3;
            Service3 service3b = Locator.Instance.Service3;

            Console.WriteLine(ReferenceEquals(service2a, service2b));
        }


    }
}