using Core.Infrastructure.Installers;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.MainMenu.World;

public class MainMenuWorldInstallerComponent : InstallerComponent
{
    public override void SetInstaller()
    {
        MainMenuWorldInstaller mainMenuWorldInstaller = new();
        Installer = mainMenuWorldInstaller;
    }
}