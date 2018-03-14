using MonoGame.Additions.Entities;

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