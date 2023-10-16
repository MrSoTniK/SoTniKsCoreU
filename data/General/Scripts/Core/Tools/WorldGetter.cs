using Leopotam.EcsLite;
using System;
using Core.Infrastructure;
using Core.Infrastructure.Scenes;

namespace Core.Tools
{
    public static class WorldGetter<TSceneType, TSceneInfo>
       where TSceneType : Enum
       where TSceneInfo : SceneInfoAbstract<TSceneType>
    {
        public static EcsWorld GetWorld(TSceneInfo sceneInfo, WorldsInfo worldsInfo)
        {
            int key = Convert.ToInt32(sceneInfo.SceneType);
            return worldsInfo.WorldsDictionary[key];
        }
    }
}