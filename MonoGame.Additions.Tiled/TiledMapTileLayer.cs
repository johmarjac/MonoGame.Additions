using Newtonsoft.Json;

namespace MonoGame.Additions.Tiled
{
    public sealed class TiledMapTileLayer : TiledMapLayer
    {
        [JsonProperty("data")]
        public int[] Data { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
        
        [JsonProperty("height")]
        public int Height { get; set; }
    }
}