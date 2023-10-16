using Core.Infrastructure.Installers;
using Unigine;
using UnigineApp.data.General.Scripts.Gameplay.Installers.MainMenu.Systems;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.MainMenu.Bootstrap;

public class MainMenuBootstrapInstallerComponent :  InstallerComponent
{
    [ShowInEditor] private MainMenuSystemsInstallerComponent _systemsInstallerComponent;
    [ShowInEditor] private float _maxElapsedTime = 0.02f;

    private MainMenuBootstrapInstaller _mainMenuBootstrapInstaller;
    
    public override void SetInstaller()
    {
        var mainMenuSystemsInstaller = (MainMenuSystemsInstaller)_systemsInstallerComponent.Installer;
        MainMenuBootstrapInstaller mainMenuBootstrapInstaller = new(mainMenuSystemsInstaller, _maxElapsedTime);
        Installer = mainMenuBootstrapInstaller;
        _mainMenuBootstrapInstaller = mainMenuBootstrapInstaller;
    }

    private void Update()
    {
        _mainMenuBootstrapInstaller?.Update();
    }
}