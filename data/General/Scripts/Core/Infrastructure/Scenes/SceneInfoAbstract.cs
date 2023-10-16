using System;

namespace Core.Infrastructure.Scenes;

public abstract class SceneInfoAbstract<TSceneType> where TSceneType : Enum
{
    public TSceneType SceneType;
}