using Microsoft.Xna.Framework;
using MonoGame.Additions.Adapters;

namespace MonoGame.Additions
{
    public class Camera2D : ITransform2D
    {
        public Camera2D(ViewportAdapter adapter)
        {
            Position = Vector2.Zero;
            Rotation = 0;
            Size = Vector2.One;
            Adapter = adapter;
        }

        public Matrix GetViewMatrix()
        {
            return
                GetVirtualViewMatrix() * 
                Adapter.GetScaleMatrix();
        }

        private Matrix GetVirtualViewMatrix()
        {
            return
                Matrix.CreateTranslation(new Vector3(-Position, 0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Size.X, Size.Y, 1);
        }

        public void Move(Vector2 direction)
        {
            Position += Vector2.Transform(direction, Matrix.CreateRotationZ(-Rotation));
        }

        public void Zoom(float deltaZoom)
        {
            Size *= deltaZoom;
        }

        public void SetZoom(float zoom)
        {
            Size = new Vector2(zoom, zoom);
        }

        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Size { get; set; }

        public Rectangle Bounds
        {
            get
            {
                return
                    new Rectangle(Position.ToPoint(), Size.ToPoint());
            }
        }
        
        public ViewportAdapter Adapter { get; }
    }
}