using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MonoGame.Additions.Tiled
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TiledType
    {
        [EnumMember(Value = "map")] Map,
        [EnumMember(Value = "tileset")] Tileset,
        [EnumMember(Value = "tilelayer")] TileLayer,
    }
}