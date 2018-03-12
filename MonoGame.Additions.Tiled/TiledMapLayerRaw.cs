namespace MonoGame.Additions.Tiled
{
    public sealed class TiledMapLayerRaw
    {
        public string name { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public TiledMapLayerDataRaw data { get; set; }
    }
}