using Microsoft.Xna.Framework;

namespace MonoGame.Additions
{
    public interface IRectangular
    {
        Rectangle BoundingRectangle { get; }
    }
}