namespace F23L034_SingletonToDependencyInjection.Models
{
    internal class Service1 : IService
    {
        internal Service1()
        {
            
        }

        public void DoSomething()
        {
            Console.WriteLine("I do something (by Service1)");
        }
    }
}