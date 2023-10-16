using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Core.DI
{
    public class Container : IContainer
    {
        private readonly Dictionary<RegisteredType, Func<object>> _registeredTypes;
        private readonly IContainer _parentContainer; 

        public Container()
        {
            _registeredTypes = new Dictionary<RegisteredType, Func<object>>();
        }
        
        public Container(IContainer parentContainer)
        {
            _registeredTypes = new Dictionary<RegisteredType, Func<object>>();
            _parentContainer = parentContainer;
        }

        public TObject CreateInjectedObject<TObject>() where TObject : new()
        {
            var type = typeof(TObject);
            return (TObject)CreateInstance(type);
        }
        
        public void RegisterAllInterfaces<TClass>(Lifetime lifetime = Lifetime.Transient)
        {
            var classType = typeof(TClass);
            RegisterInterfaces(classType, lifetime);
        }
        
        public void RegisterAllInterfacesAndSelf<TClass>(Lifetime lifetime = Lifetime.Transient)
        {
            var classType = typeof(TClass);
            RegisterInterfaces(classType, lifetime);
            RegisterClass(classType, lifetime);
        }

        public void RegisterAsInterface<TInterface, TClass>(Lifetime lifetime = Lifetime.Transient)
            where TClass : TInterface
        {
            var interfaceType = typeof(TInterface);
            var classType = typeof(TClass);
            
            RegisterType(interfaceType, classType, lifetime);
        }

        public void Register<TClass>(Lifetime lifetime = Lifetime.Transient)
        {
            var classType = typeof(TClass);
            var registeredType = new RegisteredType(classType, lifetime);

            RegisterAccordingToLifetime(registeredType, classType, lifetime);
        }

        public void RegisterInstance<TClass>(TClass instance, Lifetime lifetime = Lifetime.Single)
        {
            var classType = instance.GetType();
            var registeredType = new RegisteredType(classType, lifetime);
            
            switch (lifetime)
            {
                case Lifetime.Single:
                    RegisterForSingle(registeredType, instance);
                    break;
                case Lifetime.Transient:
                    _registeredTypes.Add(registeredType, () => instance);
                    break;
            }
        }

        public TContract Resolve<TContract>()
        {
            return (TContract)ResolveElement(typeof(TContract));
        }
        
        public object Resolve(Type type)
        {
            return ResolveElement(type);
        }

        public RegisteredType[] ResolveRegisteredTypes(Type type)
        {
            return _registeredTypes.Keys.Where(registeredType =>
                registeredType.ImplementationType.Name == type.Name).ToArray();
        }
        
        public object ResolveRegisteredType(Type type)
        {
            var registeredType = _registeredTypes.Keys.FirstOrDefault(registeredType =>
                registeredType.ImplementationType.Name == type.Name);
            
            return registeredType != null ? _registeredTypes[registeredType].Invoke() : null;
        }

        private void RegisterClass(Type classType, Lifetime lifetime)
        {
            var registeredType = new RegisteredType(classType, lifetime);
            
            RegisterAccordingToLifetime(registeredType, classType, lifetime);
        }

        private void RegisterInterfaces(Type classType, Lifetime lifetime)
        {
            var interfaceTypes = classType.GetInterfaces();

            foreach (var interfaceType in interfaceTypes)
            {
                RegisterType(interfaceType, classType, lifetime);
            }
        }

        private void RegisterType(Type interfaceType, Type classType, Lifetime lifetime)
        {
            var registeredType = new RegisteredType(interfaceType, lifetime);

            RegisterAccordingToLifetime(registeredType, classType, lifetime);
        }

        private void RegisterAccordingToLifetime(RegisteredType registeredType, Type classType, Lifetime lifetime)
        {
            switch (lifetime)
            {
                case Lifetime.Single:
                    RegisterForSingle(registeredType, classType);
                    break;
                case Lifetime.Transient:
                    _registeredTypes.Add(registeredType, () => CreateInstance(classType));
                    break;
            }
        }

        private void RegisterForSingle<TClass>(RegisteredType registeredType, TClass instance)
        {
            var existingRegisteredType =
                _registeredTypes.Keys.FirstOrDefault(key =>
                    key.ImplementationType.Name == registeredType.ImplementationType.Name);

            if (existingRegisteredType != null)
                throw new InvalidOperationException($"Type {registeredType.ImplementationType.Name} has been already registered.");
            
            _registeredTypes.Add(registeredType, () => instance);
        }
        
        private void RegisterForSingle(RegisteredType registeredType, Type classType)
        {
            var existingRegisteredType =
                _registeredTypes.Keys.FirstOrDefault(key =>
                    key.ImplementationType.Name == registeredType.ImplementationType.Name);

            if (existingRegisteredType != null)
                throw new InvalidOperationException($"Type {classType.Name} has been already registered.");
            
            _registeredTypes.Add(registeredType, () => CreateInstance(classType));
        }
        
        private object CreateInstance(Type implementationType)
        {
            var constructors = implementationType.GetConstructors();
            if (constructors.Length == 0)
            {
                Activator.CreateInstance(implementationType);
            }

            var constructor = constructors[0];
            var parameters = constructor.GetParameters();

            List<object> arguments = new();
            foreach (var parameter in parameters)
            {
                var interfaces = parameter.ParameterType.GetInterfaces();

                var argument = interfaces.Contains(typeof(IList)) switch
                {
                    true => ResolveList(parameter),
                    false => ResolveElement(parameter.ParameterType)
                };

                if(argument != null)
                    arguments.Add(argument);
            }
            
            return constructor.Invoke(arguments.ToArray());
        }

        private object ResolveList(ParameterInfo parameterInfo)
        {
            var listItemType = parameterInfo.ParameterType.GetGenericArguments().Single();
            
            var existingRegisteredTypes =
                _registeredTypes.Keys.Where(key =>
                    key.ImplementationType.Name == listItemType.Name);
            
            var list = ((IList)Activator.CreateInstance(parameterInfo.ParameterType));

            foreach (var registeredType in existingRegisteredTypes)
            {
                list?.Add(_registeredTypes[registeredType].Invoke());
            }
            
            return list;
        }

        private object ResolveElement(Type contractType)
        {
            var existingRegisteredType =
                _registeredTypes.Keys.FirstOrDefault(key =>
                    key.ImplementationType.Name == contractType.Name);
            
            if (existingRegisteredType == null)
            {
                var instanceFromParent = TryToResolveFromParent(contractType);
                
                if(instanceFromParent == null)
                    throw new InvalidOperationException($"Type {contractType.Name} is not registered.");

                return instanceFromParent;
            }
            
            return _registeredTypes[existingRegisteredType].Invoke();;
        }

        private object TryToResolveFromParent(Type type)
        {
            return _parentContainer?.ResolveRegisteredType(type);
        }
    }
}