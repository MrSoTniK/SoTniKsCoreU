using Unigine;

namespace Core.DI;

public interface IInjector
{
    public void InjectMethods(object instance, IContainer container);
    public void InjectProperties(object instance, IContainer container);
}