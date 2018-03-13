using Microsoft.Xna.Framework.Content;
using MonoGame.Additions.Graphics;
using System.IO;

namespace MonoGame.Additions.Animations
{
    public class SpriteSheetAnimationsReader : ContentTypeReader<SpriteSheetAnimations>
    {
        protected override SpriteSheetAnimations Read(ContentReader input, SpriteSheetAnimations existingInstance)
        {
            if (existingInstance != null) return existingInstance;

            var animations = new SpriteSheetAnimations();
            animations.SpriteSheetSource = input.ReadString();

            var animationCount = input.ReadInt32();
            for(int i = 0; i < animationCount; i++)
            {
                var animation = new SpriteSheetAnimation();
                animation.Name = input.ReadString();
                animation.PlaybackMode = (SpriteSheetAnimationPlaybackMode)input.ReadInt32();

                var frameCount = input.ReadInt32();
                for(int j = 0; j < frameCount; j++)
                {
                    var frame = new SpriteSheetAnimationFrame();
                    frame.Index = input.ReadInt32();
                    frame.Duration = input.ReadInt32();

                    animation.Frames.Add(frame);
                }

                animations.Animations.Add(animation);
            }

            LoadSpriteSheet(input.ContentManager, animations);

            return animations;
        }

        private void LoadSpriteSheet(ContentManager content, SpriteSheetAnimations animations)
        {
            var path = Path.GetDirectoryName(animations.SpriteSheetSource);
            if (!Path.IsPathRooted(path))
                path = Path.Combine(content.RootDirectory, path);

            var filename = Path.GetFileNameWithoutExtension(animations.SpriteSheetSource);

            animations.SpriteSheet = content.Load<SpriteSheet>(path + "\\" + filename);
        }
    }
}