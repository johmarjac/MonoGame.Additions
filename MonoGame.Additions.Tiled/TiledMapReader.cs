using Microsoft.Xna.Framework.Content;
using Newtonsoft.Json;

namespace MonoGame.Additions.Tiled
{
    public class TiledMapReader : ContentTypeReader<TiledMap>
    {
        protected override TiledMap Read(ContentReader input, TiledMap existingInstance)
        {
            return JsonConvert.DeserializeObject<TiledMap>(input.ReadString());
        }
    }
}