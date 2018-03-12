using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Additions.Adapters
{
    public class WindowViewportAdapter : ViewportAdapter
    {
        public WindowViewportAdapter(GameWindow window, GraphicsDevice device)
            : base(device)
        {
            Window = window;
            window.ClientSizeChanged += Window_ClientSizeChanged;
        }

        private void Window_ClientSizeChanged(object sender, System.EventArgs e)
        {
            var x = Window.ClientBounds.Width;
            var y = Window.ClientBounds.Height;

            GraphicsDevice.Viewport = new Viewport(0, 0, x, y);
        }

        public override Matrix GetScaleMatrix()
        {
            return Matrix.Identity;
        }

        protected readonly GameWindow Window;

        public override int VirtualWidth => Window.ClientBounds.Width;
        public override int VirtualHeight => Window.ClientBounds.Height;
        public override int ViewportWidth => GraphicsDevice.Viewport.Width;
        public override int ViewportHeight => GraphicsDevice.Viewport.Height;
    }
}