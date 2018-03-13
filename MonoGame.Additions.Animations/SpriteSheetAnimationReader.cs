using Microsoft.Xna.Framework.Content;
using MonoGame.Additions.Graphics;
using System.IO;

namespace MonoGame.Additions.Animations
{
    public class SpriteSheetAnimationReader : ContentTypeReader<SpriteSheetAnimation>
    {
        protected override SpriteSheetAnimation Read(ContentReader input, SpriteSheetAnimation existingInstance)
        {
            if (existingInstance != null) return existingInstance;

            var animation = new SpriteSheetAnimation()
            {
                Name = input.ReadString(),
                SpriteSheetSource = input.ReadString()
            };

            var frameCount = input.ReadInt32();
            for(int i = 0; i < frameCount; i++)
            {
                animation.Frames.Add(new SpriteSheetAnimationFrame()
                {
                    Index = input.ReadInt32(),
                    Duration = input.ReadInt32()
                });
            }

            LoadSpriteSheet(input.ContentManager, animation);

            return animation;
        }

        private void LoadSpriteSheet(ContentManager content, SpriteSheetAnimation animation)
        {
            var path = Path.GetDirectoryName(animation.SpriteSheetSource);
            if (!Path.IsPathRooted(path))
                path = Path.Combine(content.RootDirectory, path);

            var filename = Path.GetFileNameWithoutExtension(animation.SpriteSheetSource);

            animation.SpriteSheet = content.Load<SpriteSheet>(path + "\\" + filename);
        }
    }
}