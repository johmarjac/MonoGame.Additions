using Microsoft.Xna.Framework;

namespace MonoGame.Additions.Entities.Components
{
    public class TransformComponent : EntityComponent, ITransform2D
    {
        public TransformComponent()
        {
            Position = Vector2.Zero;
            Rotation = 0;
            Size = Vector2.One;
        }

        public void Move(Vector2 delta)
        {
            Position += Vector2.Transform(delta, Matrix.CreateRotationZ(-Rotation));
        }

        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Size { get; set; }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(Position.ToPoint(), Size.ToPoint());
            }
        }

        public Matrix TransformMatrix
        {
            get
            {
                return
                    Matrix.CreateTranslation(new Vector3(Position, 0)) *
                    Matrix.CreateRotationZ(Rotation) *
                    Matrix.CreateScale(Size.X, Size.Y, 1f);
            }
        }
    }
}