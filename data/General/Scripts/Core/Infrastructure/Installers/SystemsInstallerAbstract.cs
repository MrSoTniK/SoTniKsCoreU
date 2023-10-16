using System.Collections.Generic;
using Core.DI;
using Leopotam.EcsLite;

namespace Core.Infrastructure.Installers
{
    public abstract class SystemsInstallerAbstract : InstallerAbstract
    {
        public List<IEcsPreInitSystem> EcsPreInitSystems { get; protected set; }
        public List<IEcsInitSystem> EcsInitSystems{ get; protected set; }
        public List<IEcsRunSystem> EcsRunSystems{ get; protected set; }
        public List<IEcsRunSystem> EcsFixedRunSystems{ get; protected set; }
        
        public override void RegisterBindings(IContainer container)
        {
            InitializeSystems();
            AddPreInitSystems(container);
            AddInitSystems(container);
            AddRunSystems(container);
            AddFixedRunSystems(container);
        }

        protected virtual void InitializeSystems()
        {
            EcsPreInitSystems = new();
            EcsInitSystems = new();
            EcsRunSystems = new();
            EcsFixedRunSystems = new();
        }

        protected abstract void AddPreInitSystems(IContainer container);

        protected abstract void AddInitSystems(IContainer container);

        protected abstract void AddRunSystems(IContainer container);

        protected abstract void AddFixedRunSystems(IContainer container);
    }
}