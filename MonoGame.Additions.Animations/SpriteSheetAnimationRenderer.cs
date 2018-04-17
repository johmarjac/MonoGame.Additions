using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Additions.Graphics;

namespace MonoGame.Additions.Animations
{
    public class SpriteSheetAnimationsRenderer
    {
        public SpriteSheetAnimationsRenderer(GraphicsDevice device)
        {
            SpriteBatch = new SpriteBatch(device);
        }

        public void Update(SpriteSheetAnimations animations, GameTime gameTime)
        {
            animations.CurrentAnimation?.Update(gameTime);
        }

        public void Draw(SpriteSheetAnimation animation, SpriteSheet spritesheet, ref Matrix TransformMatrix, SpriteEffects effects = SpriteEffects.None)
        {
            if (animation == null)
                return;

            SpriteBatch.Begin(transformMatrix: TransformMatrix);

            SpriteBatch.Draw(
                spritesheet.Sprite.Texture,
                new Rectangle(0, 0, spritesheet.SpriteWidth, spritesheet.SpriteHeight),
                spritesheet[animation.Frames[animation.CurrentFrameIndex].Index],
                Color.White,
                0.0f,
                Vector2.Zero,
                effects,
                0.0f);

            SpriteBatch.End();
        }

        public void Draw(SpriteSheetAnimations animations, ref Matrix transformMatrix)
        {
            if (animations.CurrentAnimation == null)
                return;

            SpriteBatch.Begin(transformMatrix: transformMatrix);

            SpriteBatch.Draw(
                animations.SpriteSheet.Sprite.Texture,
                new Rectangle(0, 0, animations.SpriteSheet.SpriteWidth, animations.SpriteSheet.SpriteHeight),
                animations.SpriteSheet[animations.CurrentAnimation.Frames[animations.CurrentAnimation.CurrentFrameIndex].Index],
                Color.White,
                0.0f,
                Vector2.Zero,
                animations.SpriteEffects, 
                0.0f);

            SpriteBatch.End();
        }

        protected readonly SpriteBatch SpriteBatch;
    }
}