using Core.Infrastructure.Installers;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.Project.Tools;

public class ProjectToolsInstallerComponent : InstallerComponent
{
    public override void SetInstaller()
    {
        ProjectToolsInstaller projectToolsInstaller = new();
        Installer = projectToolsInstaller;
    }
}