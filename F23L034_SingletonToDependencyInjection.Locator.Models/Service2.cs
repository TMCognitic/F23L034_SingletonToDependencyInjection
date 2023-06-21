namespace F23L034_SingletonToDependencyInjection.Models
{
    internal class Service2 : IService
    {       
        internal Service2()
        {

        }


        public void DoSomething()
        {
            Console.WriteLine("I do something (by Service2)");
        }
    }
}