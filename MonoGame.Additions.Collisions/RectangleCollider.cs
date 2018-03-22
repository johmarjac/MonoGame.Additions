using Microsoft.Xna.Framework;
using System;

namespace MonoGame.Additions.Collisions
{
    public class RectangleCollider : Collider
    {
        public Vector2 Size { get; set; }

        public override bool IntersectsWith(Collider other)
        {
            throw new NotImplementedException();
        }
    }
}