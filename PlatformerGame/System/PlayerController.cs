using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Additions;
using MonoGame.Additions.Animations;
using MonoGame.Additions.Entities;
using MonoGame.Additions.Entities.Attributes;
using MonoGame.Additions.Entities.Components;
using PlatformerGame.Components;

namespace PlatformerGame.System
{
    [RequiredComponents(typeof(PlayerComponent), typeof(SpriteSheetAnimationComponent), typeof(TransformComponent))]
    public class PlayerController : ComponentSystem
    {
        public override void UpdateEntity(Entity entity, GameTime gameTime)
        {
            base.UpdateEntity(entity, gameTime);

            var animations = entity.GetComponent<SpriteSheetAnimationComponent>();
            var transform = entity.GetComponent<TransformComponent>();
            var player = entity.GetComponent<PlayerComponent>();

            var kbState = Keyboard.GetState();

            if (kbState.IsKeyDown(Keys.D))
            {
                animations.Animations.Play("player_move");
                animations.Animations.SpriteEffects = SpriteEffects.None;

                transform.Move(new Vector2(player.MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds, 0));
            }
            else if (kbState.IsKeyDown(Keys.A))
            {
                animations.Animations.Play("player_move");
                animations.Animations.SpriteEffects = SpriteEffects.FlipHorizontally;

                transform.Move(new Vector2(-player.MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds, 0));
            }
            else if(kbState.IsKeyDown(Keys.S))
                transform.Move(new Vector2(0, player.MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds));
            else
                animations.Animations.Play("player_stand");

            var camera = Game.Services.GetService<Camera2D>();
            if (camera != null)
                camera.LookAt(transform.Position + (new Vector2(animations.Animations.SpriteSheet.SpriteWidth, animations.Animations.SpriteSheet.SpriteHeight)) * 0.5f);
        }

    }
}