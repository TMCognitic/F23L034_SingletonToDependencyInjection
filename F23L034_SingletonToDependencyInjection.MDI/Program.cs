using F23L034_SingletonToDependencyInjection.Models;
using Microsoft.Extensions.DependencyInjection;

namespace F23L034_SingletonToDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //IService1 service1a = Locator.Instance.Service1;
            //IService1 service1b = Locator.Instance.Service1;

            //Console.WriteLine(ReferenceEquals(service1a, service1b));

            //IService2 service2a = Locator.Instance.Service2;
            //IService2 service2b = Locator.Instance.Service2;

            //Console.WriteLine(ReferenceEquals(service2a, service2b));

            //Service3 service3a = Locator.Instance.Service3;
            //Service3 service3b = Locator.Instance.Service3;

            //Console.WriteLine(ReferenceEquals(service2a, service2b));

            IServiceProvider serviceProvider1 = Locator.Instance.CreateScope();
            IService1 service1d = serviceProvider1.GetService<IService1>()!;
            IService1 service1e = serviceProvider1.GetService<IService1>()!;
            Console.WriteLine(ReferenceEquals(service1d, service1e));

            IService2 service2d = serviceProvider1.GetService<IService2>()!;
            IService2 service2e = serviceProvider1.GetService<IService2>()!;
            Console.WriteLine(ReferenceEquals(service2d, service2e));

            IServiceProvider serviceProvider2 = Locator.Instance.CreateScope();
            IService1 service1f = serviceProvider2.GetService<IService1>()!;
            IService1 service1g = serviceProvider2.GetService<IService1>()!;
            Console.WriteLine(ReferenceEquals(service1f, service1g));

            IService2 service2f = serviceProvider2.GetService<IService2>()!;
            IService2 service2g = serviceProvider2.GetService<IService2>()!;
            Console.WriteLine(ReferenceEquals(service2f, service2g));
            Console.WriteLine(ReferenceEquals(service2d, service2g));
        }


    }
}