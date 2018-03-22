using MonoGame.Additions.Entities;
using MonoGame.Additions.Entities.Components;

namespace MonoGame.Additions.Collisions
{
    public abstract class Collider : EntityComponent, ICollidable
    {
        public TransformComponent Transform => Entity.GetComponent<TransformComponent>();
        
        public abstract bool IntersectsWith(Collider other);
    }
}