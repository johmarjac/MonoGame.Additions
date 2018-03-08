using Microsoft.Xna.Framework;
using MonoGame.Additions.Entities.Attributes;
using MonoGame.Additions.Entities.Components;

namespace MonoGame.Additions.Entities.Systems
{
    [ComponentSystem]
    [RequiredComponents(typeof(SpriteBatchComponent), typeof(SpriteComponent), typeof(TransformComponent))]
    public class SpriteSystem : ComponentSystem
    {
        public override void DrawEntity(Entity entity, GameTime gameTime)
        {
            base.DrawEntity(entity, gameTime);

            var batch = entity.GetComponent<SpriteBatchComponent>();
            var sprite = entity.GetComponent<SpriteComponent>();
            var transform = entity.GetComponent<TransformComponent>();

            if (!sprite.Sprite.IsVisible)
                return;

            batch.SpriteBatch.Draw(sprite.Sprite.Texture,
                transform.Position,
                sprite.Sprite.Texture.Bounds,
                Color.White,
                transform.Rotation,
                Vector2.Zero,
                transform.Scale,
                sprite.Sprite.Effect, 1f);
        }
    }
}