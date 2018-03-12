namespace MonoGame.Additions.Tiled
{
    public abstract class TiledMapLayer
    {
        public TiledType Type { get; set; }
        public string Name { get; set; }
        public float Opacity { get; set; }
        public bool Visible { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}