using Newtonsoft.Json;

namespace MonoGame.Additions.Tiled
{
    public class TiledTilesetSource
    {
        [JsonProperty("firstgid")]
        public int FirstGID { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}