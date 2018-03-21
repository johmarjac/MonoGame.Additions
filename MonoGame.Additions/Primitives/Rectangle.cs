using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Additions.Primitives
{
    public class Rectangle : Primitive
    {
        public static Rectangle Create(float width, float height, Color color)
        {
            var vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(0, 0, 0), color),
                new VertexPositionColor(new Vector3(width, 0, 0), color),
                new VertexPositionColor(new Vector3(width, height, 0), color),

                new VertexPositionColor(new Vector3(width, height, 0), color),
                new VertexPositionColor(new Vector3(0, height, 0), color),
                new VertexPositionColor(new Vector3(0, 0, 0), color)
            };

            return new Rectangle()
            {
                Vertices = vertices,
                PrimitiveCount = 2,
                Type = PrimitiveType.TriangleList
            };
        }
    }
}