namespace F23L034_SingletonToDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IService service1a = Service1.Instance;
            IService service1b = Service1.Instance;

            Console.WriteLine(ReferenceEquals(service1a, service1b));

            IService service2a = Service2.Instance;
            IService service2b = Service2.Instance;

            Console.WriteLine(ReferenceEquals(service2a, service2b));
        }


    }

    interface IService
    {
        void DoSomething();
    }

    class Service1 : IService
    {
        public static readonly IService Instance = new Service1();

        private Service1()
        {
            
        }

        public void DoSomething()
        {
            Console.WriteLine("I do something (by Service1)");
        }
    }

    class Service2 : IService
    {
        private static readonly object _lock = new object();
        private static IService? _instance;
        internal static IService Instance
        {
            get
            {
                lock(_lock)
                {
                    if (_instance is null) 
                    {
                        _instance = new Service2();
                    }
                }

                return _instance;
                //return _instance ??= new Service2();
            }
        }

        private Service2()
        {

        }


        public void DoSomething()
        {
            Console.WriteLine("I do something (by Service2)");
        }
    }
}