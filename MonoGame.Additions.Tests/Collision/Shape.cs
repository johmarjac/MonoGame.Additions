using Microsoft.Xna.Framework;

namespace MonoGame.Additions.Tests.Collision
{
    public abstract class Shape : IShapeIntersectable, ITransform2D
    {
        public Vector2 Position { get; set; }

        public Vector2 Size { get; set; }

        public Vector2 Origin { get; set; }

        public float Scale { get; set; }

        public float Rotation { get; set; }

        public Rectangle BoundingRectangle
        {
            get
            {
                return
                    new Rectangle(Position.ToPoint(), Size.ToPoint());
            }
        }

        public abstract bool IntersectingWith(CircleShape other);

        public abstract bool IntersectingWith(RectangleShape other);
    }
}