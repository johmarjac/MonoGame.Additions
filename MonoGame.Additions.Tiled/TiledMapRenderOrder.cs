using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MonoGame.Additions.Tiled
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TiledMapRenderOrder
    {
        [EnumMember(Value = "right-down")] RightDown
    }
}