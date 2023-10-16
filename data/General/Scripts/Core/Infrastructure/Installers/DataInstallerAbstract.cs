using System;
using Core.DI;
using Core.Infrastructure.Scenes;

namespace Core.Infrastructure.Installers 
{
    public abstract class DataInstallerAbstract<TSceneType, TSceneInfo> : InstallerAbstract 
        where TSceneType : Enum 
        where TSceneInfo : SceneInfoAbstract<TSceneType>, new()
    {
        private readonly TSceneType _sceneType;
        private readonly bool _isProject;
        
        protected DataInstallerAbstract(TSceneType sceneType, bool isProject)
        {
            _sceneType = sceneType;
            _isProject = isProject;
        }

        public override void RegisterBindings(IContainer container)
        {
            RegisterSceneInfo(container);

            TryToRegisterWorldsInfo(container);

            RegisterData(container);
        }

        protected abstract void RegisterData(IContainer container);

        protected virtual void RegisterSceneInfo(IContainer container) 
        {
            TSceneInfo sceneInfo = new();
            sceneInfo.SceneType = _sceneType;
            container.RegisterInstance(sceneInfo);
        }

        protected virtual void TryToRegisterWorldsInfo(IContainer container) 
        {
            if (_isProject)
            {
                WorldsInfo worldsInfo= new();
                container.RegisterInstance(worldsInfo);
            }
        }
    }
}