using System;

namespace Core.DI;

public interface IContainer
{
    public void RegisterAllInterfaces<TClass>(Lifetime lifetime = Lifetime.Transient);
    public void RegisterAllInterfacesAndSelf<TClass>(Lifetime lifetime = Lifetime.Transient);

    public void RegisterAsInterface<TInterface, TClass>(Lifetime lifetime = Lifetime.Transient)
        where TClass : TInterface;
    public void Register<TClass>(Lifetime lifetime = Lifetime.Transient);
    public void RegisterInstance<TClass>(TClass instance, Lifetime lifetime = Lifetime.Single);
    public TContract Resolve<TContract>();
    public RegisteredType[] ResolveRegisteredTypes(Type type);
    public object ResolveRegisteredType(Type type);
    public object Resolve(Type type);
}