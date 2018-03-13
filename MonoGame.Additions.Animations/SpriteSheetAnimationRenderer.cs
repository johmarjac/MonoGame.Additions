using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        public void Draw(SpriteSheetAnimations animations, ref Matrix transformMatrix)
        {
            if (animations.CurrentAnimation == null)
                return;

            SpriteBatch.Begin(transformMatrix: transformMatrix);

            SpriteBatch.Draw(
                animations.SpriteSheet.Image,
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