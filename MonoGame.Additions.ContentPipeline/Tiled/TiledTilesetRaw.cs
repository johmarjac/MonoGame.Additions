using Newtonsoft.Json;

namespace MonoGame.Additions.ContentPipeline.Tiled
{
    public sealed class TiledTilesetRaw
    {
        [JsonProperty("firstgid")]
        public int FirstGID { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}