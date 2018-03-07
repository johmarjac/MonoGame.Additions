using Microsoft.Xna.Framework;
using MonoGame.Additions.Entities.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MonoGame.Additions.Entities
{
    public sealed class EntityComponentSystem : DrawableGameComponent
    {
        public EntityComponentSystem(Game game) : base(game)
        {
            _componentSystems = new ConcurrentDictionary<Type, ComponentSystemContract>();
            _entities = new List<Entity>();
        }

        public override void Initialize()
        {
            base.Initialize();

            foreach(var system in AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes()
                .Where(t => t.GetCustomAttributes(true).Any(at => at.GetType() == typeof(ComponentSystemAttribute)))))
            {
                var obj = (ComponentSystem)Activator.CreateInstance(system);

                obj.Game = Game;

                var requiredComponents = new List<Type>();
                foreach (var attr in system.GetCustomAttributes(typeof(RequiredComponentsAttribute), true) as RequiredComponentsAttribute[])
                {
                    requiredComponents.AddRange(attr.RequiredComponents);
                }

                var contract = new ComponentSystemContract(obj, requiredComponents.ToArray());

                if (!_componentSystems.TryAdd(system, contract))
                    throw new ArgumentException("A system with this type is already defined.");
            }
        }

        public T RegisterSystem<T>() where T : ComponentSystem, new()
        {
            var type = typeof(T);
            var obj = new T();

            obj.Game = Game;

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

        public Entity CreateEntity()
        {
            var entity = new Entity();

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
            base.Update(gameTime);

            foreach (var system in _componentSystems.Values)
            {
                foreach(var entity in Entities.Where(e => system.RequiredComponents.All(c => e.HasComponent(c))))
                {
                    system.ComponentSystem.UpdateEntity(entity, gameTime);
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (var system in _componentSystems.Values)
            {
                foreach (var entity in Entities.Where(e => system.RequiredComponents.All(c => e.HasComponent(c))))
                {
                    system.ComponentSystem.DrawEntity(entity, gameTime);
                }
            }
        }

        private ConcurrentDictionary<Type, ComponentSystemContract> _componentSystems { get; }
        public IEnumerable<ComponentSystem> ComponentSystems => _componentSystems.Values.Select(x => x.ComponentSystem);

        private List<Entity> _entities { get; }
        public IEnumerable<Entity> Entities => _entities;
    }
}