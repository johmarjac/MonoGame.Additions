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
            return (Transform.Position + Transform.Origin) * 0.5f;
        }

        public override bool IntersectingWith(CircleShape other) 
        {
            return (other.GetCircleCenter() - GetCircleCenter()).LengthSquared() < (Radius * Radius);
        }
    }
}