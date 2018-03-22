using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;

namespace MonoGame.Additions.Graphics
{
    public class SpriteSheet
    {        
        public Rectangle this[int idx]
        {
            get
            {
                var x = idx % Columns;
                var y = idx / Columns;

                return 
                    new Rectangle(x * SpriteWidth, y * SpriteHeight, SpriteWidth, SpriteHeight);
            }
        }

        public Sprite Sprite { get; set; }

        [JsonProperty("image")]
        public string ImageSource { get; set; }

        [JsonProperty("columns")]
        public int Columns { get; set; }

        [JsonProperty("rows")]
        public int Rows { get; set; }

        [JsonProperty("spritewidth")]
        public int SpriteWidth { get; set; }
        
        [JsonProperty("spriteheight")]
        public int SpriteHeight { get; set; }
    }
}