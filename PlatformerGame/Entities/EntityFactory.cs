using MonoGame.Additions.Entities;
using MonoGame.Additions.Entities.Components;

namespace PlatformerGame.Entities
{
    public class EntityFactory
    {
        public EntityFactory(EntityComponentSystem ecs)
        {
            Ecs = ecs;
        }

        public Entity CreatePlayer()
        {
            var entity = Ecs.CreateEntity();

            entity.Attach<TransformComponent>();

            return entity;
        }

        public Entity CreateEnemy()
        {
            var entity = Ecs.CreateEntity();

            return entity;
        }

        private readonly EntityComponentSystem Ecs;
    }
}