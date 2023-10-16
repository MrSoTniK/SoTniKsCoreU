using Leopotam.EcsLite;

namespace Core.EcsProvider;

public interface IConvertToEntity
{
    void Convert(int entity, EcsWorld world);
}