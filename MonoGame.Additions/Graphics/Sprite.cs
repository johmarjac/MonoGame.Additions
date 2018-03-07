using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Additions.Graphics
{
    public class Sprite : ITransform2D, IRectangular
    {
        public Sprite(Texture2D texture)
        {
            Texture = texture;
            IsVisible = true;
            Scale = 1;
        }

        public Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }
        public float Scale { get; set; }
        public float Rotation { get; set; }
        public Texture2D Texture { get; set; }
        public bool IsVisible { get; set; }
        public Rectangle BoundingRectangle
        {
            get
            {
                return new Rectangle(Position.ToPoint(), (Texture.Bounds.Size.ToVector2() * Scale).ToPoint());
            }
        }
    }
}