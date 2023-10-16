using Unigine;

namespace Core.Infrastructure.Installers;

public class InstallerComponent : Component
{
    public InstallerAbstract Installer { get; protected set; }

    public virtual void SetInstaller()
    {
        
    }
}