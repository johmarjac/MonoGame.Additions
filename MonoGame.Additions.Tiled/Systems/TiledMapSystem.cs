using Microsoft.Xna.Framework;
using MonoGame.Additions.Entities;
using MonoGame.Additions.Entities.Attributes;
using MonoGame.Additions.Entities.Components;
using MonoGame.Additions.Tiled.Components;

namespace MonoGame.Additions.Tiled.Systems
{
    [RequiredComponents(typeof(TiledMapComponent), typeof(TransformComponent))]
    public class TiledMapSystem : ComponentSystem
    {
        private TiledMapRenderer _renderer;

        public override void Initialize()
        {
            _renderer = new TiledMapRenderer(GraphicsDevice);
            base.Initialize();            
        }

        public override void DrawEntity(Entity entity, GameTime gameTime)
        {
            base.DrawEntity(entity, gameTime);

            var transformComponent = entity.GetComponent<TransformComponent>();
            var mapComponent = entity.GetComponent<TiledMapComponent>();
            var camera = Game.Services.GetService<Camera2D>();

            var transformMatrix = transformComponent.TransformMatrix;
            if (camera != null)
                transformMatrix = Matrix.Multiply(camera.GetViewMatrix(), transformMatrix);


            _renderer.Draw(mapComponent.Map, ref transformMatrix);
        }
    }
}