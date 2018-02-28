using Microsoft.Xna.Framework;
using MonoGame.Entities.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MonoGame.Entities
{
    public sealed class EntityComponentSystem : DrawableGameComponent
    {
        public EntityComponentSystem(Game game) : base(game)
        {
            _componentSystems = new ConcurrentDictionary<Type, ComponentSystemContract>();
            _entities = new List<Entity>();
        }

        public T RegisterSystem<T>(T system) where T : ComponentSystem
        {
            var type = typeof(T);
            var obj = system;

            var requiredComponents = new List<Type>();
            foreach (var attr in typeof(T).GetCustomAttributes(typeof(RequiredComponentsAttribute), true) as RequiredComponentsAttribute[])
            {
                requiredComponents.AddRange(attr.RequiredComponents);
            }

            var contract = new ComponentSystemContract(obj, requiredComponents.ToArray());

            if (!_componentSystems.TryAdd(type, contract))
                throw new ArgumentException("A system with this type is already defined.");

            return obj;
        }

        public void UnregisterSystem<T>() where T : ComponentSystem
        {
            var type = typeof(T);

            if (!_componentSystems.TryRemove(type, out var obj))
                throw new ArgumentException("A system with this type is not defined.");
        }

        public T CreateEntity<T>() where T : Entity, new()
        {
            var entity = new T();

            foreach (var system in _componentSystems)
                system.Value.ComponentSystem.OnEntityCreated(entity);

            _entities.Add(entity);

            return entity;
        }

        public void DestroyEntity(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            foreach (var system in _componentSystems)
                system.Value.ComponentSystem.OnEntityDestroyed(entity);

            if (!_entities.Remove(entity))
                throw new ArgumentException("Specified entity was not found.");
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var system in _componentSystems.Values)
            {
                foreach (var entity in _entities)
                {
                    bool skip = false;
                    foreach (var requiredComponent in system.RequiredComponents)
                    {
                        if (!entity.Components.Any(c => c.GetType() == requiredComponent))
                        {
                            skip = true;
                            break;
                        }
                    }

                    if (skip)
                        break;

                    system.ComponentSystem.UpdateEntity(entity, gameTime);
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var system in _componentSystems.Values)
            {
                foreach (var entity in _entities)
                {
                    bool skip = false;
                    foreach (var requiredComponent in system.RequiredComponents)
                    {
                        if (!entity.Components.Any(c => c.GetType() == requiredComponent))
                        {
                            skip = true;
                            break;
                        }
                    }

                    if (skip)
                        break;

                    system.ComponentSystem.DrawEntity(entity, gameTime);
                }
            }

            base.Update(gameTime);
        }

        private ConcurrentDictionary<Type, ComponentSystemContract> _componentSystems { get; }
        public IEnumerable<ComponentSystem> ComponentSystems => _componentSystems.Values.Select(x => x.ComponentSystem);

        private List<Entity> _entities { get; }
        public IEnumerable<Entity> Entities => _entities;
    }
}