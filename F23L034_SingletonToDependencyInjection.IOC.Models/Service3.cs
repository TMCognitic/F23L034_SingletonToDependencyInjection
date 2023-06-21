namespace F23L034_SingletonToDependencyInjection.Models
{
    public class Service3
    {
        public static readonly Service3 Instance = new Service3();

        private Service3()
        {
            
        }
    }
}
