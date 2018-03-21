using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Additions.Entities.Attributes;
using MonoGame.Additions.Entities.Components;

namespace MonoGame.Additions.Entities.Systems
{
    [ComponentSystem]
    [RequiredComponents(typeof(PrimitiveComponent), typeof(TransformComponent))]
    public class PrimitivesRenderSystem : ComponentSystem
    {
        public override void DrawEntity(Entity entity, GameTime gameTime)
        {
            var transform = entity.GetComponent<TransformComponent>();
            var primitives = entity.GetComponents<PrimitiveComponent>();
            var projection = Matrix.CreateOrthographicOffCenter(0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 0, 0, -1);
            var effect = new BasicEffect(GraphicsDevice);
            
            effect.VertexColorEnabled = true;
            effect.Projection = projection;
            effect.View = transform.TransformMatrix + Game.Services.GetService<Camera2D>().GetViewMatrix();

            foreach(var primitive in primitives)
            {
                foreach(var pass in effect.CurrentTechnique.Passes)
                {
                    pass.Apply();

                    GraphicsDevice.DrawUserPrimitives(primitive.Primitive.Type, primitive.Primitive.Vertices, 0, primitive.Primitive.PrimitiveCount);
                }
            }

            base.DrawEntity(entity, gameTime);
        }
    }
}