using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MonoGame.Additions.Scenes
{
    public abstract class Scene : IScene, IEquatable<IScene>
    {
        public Scene()
        {
            Id = Guid.NewGuid();
        }

        public virtual void Initialize()
        {
            Content = new ContentManager(Game.Content.ServiceProvider, Game.Content.RootDirectory);
        }

        public virtual void LoadContent()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(GameTime gameTime)
        {
        }

        public virtual void UnloadContent()
        {
        }

        ~Scene()
        {
            Dispose(false);
        }

        public virtual bool Equals(IScene other)
        {
            return Id == other.Id;
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                UnloadContent();

                Content?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Guid Id { get; }
        public Game Game { get; internal set; }
        public ContentManager Content { get; protected set; }
    }
}