using Core.DI;

namespace Core.Infrastructure.Installers
{
    public abstract class ToolsInstallerAbstract : InstallerAbstract
    {
        public override void RegisterBindings(IContainer container)
        {
            RegisterTools(container);
        }

        protected abstract void RegisterTools(IContainer container);
    }
}