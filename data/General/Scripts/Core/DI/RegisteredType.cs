using System;

namespace Core.DI;

public class RegisteredType
{
    public Type ImplementationType { get; }
    public Lifetime Lifetime { get; }

    public RegisteredType(Type implementationType, Lifetime lifetime)
    {
        ImplementationType = implementationType;
        Lifetime = lifetime;
    }
}