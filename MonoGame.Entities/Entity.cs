using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MonoGame.Entities
{
    public class Entity
    {
        public Entity()
        {
            _components = new ConcurrentDictionary<Type, EntityComponent>();
        }

        public T Attach<T>() where T : EntityComponent, new()
        {
            var type = typeof(T);
            var obj = new T();

            if (!_components.TryAdd(type, obj))
                throw new ArgumentException("Component with this type already exists.");

            return obj;
        }

        public void Detach<T>() where T : EntityComponent
        {
            var type = typeof(T);

            if (!_components.TryRemove(type, out var component))
                throw new ArgumentException("Component with this type does not exist.");
        }

        public T GetComponent<T>() where T : EntityComponent
        {
            var type = typeof(T);

            if (!_components.TryGetValue(type, out var component))
                throw new ArgumentException("Component with this type does not exist.");

            return (T)component;
        }

        public bool HasComponent<T>() where T : EntityComponent
        {
            return _components.ContainsKey(typeof(T));
        }

        private ConcurrentDictionary<Type, EntityComponent> _components { get; }
        public ICollection<EntityComponent> Components => _components.Values;
    }
}