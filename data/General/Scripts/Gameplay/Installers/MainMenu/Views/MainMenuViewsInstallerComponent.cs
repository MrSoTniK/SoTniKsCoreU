using Core.Infrastructure.Installers;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.MainMenu.Views;

public class MainMenuViewsInstallerComponent : InstallerComponent
{
    public override void SetInstaller()
    {
        MainMenuViewsInstaller mainMenuViewsInstaller = new();
        Installer = mainMenuViewsInstaller;
    }
}