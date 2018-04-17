using MonoGame.Additions.Entities;

namespace MonoGame.Additions.Tiled.Components
{
    public class TiledMapComponent : EntityComponent
    {
        public TiledMap Map { get; set; }
    }
}