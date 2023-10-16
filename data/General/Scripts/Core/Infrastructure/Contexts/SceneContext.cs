using System.Collections.Generic;
using Core.DI;
using Core.Infrastructure.Installers;
using Unigine;

namespace Core.Infrastructure.Contexts;

public class SceneContext : Component
{
    [ShowInEditor] public AssetLinkNode  _projectContextTemplate; 
    [ShowInEditor] private List<InstallerComponent> _installers;
    
    [HideInEditor] public Container Container { get; private set; }
    
    private void Init()
    {
        if (ProjectContext.Instance == null)
        {
            var projectContextNode =_projectContextTemplate.Load(node.WorldPosition, quat.IDENTITY);
            var projectContex = projectContextNode.GetComponent<ProjectContext>();
            projectContex.InitContext();
        }

        Container = new(ProjectContext.Instance.Container);
        
        foreach (var installer in _installers)
        {
            installer.SetInstaller();
            installer.Installer?.RegisterBindings(Container);
        }
    }
}