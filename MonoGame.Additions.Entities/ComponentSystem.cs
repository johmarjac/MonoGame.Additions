using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MonoGame.Additions.Entities
{
    public abstract class ComponentSystem : IDisposable
    {
        public virtual void OnEntityCreated(Entity entity)
        {
            entity.OnComponentAttached += OnEntityComponentAttached;
            entity.OnComponentDetached += OnEntityComponentDetached;
        }

        public virtual void OnEntityDestroyed(Entity entity)
        {
            entity.OnComponentAttached -= OnEntityComponentAttached;
            entity.OnComponentDetached -= OnEntityComponentDetached;
        }

        protected virtual void OnEntityComponentAttached(Entity entity, EntityComponent component) { }
        protected virtual void OnEntityComponentDetached(Entity entity, EntityComponent component) { }

        public virtual void UpdateEntity(Entity entity, GameTime gameTime) { }
        public virtual void DrawEntity(Entity entity, GameTime gameTime) { }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {

            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Game Game { get; internal set; }
        protected GraphicsDevice GraphicsDevice => Game.GraphicsDevice;
    }
}