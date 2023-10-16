using Leopotam.EcsLite;
using System;
using Core.DI;
using Core.Infrastructure.Scenes;

namespace Core.Infrastructure.Installers
{
    public abstract class WorldInstallerAbstract<TSceneType, TSceneInfo> : InstallerAbstract
         where TSceneType : Enum 
         where TSceneInfo : SceneInfoAbstract<TSceneType>, new() 
    {
        public override void RegisterBindings(IContainer container)
        {
            BindWorld(container);
        }

        protected virtual void BindWorld(IContainer container)
        {
            EcsWorld world = new();

            var sceneInfo = container.Resolve<TSceneInfo>();
            var worldsInfo = container.Resolve<WorldsInfo>();

            int key = Convert.ToInt32(sceneInfo.SceneType);
            worldsInfo.WorldsDictionary.Add(key, world);
        }
    }
}