using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F23L034_SingletonToDependencyInjection.Tools
{
    public interface ISimpleIOC
    {
        TService GetService<TService>();

        void AddSingleton<TService>();
        void AddSingleton<TService>(Func<TService> builder);
        void AddSingleton<TInterface, TService>()
            where TService : TInterface;
        void AddSingleton<TInterface, TService>(Func<TInterface> builder)
            where TService : TInterface;


    }
}
