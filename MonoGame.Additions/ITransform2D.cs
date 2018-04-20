using Microsoft.Xna.Framework;

namespace MonoGame.Additions
{
    public interface ITransform2D
    {
        Vector2 Position { get; }
        float Rotation { get; }
        float Scale { get; }
    }
}