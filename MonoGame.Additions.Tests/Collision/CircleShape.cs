using Microsoft.Xna.Framework;

namespace MonoGame.Additions.Tests.Collision
{
    public class CircleShape : Shape
    {
        public float Radius { get; set; }

        public Vector2 CircleCenterPoint
        {
            get
            {
                return Transform.Position + new Vector2(Radius, Radius);
            }
        }

        public override bool IntersectingWith(CircleShape other) 
        {
            return (other.CircleCenterPoint - CircleCenterPoint).LengthSquared() < (Radius * Radius);
        }
    }
}