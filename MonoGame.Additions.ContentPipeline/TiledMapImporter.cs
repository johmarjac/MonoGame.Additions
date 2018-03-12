using Microsoft.Xna.Framework.Content.Pipeline;
using MonoGame.Additions.Tiled;

namespace MonoGame.Additions.ContentPipeline
{
    [ContentImporter(".tmx", DefaultProcessor = "PassThroughProcessor", DisplayName = "MonoGame.Addition - TiledMapImporter")]
    public class TiledMapImporter : ContentImporter<TiledMapRaw>
    {
        public override TiledMapRaw Import(string filename, ContentImporterContext context)
        {
            
        }
    }
}