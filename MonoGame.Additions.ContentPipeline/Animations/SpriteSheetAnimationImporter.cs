using Microsoft.Xna.Framework.Content.Pipeline;
using MonoGame.Additions.Animations;
using Newtonsoft.Json;
using System.IO;

namespace MonoGame.Additions.ContentPipeline.Animations
{
    [ContentImporter(".ssanimation", DefaultProcessor = "PassThroughProcessor", DisplayName = "MonoGame.Additions - SpriteSheetAnimationImporter")]
    public class SpriteSheetAnimationImporter : ContentImporter<SpriteSheetAnimation>
    {
        public override SpriteSheetAnimation Import(string filename, ContentImporterContext context)
        {
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None))
            using (var reader = new StreamReader(file))
            {
                return JsonConvert.DeserializeObject<SpriteSheetAnimation>(reader.ReadToEnd());
            }
        }
    }
}