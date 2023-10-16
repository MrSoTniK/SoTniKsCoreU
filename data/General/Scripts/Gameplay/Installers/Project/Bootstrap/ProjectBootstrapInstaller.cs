using Core.Infrastructure.Installers;
using UnigineApp.data.General.Scripts.Gameplay.Enums.Scenes;
using UnigineApp.data.General.Scripts.Gameplay.Info.Scenes.Project;
using UnigineApp.data.General.Scripts.Gameplay.Startups.Project;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.Project.Bootstrap;

public class ProjectBootstrapInstaller : BootstrapInstallerAbstract<ProjectStartup, SceneType, ProjectInfo>
{
    public ProjectBootstrapInstaller(SystemsInstallerAbstract systemsInstaller, float maxElapsedTime) 
        : base(systemsInstaller, maxElapsedTime)
    {
    }
}