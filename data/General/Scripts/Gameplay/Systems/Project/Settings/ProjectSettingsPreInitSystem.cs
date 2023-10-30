using Leopotam.EcsLite;
using UnigineApp.data.General.Scripts.Gameplay.Info.Settings;
using Unigine;

namespace UnigineApp.data.General.Scripts.Gameplay.Systems.Project.Settings;

public class ProjectSettingsPreInitSystem : IEcsPreInitSystem
{
    private readonly SettingsInfo _settingsInfo;
    
    public ProjectSettingsPreInitSystem(SettingsInfo settingsInfo)
    {
        _settingsInfo = settingsInfo;
    }
    
    public void PreInit(IEcsSystems systems)
    {
        
    }
}