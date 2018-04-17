using Microsoft.Xna.Framework;
using MonoGame.Additions.Animations;
using MonoGame.Additions.Entities;
using MonoGame.Additions.Entities.Components;

namespace PlatformerGame.Entities
{
    public class Player : Entity
    {
        public Vector2 Position => GetComponent<TransformComponent>().Position;

        public float MoveSpeed { get; set; }

        public Player()
        {
            MoveSpeed = 4f;
        }

        public void PlayAnimation(string name)
        {
            GetComponent<SpriteSheetAnimationComponent>()?
                .Animations?
                .Play(name);
        }

        public void SetPosition(Vector2 position)
        {
            GetComponent<TransformComponent>()
                .Position = position;
        }
    }
}