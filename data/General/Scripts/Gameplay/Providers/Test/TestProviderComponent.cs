using Core.EcsProvider;
using Unigine;

namespace Gameplay.Providers.Test;

public class TestProviderComponent : Component, IProvider<TestStruct>
{
    [ShowInEditor] private int _value1;
    [ShowInEditor] private int _value2;
    
    public TestStruct GetValue()
    {
        TestStruct testStruct = new();
        testStruct.Value1 = _value1;
        testStruct.Value2 = _value2;
        return testStruct;
    }
}