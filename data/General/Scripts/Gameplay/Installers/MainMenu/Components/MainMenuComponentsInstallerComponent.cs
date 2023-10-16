using Core.Infrastructure.Installers;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.MainMenu.Components;

public class MainMenuComponentsInstallerComponent : InstallerComponent
{
    public override void SetInstaller()
    {
        MainMenuComponentsInstaller mainMenuComponentsInstaller = new();
        Installer = mainMenuComponentsInstaller;
    }
}