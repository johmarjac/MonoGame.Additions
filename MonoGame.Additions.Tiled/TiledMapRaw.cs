namespace MonoGame.Additions.Tiled
{
    public sealed class TiledMapRaw
    {
        public string version { get; set; }
        public string tiledversion { get; set; }
        public TiledMapOrientation orientation { get; set; }
        public TiledMapRenderOrder renderorder { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int tilewidth { get; set; }
        public int tileheight { get; set; }
        public bool infinite { get; set; }
        public int nextobjectid { get; set; }
        public TiledTilesetRaw[] tilesets { get; set; }
        public TiledMapLayerRaw[] layers { get; set; }
    }
}