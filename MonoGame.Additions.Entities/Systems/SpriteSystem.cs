using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Additions.Entities.Attributes;
using MonoGame.Additions.Entities.Components;

namespace MonoGame.Additions.Entities.Systems
{
    [ComponentSystem]
    [RequiredComponents(typeof(SpriteComponent), typeof(TransformComponent))]
    public class SpriteSystem : ComponentSystem
    {

        private SpriteBatch spriteBatch;

        public override void Initialize()
        {
            base.Initialize();

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        public override void DrawEntity(Entity entity, GameTime gameTime)
        {
            base.DrawEntity(entity, gameTime);
            
            var sprite = entity.GetComponent<SpriteComponent>();
            var transform = entity.GetComponent<TransformComponent>();

            if (!sprite.Sprite.IsVisible)
                return;

            spriteBatch.Begin(transformMatrix: transform.TransformMatrix);

            spriteBatch.Draw(sprite.Sprite.Texture,
                transform.Position,
                sprite.Sprite.Texture.Bounds,
                Color.White,
                transform.Rotation,
                Vector2.Zero,
                transform.Size,
                sprite.Sprite.Effect, 1f);

            spriteBatch.End();
        }
    }
}