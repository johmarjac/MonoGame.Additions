using MonoGame.Additions.Entities;
using MonoGame.Additions.Scenes;
using PlatformerGame.Entities;

namespace PlatformerGame.Scenes
{
    public class InGame : Scene
    {
        public InGame()
        {
            ecs = new EntityComponentSystem(Game);
            ef = new EntityFactory(ecs);
        }

        public override void Initialize()
        {
            base.Initialize();

            Player = ef.CreatePlayer();
        }

        private readonly EntityComponentSystem ecs;
        private readonly EntityFactory ef;

        public Entity Player { get; private set; }
    }
}