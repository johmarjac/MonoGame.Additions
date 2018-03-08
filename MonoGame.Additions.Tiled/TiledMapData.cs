using System.Xml.Serialization;

namespace MonoGame.Additions.Tiled
{
    [XmlRoot("data")]
    public sealed partial class TiledMapData
    {
        [XmlAttribute("encoding")]
        public DataEncoding Encoding { get; set; }

        //[XmlArray]
        //public int[] Data { get; set; }
    }
}