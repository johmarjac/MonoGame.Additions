using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace MonoGame.Additions.Tiled
{
    public sealed class TiledMapRenderer
    {
        public TiledMapRenderer(GraphicsDevice device)
        {
            batch = new SpriteBatch(device);
        }

        public void Draw(TiledMap map, ref Matrix viewMatrix)
        {
            batch.Begin(transformMatrix: viewMatrix, blendState: BlendState.AlphaBlend, samplerState: SamplerState.PointClamp, rasterizerState: RasterizerState.CullCounterClockwise);
            
            for(var l = 0; l < map.Layers.Count; l++)
            {
                var layer = map.Layers[l];

                if (layer.Type != TiledType.TileLayer)
                    continue;

                if (map.RenderOrder != TiledMapRenderOrder.RightDown)
                    throw new NotSupportedException("Not (yet) supported.");

                for(var y = 0; y < layer.Height; y++)
                {
                    for(var x = 0; x < layer.Width; x++)
                    {
                        var idx = y * layer.Width + x;
                        var tileId = layer.Data[idx];

                        // blank tile
                        if (tileId == 0)
                            continue;

                        var tilesetSrc = map.TilesetSources
                            .Where(ts => ts.FirstGID <= tileId)
                            .Last();

                        var tileset = map.Tilesets[map.TilesetSources.IndexOf(tilesetSrc)];

                        var tileIdxOnTileset = tileId - tilesetSrc.FirstGID;

                        var tileX = tileIdxOnTileset % (tileset.ImageWidth / tileset.TileWidth);
                        var tileY = tileIdxOnTileset / (tileset.ImageWidth / tileset.TileWidth);

                        batch.Draw(tileset.Image, new Vector2(x * tileset.TileWidth, y * tileset.TileHeight), new Rectangle(tileX * tileset.TileWidth, tileY * tileset.TileHeight, tileset.TileWidth, tileset.TileHeight), Color.White);
                    }
                }
            }

            batch.End();
        }

        public void Draw(TiledMap map)
        {
            var viewMatrix = Matrix.CreateTranslation(new Vector3(Vector2.Zero, 0f)) *
                 Matrix.CreateRotationZ(0f) *
                 Matrix.CreateScale(1, 1, 1);

            Draw(map, ref viewMatrix);
        }
        
        private readonly SpriteBatch batch;
    }
}