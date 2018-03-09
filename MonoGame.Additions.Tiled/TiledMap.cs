using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonoGame.Additions.Tiled
{
    public sealed class TiledMap
    {
        public TiledMap()
        {
            Tilesets = new List<TiledTileset>();
            TilesetSources = new List<TiledTilesetSource>();
        }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("tilewidth")]
        public int TileWidth { get; set; }

        [JsonProperty("tileheight")]
        public int TileHeight { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("type")]
        public TiledType Type { get; set; }

        [JsonProperty("orientation")]
        public TiledMapOrientation Orientation { get; set; }

        [JsonProperty("renderorder")]
        public TiledMapRenderOrder RenderOrder { get; set; }

        [JsonProperty("tiledversion")]
        public string TiledVersion { get; set; }

        [JsonProperty("nextobjectid")]
        public int NextObjectId { get; set; }

        [JsonProperty("infinite")]
        public bool Infinite { get; set; }

        [JsonProperty("tilesets")]
        public List<TiledTilesetSource> TilesetSources { get; set; }
        
        [JsonProperty("internalTilesets")]
        public List<TiledTileset> Tilesets { get; set; }

        [JsonProperty("layers")]
        public List<TiledMapLayer> Layers { get; set; }
    }
}