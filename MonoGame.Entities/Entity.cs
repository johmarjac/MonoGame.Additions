using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Linq;

namespace MonoGame.Entities
{
    public class Entity
    {
        protected Entity()
        {
            _components = new List<EntityComponent>();
        }

        public T Attach<T>() where T : EntityComponent, new()
        {
            var obj = new T();

            _components.Add(obj);

            return obj;
        }

        public void Detach(EntityComponent component)
        {
            _components.Remove(component);
        }

        public IEnumerable<T> GetComponents<T>() where T : EntityComponent
        {
            return _components.OfType<T>();
        }

        public T GetComponent<T>() where T : EntityComponent
        {
            return GetComponents<T>().FirstOrDefault();
        }
        
        public virtual void LoadContent(ContentManager content) { }

        public object Tag { get; set; }

        private List<EntityComponent> _components { get; }
        public ICollection<EntityComponent> Components => _components;
    }
}