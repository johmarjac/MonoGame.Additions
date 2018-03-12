using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Additions.Adapters
{
    public abstract class ViewportAdapter
    {
        protected ViewportAdapter(GraphicsDevice device)
        {
            GraphicsDevice = device;
        }

        public abstract Matrix GetScaleMatrix();

        public abstract int VirtualWidth { get; } 
        public abstract int VirtualHeight { get; }
        public abstract int ViewportWidth { get; }
        public abstract int ViewportHeight { get; }
        public GraphicsDevice GraphicsDevice { get; }
    }
}