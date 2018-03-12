using Microsoft.Xna.Framework;
using MonoGame.Additions.Adapters;

namespace MonoGame.Additions
{
    public class Camera2D
    {
        public Camera2D(ViewportAdapter adapter)
        {
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
                Matrix.CreateTranslation(new Vector3(-Origin, 0)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(Origin, 0));
        }

        public void Move(Vector2 direction)
        {
            Position += Vector2.Transform(direction, Matrix.CreateRotationZ(-Rotation));
        }

        public Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }
        public float Rotation { get; set; }
        public float Zoom { get; set; } = 1f;

        public ViewportAdapter Adapter { get; }
    }
}