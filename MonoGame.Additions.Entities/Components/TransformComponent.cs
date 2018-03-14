using Microsoft.Xna.Framework;

namespace MonoGame.Additions.Entities.Components
{
    public class TransformComponent : EntityComponent, ITransform2D
    {
        public TransformComponent()
        {
            Scale = 1f;
        }

        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public Vector2 Origin { get; set; }
        public float Scale { get; set; }
        public float Rotation { get; set; }
        public Rectangle BoundingRectangle
        {
            get
            {
                return new Rectangle(Position.ToPoint(), (Size * Scale).ToPoint());
            }
        }
        public Matrix TransformMatrix
        {
            get
            {
                return
                    Matrix.CreateTranslation(new Vector3(Position, 0)) *
                    Matrix.CreateTranslation(new Vector3(-Origin, 0)) *
                    Matrix.CreateRotationZ(Rotation) *
                    Matrix.CreateScale(Scale, Scale, Scale) *
                    Matrix.CreateTranslation(new Vector3(Origin, 0));
            }
        }
    }
}