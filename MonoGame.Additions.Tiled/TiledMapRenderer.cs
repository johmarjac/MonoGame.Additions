using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace MonoGame.Additions.Tiled
{
    public class TiledMapRenderer
    {
        public TiledMapRenderer(GraphicsDevice device)
        {
            SpriteBatch = new SpriteBatch(device);
        }

        public virtual void Draw(TiledMap map, ref Matrix transformMatrix)
        {
            SpriteBatch.Begin(transformMatrix: transformMatrix);

            if (map.RenderOrder != TiledMapRenderOrder.RightDown)
                throw new NotSupportedException("Not (yet) supported.");

            foreach(var tileLayer in map.Layers.OfType<TiledMapTileLayer>())
            {
                for(int y = 0; y < tileLayer.Height; y++)
                {
                    for(int x = 0; x < tileLayer.Width; x++)
                    {
                        var gid = tileLayer.Data[y * tileLayer.Width + x];

                        // blank tile
                        if (gid == 0)
                            continue;

                        var tileset = map.Tilesets
                            .Where(t => gid >= t.FirstGID)
                            .LastOrDefault();

                        if (tileset == null)
                            continue;

                        var tileIdxOnTileset = gid - tileset.FirstGID - 1;
                        var tilesetX = tileIdxOnTileset % tileset.Columns;
                        var tilesetY = tileIdxOnTileset / tileset.Columns;

                        SpriteBatch.Draw(tileset.Image, 
                            new Rectangle(x * tileset.TileWidth, y * tileset.TileHeight, tileset.TileWidth, tileset.TileHeight),
                            new Rectangle(tilesetX * tileset.TileWidth, tilesetY * tileset.TileHeight, tileset.TileWidth, tileset.TileHeight), 
                            Color.White);
                    }
                }
            }

            SpriteBatch.End();
        }

        public void Draw(TiledMap map)
        {
            Draw(map, ref DefaultMatrix);
        }

        private Matrix DefaultMatrix = 
            Matrix.CreateTranslation(new Vector3(Vector2.Zero, 0)) *
            Matrix.CreateRotationZ(0) *
            Matrix.CreateScale(1f, 1f, 1f);

        protected readonly SpriteBatch SpriteBatch;
    }
}