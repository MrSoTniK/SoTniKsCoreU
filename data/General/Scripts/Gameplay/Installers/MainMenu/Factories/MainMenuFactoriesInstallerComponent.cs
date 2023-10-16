using Core.Infrastructure.Installers;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.MainMenu.Factories;

public class MainMenuFactoriesInstallerComponent : InstallerComponent
{
    public override void SetInstaller()
    {
        MainMenuFactoriesInstaller mainMenuFactoriesInstaller = new();
        Installer = mainMenuFactoriesInstaller;
    }
}