using Core.DI;

namespace Core.Infrastructure.Installers 
{
    public abstract class DataBasesInstallerAbstract : InstallerAbstract
    {
        public override void RegisterBindings(IContainer container)
        {
            RegisterDataBases(container);
        }

        protected abstract void RegisterDataBases(IContainer container);
    }
}