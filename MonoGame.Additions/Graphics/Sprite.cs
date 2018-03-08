using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Additions.Graphics
{
    public class Sprite
    {
        public Sprite(Texture2D texture)
        {
            Texture = texture;
            IsVisible = true;
        }
        
        public Texture2D Texture { get; set; }
        public SpriteEffects Effect { get; set; }
        public bool IsVisible { get; set; }
    }
}