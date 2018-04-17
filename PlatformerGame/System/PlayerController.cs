using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Additions.Animations;
using MonoGame.Additions.Entities;
using MonoGame.Additions.Entities.Attributes;
using PlatformerGame.Components;

namespace PlatformerGame.System
{
    [RequiredComponents(typeof(PlayerComponent))]
    public class PlayerController : ComponentSystem
    {
        public override void UpdateEntity(Entity entity, GameTime gameTime)
        {
            base.UpdateEntity(entity, gameTime);

            var animations = entity.GetComponent<SpriteSheetAnimationComponent>();

            var kbState = Keyboard.GetState();

            if (kbState.IsKeyDown(Keys.D))
            {
                animations.Animations.Play("player_move");
                animations.Animations.SpriteEffects = SpriteEffects.None;


            }
            else if (kbState.IsKeyDown(Keys.A))
            {
                animations.Animations.Play("player_move");
                animations.Animations.SpriteEffects = SpriteEffects.FlipHorizontally;
                                
            }
            else
                animations.Animations.Play("player_stand");
        }

    }
}