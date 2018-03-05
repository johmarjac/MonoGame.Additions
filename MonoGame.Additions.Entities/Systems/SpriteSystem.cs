using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Additions.Entities.Attributes;
using MonoGame.Additions.Entities.Components;

namespace MonoGame.Additions.Entities.Systems
{
    [RequiredComponents(typeof(SpriteBatchComponent), typeof(SpriteComponent))]
    public class SpriteSystem : ComponentSystem
    {
        public override void DrawEntity(Entity entity, GameTime gameTime)
        {
            base.DrawEntity(entity, gameTime);

            var batch = entity.GetComponent<SpriteBatchComponent>();
            var sprites = entity.GetComponents<SpriteComponent>();

            batch.SpriteBatch.Begin();

            foreach (var sprite in sprites)
            {
                if (!sprite.Sprite.IsVisible)
                    continue;

                batch.SpriteBatch.Draw(sprite.Sprite.Texture,
                    new Rectangle(sprite.Sprite.Position.ToPoint(), sprite.Sprite.Texture.Bounds.Size),
                    new Rectangle(0, 0, sprite.Sprite.Texture.Width, sprite.Sprite.Texture.Height),
                    Color.White,
                    sprite.Sprite.Rotation,
                    Vector2.Zero, SpriteEffects.None, 1f);
            }

            batch.SpriteBatch.End();
        }
    }
}