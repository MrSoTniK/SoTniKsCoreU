using Core.DI;

namespace Core.Infrastructure.Installers
{
    public abstract class FactoriesInstallerAbstract : InstallerAbstract
    {
        public override void RegisterBindings(IContainer container)
        {
            RegisterFactories(container);
        }

        protected abstract void RegisterFactories(IContainer container);
    }
}