using MonoGame.Additions.Tiled;
using Newtonsoft.Json;

namespace MonoGame.Additions.ContentPipeline.Tiled
{
    public sealed class TiledTilesetRaw
    {
        public TiledTilesetRaw()
        {
            TilesetMetaData = new TiledTileset();
        }

        [JsonProperty("firstgid")]
        public int FirstGID { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        public TiledTileset TilesetMetaData { get; set; }
    }
}