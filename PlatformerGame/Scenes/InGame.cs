using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Additions.Animations;
using MonoGame.Additions.Animations.Systems;
using MonoGame.Additions.Entities;
using MonoGame.Additions.Scenes;
using MonoGame.Additions.Tiled;
using MonoGame.Additions.Tiled.Systems;
using PlatformerGame.Entities;
using PlatformerGame.System;

namespace PlatformerGame.Scenes
{
    public class InGame : Scene
    {
        public override void Initialize()
        {
            base.Initialize();

            var c = new SpriteSheetAnimationSystem();

            ecs = new EntityComponentSystem(Game);
            ef = new EntityFactory(ecs);
            ecs.Initialize();
            ecs.RegisterSystem<TiledMapSystem>();
            ecs.RegisterSystem<PlayerController>();
        }

        public override void LoadContent()
        {
            Level = ef.CreateLevel(Content.Load<TiledMap>("Levels/TestLevel"));
            Player = ef.CreatePlayer(Content.Load<SpriteSheetAnimations>("Animations/Player"));
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            ecs.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            ecs.Draw(gameTime);
            base.Draw(gameTime);
        }

        private EntityComponentSystem ecs;
        private EntityFactory ef;

        public Level Level { get; private set; }
        public Player Player { get; private set; }
    }
}