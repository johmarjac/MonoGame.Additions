using Newtonsoft.Json;

namespace MonoGame.Additions.Tiled
{
    public class TiledMapLayer
    {
        [JsonProperty("data")]
        public int[] Data { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("opacity")]
        public float Opacity { get; set; }

        [JsonProperty("type")]
        public TiledType Type { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("offsetx")]
        public float OffsetX { get; set; }

        [JsonProperty("offsety")]
        public float OffsetY { get; set; }

        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }
    }
}