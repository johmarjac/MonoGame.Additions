using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Additions.Tiled
{
    public sealed class TiledTileset
    {
        public int Columns { get; set; }
        public string ImageSource { get; set; }
        public Texture2D Image { get; internal set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public int Margin { get; set; }
        public int Spacing { get; set; }
        public string Name { get; set; }
        public int TileCount { get; set; }
        public int TileHeight { get; set; }
        public int TileWidth { get; set; }
        public TiledType Type { get; set; }
    }
}