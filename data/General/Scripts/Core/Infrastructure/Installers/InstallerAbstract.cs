using Core.DI;

namespace Core.Infrastructure.Installers 
{
    public abstract class InstallerAbstract
    {      
        public abstract void RegisterBindings(IContainer container);
    }
}