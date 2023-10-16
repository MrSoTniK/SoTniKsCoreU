using Core.Infrastructure.Installers;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.Project.DataBases;

public class ProjectDataBasesInstallerComponent : InstallerComponent
{
    public override void SetInstaller()
    {
        ProjectDataBasesInstaller projectDataBasesInstaller = new();
        Installer = projectDataBasesInstaller;
    }
}