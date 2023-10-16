using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unigine;

namespace Core.DI;

public class Injector : IInjector
{
    public void InjectMethods(object instance, IContainer container)
    {
        var methods = instance.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(m => m.GetCustomAttributes(typeof(InjectAttribute), inherit: true).Any());
            
        foreach (var method in methods)
        {
            var parameters = method.GetParameters();
            var arguments = parameters.Select(p => container.Resolve(p.ParameterType)).ToArray();
            method.Invoke(instance, arguments);
        }
    }

    public void InjectProperties(object instance, IContainer container)
    {
        var properties = instance.GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(p => p.CanWrite);
            
        foreach (var property in properties)
        {
            var propertyValue = container.Resolve(property.PropertyType);
            property.SetValue(instance, propertyValue);
        }
    }
}