using MonoGame.Additions.Animations;
using MonoGame.Additions.Entities;
using MonoGame.Additions.Entities.Components;
using MonoGame.Additions.Tiled;
using MonoGame.Additions.Tiled.Components;
using PlatformerGame.Components;

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

            entity.Attach<PlayerComponent>();

            return entity;
        }

        public Level CreateLevel(TiledMap map)
        {
            var entity = Ecs.CreateEntity<Level>();

            entity.Attach<TransformComponent>();

            entity.Attach<TiledMapComponent>()
                .Map = map;

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