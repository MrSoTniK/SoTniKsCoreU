using Unigine;

namespace Core.Infrastructure.Scenes;

public class Scene : Component
{
    [ShowInEditor] private string _sceneName;

    public string SceneName => _sceneName;
}