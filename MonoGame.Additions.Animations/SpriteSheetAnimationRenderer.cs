using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Additions.Animations
{
    public class SpriteSheetAnimationRenderer
    {
        public SpriteSheetAnimationRenderer(GraphicsDevice device)
        {
            SpriteBatch = new SpriteBatch(device);
        }

        public void Update(SpriteSheetAnimation animation, GameTime gameTime)
        {
            animation.Update(gameTime);
        }

        public void Draw(SpriteSheetAnimation animation, ref Matrix transformMatrix)
        {
            SpriteBatch.Begin(transformMatrix: transformMatrix);

            SpriteBatch.Draw(animation.SpriteSheet.Image,
                new Rectangle(0, 0, animation.SpriteSheet.SpriteWidth, animation.SpriteSheet.SpriteHeight),
                animation.SpriteSheet[animation.Frames[animation.CurrentFrameListIndex].Index], Color.White, 0f, Vector2.Zero, animation.SpriteEffects, 0.0f);

            SpriteBatch.End();
        }

        protected readonly SpriteBatch SpriteBatch;
    }
}