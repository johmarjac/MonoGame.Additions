using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Additions.Primitives
{
    public sealed class Circle : Primitive
    {
        public bool IsFilled { get; }

        internal Circle(VertexPositionColor[] vertices, PrimitiveType type, bool isFilled)
        {
            Vertices = vertices;
            Type = type;
            IsFilled = isFilled;
        }
    }
}