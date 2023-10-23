using System;
using Core.DI;
using Core.Infrastructure.Scenes;
using Unigine;

namespace Core.Infrastructure.Installers 
{
    public abstract class BootstrapInstallerAbstract<TEcsStratup, 
        TSceneType, TSceneInfo> : InstallerAbstract, IDisposable
        where TEcsStratup : EcsStartup<TSceneType, TSceneInfo>, new()
        where TSceneType : Enum
        where TSceneInfo : SceneInfoAbstract<TSceneType>, new()
    {
        protected readonly SystemsInstallerAbstract SystemsInstallerAbstract;
        protected readonly float MaxElapsedTime;
        protected float ElapsedTime = 0;
        
        public TEcsStratup EcsStratup { get; protected set; }

        protected BootstrapInstallerAbstract(SystemsInstallerAbstract systemsInstaller, float maxElapsedTime)
        {
            SystemsInstallerAbstract = systemsInstaller;
            MaxElapsedTime = maxElapsedTime;
        }

        public override void RegisterBindings(IContainer container)
        {
            EcsStratup = new();
            
            var worldsInfo = container.Resolve<WorldsInfo>();
            var sceneInfo = container.Resolve<TSceneInfo>();
            
            EcsStratup.SetStartup(worldsInfo, sceneInfo);
            EcsStratup.SetSystems(SystemsInstallerAbstract.EcsPreInitSystems,SystemsInstallerAbstract.EcsInitSystems,
                SystemsInstallerAbstract.EcsRunSystems, SystemsInstallerAbstract.EcsFixedRunSystems);

            EcsStratup.Initialize();
        }

        public void Update()
        {
            ElapsedTime += Game.IFps;
            
            EcsStratup?.Tick();

            if (ElapsedTime >= MaxElapsedTime)
            {
                ElapsedTime = 0;
                EcsStratup?.FixedTick();
            }
        }

        public void Dispose()
        {
            EcsStratup?.Dispose();
        }
    }
}