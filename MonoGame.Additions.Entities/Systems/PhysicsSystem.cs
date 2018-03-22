using Microsoft.Xna.Framework;
using MonoGame.Additions.Entities.Attributes;
using MonoGame.Additions.Entities.Components;

namespace MonoGame.Additions.Entities.Systems
{
    [ComponentSystem]
    [RequiredComponents(typeof(RigidbodyComponent), typeof(TransformComponent))]
    public class PhysicsSystem : ComponentSystem
    {
        private const float Gravity = 9.812f;
        public bool GravitySystem { get; set; }

        public PhysicsSystem()
        {
            GravitySystem = false;
        }

        public override void UpdateEntity(Entity entity, GameTime gameTime)
        {
            base.UpdateEntity(entity, gameTime);

            var transformComponent = entity.GetComponent<TransformComponent>();
            var rigidbodyComponent = entity.GetComponent<RigidbodyComponent>();

            if (GravitySystem)
                rigidbodyComponent.Velocity += new Vector2(0, Gravity);

            transformComponent.Position += rigidbodyComponent.Velocity;
        }
    }
}