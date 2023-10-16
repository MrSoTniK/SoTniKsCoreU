using Core.Infrastructure.Installers;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.MainMenu.Systems;

public class MainMenuSystemsInstallerComponent : InstallerComponent
{
    public override void SetInstaller()
    {
        MainMenuSystemsInstaller mainMenuSystemsInstaller = new();
        Installer = mainMenuSystemsInstaller;
    }
}