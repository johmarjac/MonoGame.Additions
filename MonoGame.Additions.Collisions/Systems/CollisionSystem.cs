using Microsoft.Xna.Framework;
using MonoGame.Additions.Entities;
using MonoGame.Additions.Entities.Attributes;
using MonoGame.Additions.Entities.Components;
using System.Collections.Generic;
using System.Linq;

namespace MonoGame.Additions.Collisions.Systems
{
    [ComponentSystem]
    [RequiredComponents()]
    public class CollisionSystem : ComponentSystem
    {
        public List<Entity> Entities { get; set; }
        
        public CollisionSystem()
        {
            Entities = new List<Entity>();
        }

        protected override void OnEntityComponentAttached(Entity entity, EntityComponent component)
        {
            base.OnEntityComponentAttached(entity, component);

            if (component is Collider)
                Entities.Add(entity);
        }

        protected override void OnEntityComponentDetached(Entity entity, EntityComponent component)
        {
            base.OnEntityComponentDetached(entity, component);

            if (component is Collider)
                Entities.Remove(entity);
        }

        public override void UpdateEntity(Entity entity, GameTime gameTime)
        {
            base.UpdateEntity(entity, gameTime);
            
            var collider = entity.GetComponent<Collider>();
            var transform = entity.GetComponent<TransformComponent>();
            var body = entity.GetComponent<RigidbodyComponent>();

            if (body == null) return;

            foreach(var other in Entities)
            {
                if (other == entity) continue;

                var otherCollider = other.GetComponent<Collider>();

                if (collider.IntersectsWith(otherCollider))
                    body.Velocity = Vector2.Zero;
            }
        }
    }
}