using System.Xml.Serialization;

namespace MonoGame.Additions.Tiled
{
    [XmlRoot("map")]
    public sealed class TiledMapProperties
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("tiledversion")]
        public string TiledVersion { get; set; }

        [XmlAttribute("orientation")]
        public TiledMapOrientation Orientation { get; set; }

        [XmlAttribute("renderorder")]
        public TiledMapRenderOrder RenderOrder { get; set; }

        [XmlAttribute("width")]
        public int Width { get; set; }

        [XmlAttribute("height")]
        public int Height { get; set; }

        [XmlAttribute("tilewidth")]
        public int TileWidth { get; set; }

        [XmlAttribute("tileheight")]
        public int TileHeight { get; set; }

        [XmlAttribute("infinite")]
        public bool Infinite { get; set; }

        [XmlAttribute("nextobjectid")]
        public int NextObjectId { get; set; }
    }
}