using Core.Infrastructure.Installers;
using Unigine;
using UnigineApp.data.General.Scripts.Gameplay.Enums.Scenes;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.Project.Data;

public class ProjectDataInstallerComponent : InstallerComponent
{
    [ShowInEditor] private bool _isProject;
    [ShowInEditor] private SceneType _sceneType;
    
    public override void SetInstaller()
    {
        ProjectDataInstaller projectDataInstaller = new(_sceneType,_isProject);
        Installer = projectDataInstaller;
    }
}