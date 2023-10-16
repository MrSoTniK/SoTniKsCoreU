using Leopotam.EcsLite;
using Unigine;

namespace Core.EcsProvider;

public class ConvertToEntity : Component
{
    [ShowInEditor] private ConvertMode _convertMode;

    private EcsPackedEntity packedEntity;
    private EcsWorld spawnWorld;
    private bool _isProccessed = false;
    
    public void SetProccessed()
    {
        _isProccessed = true;
    }
    
    public ConvertMode GetConvertMode()
    {
        return _convertMode;
    }
    
    public void Set(int entity, EcsWorld world)
    {
        spawnWorld = world;
        packedEntity = EcsEntityExtensions.PackEntity(world, entity);
    }
}