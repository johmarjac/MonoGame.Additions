using Microsoft.Xna.Framework.Content.Pipeline;
using MonoGame.Additions.Tiled;

namespace MonoGame.Additions.ContentPipeline.Tiled
{
    [ContentProcessor(DisplayName = "MonoGame.Additions - TiledMapProcessor")]
    public class TiledMapProcesssor : ContentProcessor<TiledMapRaw, TiledMap>
    {
        public override TiledMap Process(TiledMapRaw input, ContentProcessorContext context)
        {
            return input.ToTiledMap();
        }
    }
}