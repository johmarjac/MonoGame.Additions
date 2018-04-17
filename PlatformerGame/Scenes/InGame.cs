using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Additions.Animations;
using MonoGame.Additions.Animations.Systems;
using MonoGame.Additions.Entities;
using MonoGame.Additions.Scenes;
using PlatformerGame.Entities;

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
        }

        public override void LoadContent()
        {
            Player = ef.CreatePlayer(Content.Load<SpriteSheetAnimations>("Animations/Player"));
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            ecs.Update(gameTime);

            var kbState = Keyboard.GetState();

            if (kbState.IsKeyDown(Keys.D))
            {
                Player.PlayAnimation("player_move");
                Player.GetComponent<SpriteSheetAnimationComponent>()
                    .Animations.SpriteEffects = SpriteEffects.None;

                Player.SetPosition(new Vector2(Player.Position.X + Player.MoveSpeed, Player.Position.Y));
            }
            else if(kbState.IsKeyDown(Keys.A))
            {
                Player.PlayAnimation("player_move");
                Player.GetComponent<SpriteSheetAnimationComponent>()
                    .Animations.SpriteEffects = SpriteEffects.FlipHorizontally;

                Player.SetPosition(new Vector2(Player.Position.X - Player.MoveSpeed, Player.Position.Y));
            }
            else
                Player.PlayAnimation("player_stand");

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            ecs.Draw(gameTime);
            base.Draw(gameTime);
        }

        private EntityComponentSystem ecs;
        private EntityFactory ef;

        public Player Player { get; private set; }
    }
}