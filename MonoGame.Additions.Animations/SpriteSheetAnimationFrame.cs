using Newtonsoft.Json;

namespace MonoGame.Additions.Animations
{
    public class SpriteSheetAnimationFrame
    {
        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }
    }
}