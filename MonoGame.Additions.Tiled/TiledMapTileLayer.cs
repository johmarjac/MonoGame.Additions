using Newtonsoft.Json;

namespace MonoGame.Additions.Tiled
{
    public sealed class TiledMapTileLayer : TiledMapLayer
    {
        [JsonProperty("data")]
        public int[] Data { get; set; }
    }
}