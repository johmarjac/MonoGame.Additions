using MonoGame.Additions.Entities;
using MonoGame.Additions.Entities.Components;

namespace MonoGame.Additions.Tests.Collision
{
    public abstract class Shape : EntityComponent, IShapeIntersectable
    {
        public TransformComponent Transform => Entity.GetComponent<TransformComponent>();

        public abstract bool IntersectingWith(CircleShape other);
    }
}