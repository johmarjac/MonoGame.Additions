namespace MonoGame.Additions.Tests.Collision
{
    public interface IShapeIntersectable
    {
        bool IntersectingWith(CircleShape other);
    }
}