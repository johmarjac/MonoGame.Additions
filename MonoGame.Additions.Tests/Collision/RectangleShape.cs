using Microsoft.Xna.Framework;
using System;

namespace MonoGame.Additions.Tests.Collision
{
    public class RectangleShape : Shape
    {
        public override bool IntersectingWith(CircleShape other)
        {
            var dist = new Vector2(Math.Abs(other.BoundingRectangle.X - BoundingRectangle.X), Math.Abs(other.BoundingRectangle.Y - BoundingRectangle.Y));

            if (dist.X > (BoundingRectangle.Width / 2 + other.Radius)) return false;
            if (dist.Y > (BoundingRectangle.Height / 2 + other.Radius)) return false;

            if (dist.X <= (BoundingRectangle.Width / 2)) return true;
            if (dist.Y <= (BoundingRectangle.Height / 2)) return true;

            var cornerDist = (dist.X - BoundingRectangle.Width / 2) * (dist.X - BoundingRectangle.Width / 2) +
                (dist.Y - BoundingRectangle.Height / 2) * (dist.Y - BoundingRectangle.Height / 2);

            return (cornerDist <= other.Radius * other.Radius);
        }

        public override bool IntersectingWith(RectangleShape other)
        {
            throw new NotImplementedException();
        }
    }
}