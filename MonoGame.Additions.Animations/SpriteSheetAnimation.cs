using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MonoGame.Additions.Animations
{
    public class SpriteSheetAnimation
    {
        public SpriteSheetAnimation()
        {
            Frames = new List<SpriteSheetAnimationFrame>();
        }

        public void Update(GameTime gameTime)
        {
            if(PlaybackState == SpriteSheetAnimationPlaybackState.Playing)
            {
                var currentFrameTime = (float)gameTime.TotalGameTime.TotalMilliseconds;

                if((currentFrameTime - LastFrameTime) >= Frames[CurrentFrameIndex].Duration)
                {
                    switch(PlaybackMode)
                    {
                        case SpriteSheetAnimationPlaybackMode.Loop:
                            if ((CurrentFrameIndex + 1) == Frames.Count)
                                CurrentFrameIndex = 0;
                            else
                                CurrentFrameIndex++;
                            break;
                        case SpriteSheetAnimationPlaybackMode.Once:
                            if ((CurrentFrameIndex + 1) == Frames.Count)
                                PlaybackState = SpriteSheetAnimationPlaybackState.Paused;
                            else
                                CurrentFrameIndex++;
                            break;
                    }

                    LastFrameTime = currentFrameTime;
                }
            }
        }

        public void Play()
        {
            PlaybackState = SpriteSheetAnimationPlaybackState.Playing;
        }

        public void Pause()
        {
            PlaybackState = SpriteSheetAnimationPlaybackState.Paused;
        }

        public void Stop()
        {
            PlaybackState = SpriteSheetAnimationPlaybackState.Stopped;
            CurrentFrameIndex = 0;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("playbackmode")]
        public SpriteSheetAnimationPlaybackMode PlaybackMode { get; set; }

        [JsonProperty("frames")]
        public List<SpriteSheetAnimationFrame> Frames { get; set; }

        public SpriteSheetAnimationPlaybackState PlaybackState { get; set; }

        private float LastFrameTime { get; set; }

        public int CurrentFrameIndex { get; private set; }
    }
}