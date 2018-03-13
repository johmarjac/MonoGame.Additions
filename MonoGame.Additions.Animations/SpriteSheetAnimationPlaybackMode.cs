using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MonoGame.Additions.Animations
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SpriteSheetAnimationPlaybackMode
    {
        [EnumMember(Value = "once")] Once,
        [EnumMember(Value = "loop")] Loop
    }
}