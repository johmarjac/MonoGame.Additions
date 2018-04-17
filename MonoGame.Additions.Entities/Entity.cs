using Microsoft.Xna.Framework.Content;
using MonoGame.Additions.Entities.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoGame.Additions.Entities
{
    public class Entity
    {
        public Entity()
        {
            _components = new List<EntityComponent>();
        }

        public T Attach<T>() where T : EntityComponent, new()
        {
            var obj = new T();

            obj.Entity = this;
            _components.Add(obj);

            OnComponentAttached?.Invoke(this, obj);

            return obj;
        }

        public void Detach(EntityComponent component)
        {
            _components.Remove(component);

            OnComponentDetached?.Invoke(this, component);
        }

        public IEnumerable<T> GetComponents<T>() where T : EntityComponent
        {
            return _components.OfType<T>();
        }

        public T GetComponent<T>() where T : EntityComponent
        {
            return GetComponents<T>().FirstOrDefault();
        }

        public bool HasComponent<T>() where T : EntityComponent
        {
            return _components.Any(c => c.GetType() == typeof(T));
        }

        public bool HasComponent(Type type)
        {
            return _components.Any(c => c.GetType() == type);
        }
        
        public void LoadContent(ContentManager content) { }

        public object Tag { get; set; }

        public event ComponentAttachedDelegate OnComponentAttached;
        public event ComponentDetachedDelegate OnComponentDetached;

        private List<EntityComponent> _components { get; }
        public ICollection<EntityComponent> Components => _components;
    }
}