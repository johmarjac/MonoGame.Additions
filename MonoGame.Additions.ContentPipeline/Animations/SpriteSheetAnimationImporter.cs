using Microsoft.Xna.Framework.Content.Pipeline;
using MonoGame.Additions.Animations;
using Newtonsoft.Json;
using System.IO;

namespace MonoGame.Additions.ContentPipeline.Animations
{
    [ContentImporter(".anis", DefaultProcessor = "PassThroughProcessor", DisplayName = "MonoGame.Additions - SpriteSheetAnimationsImporter")]
    public class SpriteSheetAnimationImporter : ContentImporter<SpriteSheetAnimations>
    {
        public override SpriteSheetAnimations Import(string filename, ContentImporterContext context)
        {
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None))
            using (var reader = new StreamReader(file))
            {
                return JsonConvert.DeserializeObject<SpriteSheetAnimations>(reader.ReadToEnd());
            }
        }
    }
}