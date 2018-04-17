using MonoGame.Additions.Entities;

namespace PlatformerGame.Components
{
    public class PlayerComponent : EntityComponent
    {
        public float MoveSpeed { get; set; }

        public PlayerComponent()
        {
            MoveSpeed = 200f;
        }
    }
}