using System.Collections.Generic;

namespace MonoGame.Additions.Tiled
{
    public sealed class TiledMap
    {
        public TiledMap()
        {
            Tilesets = new List<TiledTileset>();
            Layers = new List<TiledMapLayer>();
        }

        public int Version { get; set; }
        public string TiledVersion { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public TiledType Type { get; set; }
        public TiledMapOrientation Orientation { get; set; }
        public TiledMapRenderOrder RenderOrder { get; set; }
        public int NextObjectId { get; set; }
        public bool Infinite { get; set; }
        public List<TiledTileset> Tilesets { get; set; }
        public List<TiledMapLayer> Layers { get; set; }
    }
}