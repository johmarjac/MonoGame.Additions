using Microsoft.Xna.Framework;
using MonoGame.Additions.Entities;
using MonoGame.Additions.Entities.Attributes;
using MonoGame.Additions.Entities.Components;

namespace MonoGame.Additions.Animations.Systems
{
    [RequiredComponents(typeof(SpriteSheetAnimationComponent), typeof(TransformComponent))]
    public class SpriteSheetAnimationSystem : ComponentSystem
    {
        private SpriteSheetAnimationsRenderer _renderer;

        public override void Initialize()
        {
            _renderer = new SpriteSheetAnimationsRenderer(GraphicsDevice);

            base.Initialize();
        }

        public override void UpdateEntity(Entity entity, GameTime gameTime)
        {
            var animationsComponent = entity.GetComponent<SpriteSheetAnimationComponent>();

            _renderer.Update(animationsComponent.Animations, gameTime);

            base.UpdateEntity(entity, gameTime);
        }

        public override void DrawEntity(Entity entity, GameTime gameTime)
        {
            var animationsComponent = entity.GetComponent<SpriteSheetAnimationComponent>();
            var transformComponent = entity.GetComponent<TransformComponent>();

            var transformMatrix = transformComponent.TransformMatrix;

            _renderer.Draw(animationsComponent.Animations, ref transformMatrix);

            base.DrawEntity(entity, gameTime);
        }
    }
}