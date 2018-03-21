using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Additions.Primitives;

namespace MonoGame.Additions
{
    public static class SpriteBatchExt
    {
        public static void DrawCircle(this SpriteBatch batch, Circle circle, ref Matrix transformMatrix)
        {
            var effect = new BasicEffect(batch.GraphicsDevice);

            effect.VertexColorEnabled = true;
            effect.View = transformMatrix;
            effect.Projection = Matrix.CreateOrthographicOffCenter(0, batch.GraphicsDevice.Viewport.Width, batch.GraphicsDevice.Viewport.Height, 0, 0, -1);

            foreach(var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                batch.GraphicsDevice.DrawUserPrimitives(circle.Type, circle.Vertices, 0, circle.IsFilled ? circle.Vertices.Length - 2 : circle.Vertices.Length - 1);
            }
        }
    }
}