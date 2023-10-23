using System;
using Core.Infrastructure;
using Core.Infrastructure.Installers;
using Unigine;
using UnigineApp.data.General.Scripts.Gameplay.Installers.Project.Systems;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.Project.Bootstrap;

public class ProjectBootstratpInstallerComponent : InstallerComponent, IDisposable
{
    [ShowInEditor] private ProjectSystemsInstallerComponent _systemsInstallerComponent;
    [ShowInEditor] private float _maxElapsedTime = 0.02f;

    private ProjectBootstrapInstaller _projectBootstrapInstaller;
    
    public override void SetInstaller()
    {
        var projectSystemsInstaller = (ProjectSystemsInstaller)_systemsInstallerComponent.Installer;
        ProjectBootstrapInstaller projectBootstrapInstaller = new(projectSystemsInstaller, _maxElapsedTime);
        Installer = projectBootstrapInstaller;
        _projectBootstrapInstaller = projectBootstrapInstaller;
    }

    private void Update()
    {
        _projectBootstrapInstaller?.Update();
    }

    public void Dispose()
    {
        _projectBootstrapInstaller.Dispose();
    }
}