namespace MonoGame.Additions.Collisions
{
    public interface ICollidable
    {
        bool IntersectsWith(Collider other);
    }
}