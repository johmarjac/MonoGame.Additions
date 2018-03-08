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
    }
}