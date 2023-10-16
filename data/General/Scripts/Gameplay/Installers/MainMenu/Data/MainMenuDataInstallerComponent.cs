using Core.Infrastructure.Installers;
using Unigine;
using UnigineApp.data.General.Scripts.Gameplay.Enums.Scenes;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.MainMenu.Data;

public class MainMenuDataInstallerComponent : InstallerComponent
{
    [ShowInEditor] private bool _isProject;
    [ShowInEditor] private SceneType _sceneType;

    public override void SetInstaller()
    {
        MainMenuDataInstaller mainMenuDataInstaller = new(_sceneType, _isProject);
        Installer = mainMenuDataInstaller;
    }
}