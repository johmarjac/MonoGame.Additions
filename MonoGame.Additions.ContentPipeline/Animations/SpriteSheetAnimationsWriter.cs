using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using MonoGame.Additions.Animations;

namespace MonoGame.Additions.ContentPipeline.Animations
{
    [ContentTypeWriter]
    public class SpriteSheetAnimationsWriter : ContentTypeWriter<SpriteSheetAnimations>
    {
        protected override void Write(ContentWriter output, SpriteSheetAnimations value)
        {
            output.Write(value.SpriteSheetSource);

            output.Write(value.Animations.Count);
            for(int i = 0; i < value.Animations.Count; i++)
            {
                output.Write(value.Animations[i].Name);
                output.Write((int)value.Animations[i].PlaybackMode);

                output.Write(value.Animations[i].Frames.Count);
                for(int j = 0; j < value.Animations[i].Frames.Count; j++)
                {
                    output.Write(value.Animations[i].Frames[j].Index);
                    output.Write(value.Animations[i].Frames[j].Duration);
                }
            }
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "MonoGame.Additions.Animations.SpriteSheetAnimationsReader, MonoGame.Additions.Animations";
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return "MonoGame.Additions.Animations.SpriteSheetAnimations, MonoGame.Additions.Animations";
        }
    }
}