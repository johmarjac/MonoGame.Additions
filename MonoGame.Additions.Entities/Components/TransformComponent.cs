using Microsoft.Xna.Framework;

namespace MonoGame.Additions.Entities.Components
{
    public class TransformComponent : EntityComponent, ITransform2D
    {
        public TransformComponent()
        {
            Position = Vector2.Zero;
            Rotation = 0;
            Scale = 1;
        }

        public void Move(Vector2 delta)
        {
            Position += Vector2.Transform(delta, Matrix.CreateRotationZ(-Rotation));
        }

        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public float Scale { get; set; }
        
        public Matrix TransformMatrix
        {
            get
            {
                return
                    Matrix.CreateTranslation(new Vector3(Position, 0)) *
                    Matrix.CreateRotationZ(Rotation) *
                    Matrix.CreateScale(Scale, Scale, 1f);
            }
        }
    }
}