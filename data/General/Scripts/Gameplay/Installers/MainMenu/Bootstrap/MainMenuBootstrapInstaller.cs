using Core.Infrastructure.Installers;
using UnigineApp.data.General.Scripts.Gameplay.Enums.Scenes;
using UnigineApp.data.General.Scripts.Gameplay.Info.Scenes.MainMenu;
using UnigineApp.data.General.Scripts.Gameplay.Startups.MainMenu;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.MainMenu.Bootstrap;

public class MainMenuBootstrapInstaller : BootstrapInstallerAbstract<MainMenuStartup, SceneType, MainMenuInfo>
{
    public MainMenuBootstrapInstaller(SystemsInstallerAbstract systemsInstaller, float maxElapsedTime) 
        : base(systemsInstaller, maxElapsedTime)
    {
        
    }
}