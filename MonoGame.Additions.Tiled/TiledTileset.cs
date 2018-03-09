using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;

namespace MonoGame.Additions.Tiled
{
    public class TiledTileset
    {
        [JsonProperty("image")]
        public string ImageSource { get; set; }

        [JsonIgnore]
        public Texture2D Image { get; set; }

        [JsonProperty("columns")]
        public int Columns { get; set; }

        [JsonProperty("imageheight")]
        public int ImageHeight { get; set; }

        [JsonProperty("imagewidth")]
        public int ImageWidth { get; set; }

        [JsonProperty("margin")]
        public int Margin { get; set; }

        [JsonProperty("spacing")]
        public int Spacing { get; set; }

        [JsonProperty("tilecount")]
        public int TileCount { get; set; }

        [JsonProperty("tilewidth")]
        public int TileWidth { get; set; }

        [JsonProperty("tileheight")]
        public int TileHeight { get; set; }

        [JsonProperty("type")]
        public TiledType Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}