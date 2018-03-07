using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Additions.Entities.Attributes;
using MonoGame.Additions.Entities.Components;

namespace MonoGame.Additions.Entities.Systems
{
    [ComponentSystem]
    [RequiredComponents(typeof(SpriteBatchComponent), typeof(SpriteComponent))]
    public class SpriteSystem : ComponentSystem
    {
        public override void DrawEntity(Entity entity, GameTime gameTime)
        {
            base.DrawEntity(entity, gameTime);

            var batch = entity.GetComponent<SpriteBatchComponent>();
            var sprites = entity.GetComponents<SpriteComponent>();

            foreach (var sprite in sprites)
            {
                if (!sprite.Sprite.IsVisible)
                    continue;
                
                batch.SpriteBatch.Draw(sprite.Sprite.Texture,
                    sprite.Sprite.Position,
                    sprite.Sprite.Texture.Bounds,
                    Color.White,
                    sprite.Sprite.Rotation,
                    Vector2.Zero, 
                    sprite.Sprite.Scale,
                    SpriteEffects.None, 1f);
            }
        }
    }
}