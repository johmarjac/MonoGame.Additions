using Microsoft.Xna.Framework;

namespace MonoGame.Additions
{
    public interface ITransform2D : IRectangular
    {
        Vector2 Position { get; }
        Vector2 Size { get; }
        Vector2 Origin { get; }
        float Scale { get; }
        float Rotation { get; }
    }
}