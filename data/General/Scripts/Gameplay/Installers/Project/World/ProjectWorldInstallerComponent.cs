using Core.Infrastructure.Installers;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.Project.World;

public class ProjectWorldInstallerComponent : InstallerComponent
{
    public override void SetInstaller()
    {
        ProjectWorldInstaller projectWorldInstaller = new();
        Installer = projectWorldInstaller;
    }
}