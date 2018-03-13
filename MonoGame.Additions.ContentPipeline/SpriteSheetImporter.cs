using Microsoft.Xna.Framework.Content.Pipeline;
using MonoGame.Additions.Graphics;
using Newtonsoft.Json;
using System.IO;

namespace MonoGame.Additions.ContentPipeline
{
    [ContentImporter(".spritesheet", DefaultProcessor = "PassThroughProcessor", DisplayName = "MonoGame.Additions - SpriteSheetImporter")]
    public class SpriteSheetImporter : ContentImporter<SpriteSheet>
    {
        public override SpriteSheet Import(string filename, ContentImporterContext context)
        {
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None))
            using (var reader = new StreamReader(file))
            {
                return JsonConvert.DeserializeObject<SpriteSheet>(reader.ReadToEnd());
            }
        }
    }
}