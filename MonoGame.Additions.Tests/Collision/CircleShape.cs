using Microsoft.Xna.Framework;

namespace MonoGame.Additions.Tests.Collision
{
    public class CircleShape : Shape
    {
        public float Radius { get; set; }

        public CircleShape(float radius)
        {
            Radius = radius;
        }

        public Vector2 GetCircleCenter()
        {
            return (Position + Origin) * 0.5f;
        }

        public override bool IntersectingWith(CircleShape other)
        {
            return (circle.GetCircleCenter() - GetCircleCenter()).LengthSquared() < (Radius * Radius);
        }
    }
}