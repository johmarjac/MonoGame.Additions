using Microsoft.Xna.Framework;
using System;

namespace MonoGame.Entities
{
    public abstract class ComponentSystem : IDisposable
    {
        public virtual void OnEntityCreated(Entity entity) { }
        public virtual void OnEntityDestroyed(Entity entity) { }

        //public virtual void OnEntityComponentAttached(Entity entity, EntityComponent component) { }
        //public virtual void OnEntityComponentDetached(Entity entity, EntityComponent component) { }

        public virtual void UpdateEntity(Entity entity, GameTime gameTime) { }
        public virtual void DrawEntity(Entity entity, GameTime gameTime) { }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}