using Microsoft.Xna.Framework;
using System;

namespace MonoGame.Additions.Collisions
{
    public class CircleCollider : Collider
    {
        public float Radius { get; set; }

        public Vector2 CircleCenterPoint
        {
            get
            {
                return Transform.Position + new Vector2(Radius, Radius);
            }
        }

        public override bool IntersectsWith(Collider other)
        {
            if(other is CircleCollider circle)
            {
                var delta = (circle.CircleCenterPoint - CircleCenterPoint);
                var dist = delta.LengthSquared();

                return dist <= (Radius + circle.Radius) * (Radius + circle.Radius);
            }

            if(other is RectangleCollider rect)
            {
                var deltaX = Transform.Position.X - (Math.Max(rect.Transform.Position.X, Math.Min(Transform.Position.X, rect.Transform.Position.X + rect.Size.X)));
                var deltaY = Transform.Position.Y - (Math.Max(rect.Transform.Position.Y, Math.Min(Transform.Position.Y, rect.Transform.Position.Y + rect.Size.Y)));
                return (deltaX * deltaX + deltaY * deltaY) < (Radius * Radius);
            }

            throw new NotImplementedException(other.GetType().AssemblyQualifiedName);
        }
    }
}