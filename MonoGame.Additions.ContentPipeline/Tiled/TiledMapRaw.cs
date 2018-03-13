using MonoGame.Additions.Tiled;
using System.Collections.Generic;
using System.Linq;

namespace MonoGame.Additions.ContentPipeline.Tiled
{
    public sealed class TiledMapRaw
    {
        public TiledMapRaw()
        {
            Tilesets = new List<TiledTilesetRaw>();
            Layers = new List<TiledMapLayer>();
        }

        internal TiledMap ToTiledMap()
        {
            var map = new TiledMap()
            {
                Version = Version,
                TiledVersion = TiledVersion,
                Width = Width,
                Height = Height,
                TileWidth = TileWidth,
                TileHeight = TileHeight,
                Type = Type,
                Orientation = Orientation,
                RenderOrder = RenderOrder,
                NextObjectId = NextObjectId,
                Infinite = Infinite,
                Layers = Layers
            };

            Tilesets.ForEach(t => t.TilesetMetaData.FirstGID = t.FirstGID);
            map.Tilesets = Tilesets.Select(t => t.TilesetMetaData).ToList();

            return map;
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
        public List<TiledTilesetRaw> Tilesets { get; set; }
        public List<TiledMapLayer> Layers { get; set; }
    }
}