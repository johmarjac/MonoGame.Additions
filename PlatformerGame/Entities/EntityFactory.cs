using MonoGame.Additions.Animations;
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

        public Player CreatePlayer(SpriteSheetAnimations playerAnimations)
        {
            var entity = Ecs.CreateEntity<Player>();

            entity.Attach<TransformComponent>();

            entity.Attach<SpriteSheetAnimationComponent>()
                .Animations = playerAnimations;

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