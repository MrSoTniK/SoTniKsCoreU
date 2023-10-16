using Core.DI;

namespace Core.Infrastructure.Installers 
{
    public abstract class ViewsInstallerAbstract : InstallerAbstract
    {
        public override void RegisterBindings(IContainer container)
        {
            RegisterViews(container);
        }

        protected abstract void RegisterViews(IContainer container);
    }
}