using Core.DI;
using Core.Infrastructure.Installers;
using UnigineApp.data.General.Scripts.Gameplay.Systems.MainMenu.UI;

namespace UnigineApp.data.General.Scripts.Gameplay.Installers.MainMenu.Systems;

public class MainMenuSystemsInstaller : SystemsInstallerAbstract
{
    protected override void AddPreInitSystems(IContainer container)
    {
        
    }

    protected override void AddInitSystems(IContainer container)
    {
        var mainMenuPreInitSystem = container.CreateInjectedObject<MainMenuPreInitSystem>();
        EcsPreInitSystems.Add(mainMenuPreInitSystem);
    }

    protected override void AddRunSystems(IContainer container)
    {
        
    }

    protected override void AddFixedRunSystems(IContainer container)
    {
        
    }
}