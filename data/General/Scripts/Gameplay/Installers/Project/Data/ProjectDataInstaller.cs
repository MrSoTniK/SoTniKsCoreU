using Core.DI;
using Core.Infrastructure.Installers;
using UnigineApp.data.General.Scripts.Gameplay.Enums.Scenes;
using UnigineApp.data.General.Scripts.Gameplay.Info.Scenes.Project;
using UnigineApp.data.General.Scripts.Gameplay.Info.Settings;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.Project.Data;

public class ProjectDataInstaller : DataInstallerAbstract<SceneType, ProjectInfo>
{
    public ProjectDataInstaller(SceneType sceneType, bool isProject) : base(sceneType, isProject)
    {
    }

    protected override void RegisterData(IContainer container)
    {
        container.Register<SettingsInfo>();
    }
}