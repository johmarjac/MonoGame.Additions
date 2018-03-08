using Microsoft.Xna.Framework;

namespace MonoGame.Additions.Entities.Components
{
    public class RigidbodyComponent : EntityComponent
    {
        public Vector2 Velocity { get; set; }
        public bool IsStatic { get; set; }
    }
}