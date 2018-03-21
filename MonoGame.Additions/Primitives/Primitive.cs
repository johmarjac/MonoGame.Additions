using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Additions.Primitives
{
    public abstract class Primitive
    {
        public VertexPositionColor[] Vertices { get; protected set; }
        public PrimitiveType Type { get; protected set; }
        public int PrimitiveCount { get; protected set; }
    }
}