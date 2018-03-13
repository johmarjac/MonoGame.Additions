using Microsoft.Xna.Framework.Graphics;
using MonoGame.Additions.Graphics;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MonoGame.Additions.Animations
{
    public class SpriteSheetAnimations
    {
        public SpriteSheetAnimations()
        {
            Animations = new List<SpriteSheetAnimation>();
        }

        public void Play(string name)
        {
            var nextAnimation = Animations
                .FirstOrDefault(a => a.Name == name);

            if (nextAnimation != null)
                CurrentAnimation = nextAnimation;

            CurrentAnimation?.Play();
        }

        public void Pause()
        {
            if (CurrentAnimation == null)
                return;

            CurrentAnimation?.Pause();
        }

        public void Stop()
        {
            if (CurrentAnimation == null)
                return;

            CurrentAnimation?.Stop();
        }

        [JsonProperty("spritesheet")]
        public string SpriteSheetSource { get; set; }

        [JsonIgnore]
        public SpriteSheet SpriteSheet { get; set; }

        [JsonProperty("animations")]
        public List<SpriteSheetAnimation> Animations { get; set; }

        [JsonIgnore]
        public SpriteSheetAnimation CurrentAnimation { get; private set; }

        [JsonIgnore]
        public SpriteEffects SpriteEffects { get; set; }
    }
}