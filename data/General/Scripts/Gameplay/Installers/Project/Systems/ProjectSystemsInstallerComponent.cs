using Core.Infrastructure.Installers;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.Project.Systems;

public class ProjectSystemsInstallerComponent : InstallerComponent
{
    public override void SetInstaller()
    {
        ProjectSystemsInstaller projectSystemsInstaller = new();
        Installer = projectSystemsInstaller;
    }
}