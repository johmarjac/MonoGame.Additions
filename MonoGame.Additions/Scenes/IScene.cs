using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;

namespace MonoGame.Additions.Scenes
{
    public interface IScene : IDisposable
    {
        Guid Id { get; }

        Game Game { get; }

        ContentManager Content { get; }

        void Initialize();

        void LoadContent();

        void Update(GameTime gameTime);

        void Draw(GameTime gameTime);

        void UnloadContent();
    }
}