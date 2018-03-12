using System.Runtime.Serialization;

namespace MonoGame.Additions.Tiled
{
    public enum TiledType
    {
        [EnumMember(Value = "map")] Map,
        [EnumMember(Value = "tileset")] Tileset,
        [EnumMember(Value = "tilelayer")] TileLayer
    }
}