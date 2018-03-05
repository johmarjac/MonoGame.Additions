using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Additions.Graphics
{
    public class Sprite : ITransform2D
    {
        public Sprite(Texture2D texture)
        {
            Texture = texture;
            IsVisible = true;
        }

        public Vector2 Position { get; set; }
        public Vector2 Scalation { get; set; }
        public float Rotation { get; set; }
        public Texture2D Texture { get; set; }
        public bool IsVisible { get; set; }
    }
}