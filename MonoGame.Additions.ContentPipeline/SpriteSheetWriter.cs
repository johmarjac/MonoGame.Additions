using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using MonoGame.Additions.Graphics;

namespace MonoGame.Additions.ContentPipeline
{
    [ContentTypeWriter]
    public class SpriteSheetWriter : ContentTypeWriter<SpriteSheet>
    {
        protected override void Write(ContentWriter output, SpriteSheet value)
        {
            output.Write(value.ImageSource);
            output.Write(value.Columns);
            output.Write(value.Rows);
            output.Write(value.SpriteWidth);
            output.Write(value.SpriteHeight);
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "MonoGame.Additions.Graphics.SpriteSheetReader, MonoGame.Additions";
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return "MonoGame.Additions.Graphics.SpriteSheet, MonoGame.Additions";
        }
    }
}