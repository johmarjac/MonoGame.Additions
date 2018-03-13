using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Additions.Graphics;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonoGame.Additions.Animations
{
    public class SpriteSheetAnimation
    {
        public SpriteSheetAnimation()
        {
            Frames = new List<SpriteSheetAnimationFrame>();
            IsRunning = true;
            IsLooping = true;
        }

        public void Update(GameTime gameTime)
        {
            if(IsRunning)
            {
                var currentFrameTime = (float)gameTime.TotalGameTime.TotalMilliseconds;

                if((currentFrameTime - LastFrameTime) >= Frames[CurrentFrameListIndex].Duration)
                {
                    if (CurrentFrameListIndex + 1 == Frames.Count)
                    {
                        if (IsLooping)
                            CurrentFrameListIndex = 0;
                        else
                            IsRunning = false;
                    }
                    else
                        CurrentFrameListIndex++;
                    
                    LastFrameTime = currentFrameTime;
                }
            }
        }

        public void Play()
        {
            IsRunning = true;
        }

        public void Pause()
        {
            IsRunning = false;
        }

        public void Stop()
        {
            IsRunning = false;
            CurrentFrameListIndex = 0;
        }
        
        [JsonIgnore]
        public SpriteSheet SpriteSheet { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("spritesheet")]
        public string SpriteSheetSource { get; set; }

        [JsonProperty("frames")]
        public List<SpriteSheetAnimationFrame> Frames { get; set; }

        public SpriteEffects SpriteEffects { get; set; }
        public bool IsRunning { get; set; }
        public bool IsLooping { get; set; }
        public int CurrentFrameListIndex { get; set; }
        public float LastFrameTime { get; set; }
    }
}