using Leopotam.EcsLite;

namespace Core.EcsProvider;

public interface IProvider<TStruct> : IConvertToEntity 
    where TStruct : struct
{
    void IConvertToEntity.Convert(int entity, EcsWorld world)
    {
        var pool = world.GetPool<TStruct>();
        if (pool.Has(entity))
        {
            pool.Del(entity);
        }
        
        pool.Add(entity) = GetValue();
    }

    public TStruct GetValue();
}