using Core.Infrastructure.Installers;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.MainMenu.DataBases;

public class MainMenuDataBasesInstallerComponent : InstallerComponent
{
    public override void SetInstaller()
    {
        MainMenuDataBasesInstaller mainMenuDataBasesInstaller = new();
        Installer = mainMenuDataBasesInstaller;
    }
}