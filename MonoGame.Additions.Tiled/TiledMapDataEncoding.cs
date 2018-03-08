using System.Xml.Serialization;

namespace MonoGame.Additions.Tiled
{
    public sealed partial class TiledMapData
    {
        public enum DataEncoding
        {
            [XmlEnum("csv")]
            Csv
        }
    }
}