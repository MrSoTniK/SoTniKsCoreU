using Core.DI;
using Core.Infrastructure.Installers;
using UnigineApp.data.General.Scripts.Gameplay.Enums.Scenes;
using UnigineApp.data.General.Scripts.Gameplay.Info.Scenes.MainMenu;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.MainMenu.Data;

public class MainMenuDataInstaller : DataInstallerAbstract<SceneType, MainMenuInfo>
{
    public MainMenuDataInstaller(SceneType sceneType, bool isProject) : base(sceneType, isProject)
    {
    }

    protected override void RegisterData(IContainer container)
    {
        
    }
}