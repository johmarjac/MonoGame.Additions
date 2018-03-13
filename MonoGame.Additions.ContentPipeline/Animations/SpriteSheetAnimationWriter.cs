using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using MonoGame.Additions.Animations;

namespace MonoGame.Additions.ContentPipeline.Animations
{
    [ContentTypeWriter]
    public class SpriteSheetAnimationWriter : ContentTypeWriter<SpriteSheetAnimation>
    {
        protected override void Write(ContentWriter output, SpriteSheetAnimation value)
        {
            output.Write(value.Name);
            output.Write(value.SpriteSheetSource);

            output.Write(value.Frames.Count);
            for(int i = 0; i < value.Frames.Count; i++)
            {
                output.Write(value.Frames[i].Index);
                output.Write(value.Frames[i].Duration);
            }
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "MonoGame.Additions.Animations.SpriteSheetAnimationReader, MonoGame.Additions.Animations";
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return "MonoGame.Additions.Animations.SpriteSheetAnimation, MonoGame.Additions.Animations";
        }
    }
}