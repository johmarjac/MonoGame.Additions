using Microsoft.Xna.Framework;

namespace MonoGame.Additions.Entities.Components
{
    public class RigidbodyComponent : EntityComponent
    {
        public Vector2 Velocity { get; set; }
        public bool IsStatic { get; set; }

        public void EaseOut(Vector2 destination, float ease = 0.05f)
        {
            var transform = Entity.GetComponent<TransformComponent>();

            Velocity = (destination - transform.Position) * ease;
        }
    }
}