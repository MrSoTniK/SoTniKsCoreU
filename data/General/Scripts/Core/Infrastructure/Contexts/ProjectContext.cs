using System.Collections.Generic;
using Core.DI;
using Core.Infrastructure.Installers;
using Unigine;

namespace Core.Infrastructure.Contexts;

public class ProjectContext : Component
{
    [ShowInEditor] private List<InstallerComponent> _installers;

    [HideInEditor] public Container Container { get; private set; }
    
    public static ProjectContext Instance { get; private set; }
    
    private void Init()
    {
        if (Instance == null)
            InitContext();
    }

    public void InitContext()
    {
        if (Instance != null) return;
        
        Instance = this;
        node.Lifetime = Node.LIFETIME.ENGINE;
        Container = new();
        
        foreach (var installer in _installers)
        {
            installer.SetInstaller();
            installer.Installer?.RegisterBindings(Container);
        }
    }
}