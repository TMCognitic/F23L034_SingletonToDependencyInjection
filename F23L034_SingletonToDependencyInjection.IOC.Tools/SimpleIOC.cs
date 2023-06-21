using System.Reflection;

namespace F23L034_SingletonToDependencyInjection.Tools
{
    internal class SimpleIOC : ISimpleIOC
    {
        private readonly IDictionary<Type, object?> _instances;
        private readonly IDictionary<Type, Type> _mappers;
        private readonly IDictionary<Type, Func<object>> _builders;

        public SimpleIOC()
        {
            _instances = new Dictionary<Type, object?>();
            _mappers = new Dictionary<Type, Type>();
            _builders = new Dictionary<Type, Func<object>>();
        }

        public void AddSingleton<TService>()
        {
            _instances.Add(typeof(TService), null);
        }

        public void AddSingleton<TService>(Func<TService> builder)
        {
            AddSingleton<TService>();
            _builders.Add(typeof(TService), () => builder()!);
        }

        public void AddSingleton<TInterface, TService>() 
            where TService : TInterface
        {
            AddSingleton<TInterface>();
            _mappers.Add(typeof(TInterface), typeof(TService));
        }

        public void AddSingleton<TInterface, TService>(Func<TInterface> builder) 
            where TService : TInterface
        {
            AddSingleton<TInterface>();
            _builders.Add(typeof(TInterface), () => builder()!);
        }

        public TService GetService<TService>()
        {
            Type type = typeof(TService);

            return (TService)(_instances[type] ??= Resolve(type));
        }

        private object Resolve(Type type)
        {
            if(_builders.ContainsKey(type)) 
                return _builders[type].Invoke();

            if(_mappers.ContainsKey(type))
                type = _mappers[type];

            ConstructorInfo? constructorInfo = type.GetConstructors().SingleOrDefault();

            if(constructorInfo is not null)
            {
                if (constructorInfo.GetParameters().Length > 0)
                    throw new InvalidOperationException($"Le constructeur du Type '{type.FullName}' contient des arguments veuillez utiliser la méthode Register recevant en argument le builder");

                return constructorInfo.Invoke(Array.Empty<object>());
            }

            PropertyInfo? propertyInfo = type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);

            if(propertyInfo is not null && propertyInfo.CanRead)
            {
                return propertyInfo.GetMethod!.Invoke(null, null)!;
            }

            FieldInfo? fieldInfo = type.GetField("Instance", BindingFlags.Public | BindingFlags.Static);

            if(fieldInfo is not null)
            {
                return fieldInfo.GetValue(null)!;
            }

            throw new InvalidOperationException($"Je ne peux résoudre le type {type.FullName}");
        }
    }
}