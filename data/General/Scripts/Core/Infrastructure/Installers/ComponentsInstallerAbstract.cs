using Core.Tools;
using Core.Views;
using Leopotam.EcsLite;
using System;
using Core.DI;
using Core.EcsProvider;
using Core.Infrastructure.Scenes;
using Unigine;

namespace Core.Infrastructure.Installers 
{
    public abstract class ComponentsInstallerAbstract<TSceneType, TSceneInfo> : InstallerAbstract 
        where TSceneType : Enum 
        where TSceneInfo : SceneInfoAbstract<TSceneType>, new()
    {
        public override void RegisterBindings(IContainer container)
        {
            BindComponents(container);
        }

        protected virtual void BindComponents(IContainer container)
        {
            var worldsInfo = container.Resolve<WorldsInfo>();
            var sceneInfo = container.Resolve<TSceneInfo>();
            
            var convertables = ComponentSystem.FindComponentsInWorld<ConvertToEntity>();
            // Iterate through all nodes, that has ECS Components

            EcsWorld world = WorldGetter<TSceneType, TSceneInfo>.GetWorld(sceneInfo, worldsInfo);

            foreach (var convertable in convertables)
            {
                AddEntity(convertable.node, convertable, world);
            }
        }

        protected void AddEntity(Node node, ConvertToEntity convertComponent, EcsWorld world)
        {
            // Creating new Entity
            int entity = world.NewEntity();
            if (convertComponent)
            {
                foreach (var component in node.GetComponents<Component>())
                {
                    if (component is IConvertToEntity entityComponent)
                    {
                        // Adding Component to entity
                        entityComponent.Convert(entity, world);
                        ComponentSystem.RemoveComponent(component);
                    }
                }

                convertComponent.SetProccessed();
                switch (convertComponent.GetConvertMode())
                {
                    case ConvertMode.ConvertAndDestroy:
                        node.DeleteLater();
                        break;
                    case ConvertMode.ConvertAndInject:
                        ComponentSystem.RemoveComponent(convertComponent);
                        break;
                    case ConvertMode.ConvertAndSave:
                        convertComponent.Set(entity, world);
                        break;
                }

                var viewBase = node.GetComponent<ViewBase>();
                if(viewBase != null) 
                    viewBase.Entity = entity;
            }
        }
    }
}