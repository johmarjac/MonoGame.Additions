﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MonoGame.Additions.Tiled
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TiledMapOrientation
    {
        [EnumMember(Value = "orthogonal")] Orthogonal
    }
}