using Microsoft.Xna.Framework.Content.Pipeline;
using MonoGame.Additions.Tiled;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace MonoGame.Additions.ContentPipeline.Tiled
{
    [ContentImporter(".json", DefaultProcessor = "MonoGame.Additions - TiledMapProcessor", DisplayName = "MonoGame.Addition - TiledMapImporter")]
    public class TiledMapImporter : ContentImporter<TiledMapRaw>
    {
        public override TiledMapRaw Import(string filename, ContentImporterContext context)
        {
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None))
            using (var reader = new StreamReader(file))
            {
                var obj = JObject.Parse(reader.ReadToEnd());

                var map = new TiledMapRaw()
                {
                    Version = obj["version"].ToObject<int>(),
                    TiledVersion = obj["tiledversion"].ToObject<string>(),
                    Width = obj["width"].ToObject<int>(),
                    Height = obj["height"].ToObject<int>(),
                    TileWidth = obj["tilewidth"].ToObject<int>(),
                    TileHeight = obj["tileheight"].ToObject<int>(),
                    Type = obj["type"].ToObject<TiledType>(),
                    Orientation = obj["orientation"].ToObject<TiledMapOrientation>(),
                    RenderOrder = obj["renderorder"].ToObject<TiledMapRenderOrder>(),
                    NextObjectId = obj["nextobjectid"].ToObject<int>(),
                    Infinite = obj["infinite"].ToObject<bool>(),
                    Tilesets = obj["tilesets"].ToObject<List<TiledTilesetRaw>>()
                };

                foreach (var layerObj in obj["layers"])
                {
                    switch (layerObj["type"].ToObject<TiledType>())
                    {
                        case TiledType.TileLayer:
                            map.Layers.Add(layerObj.ToObject<TiledMapTileLayer>());
                            break;
                        case TiledType.ObjectLayer:
                            map.Layers.Add(layerObj.ToObject<TiledMapObjectLayer>());
                            break;
                        case TiledType.Tileset:
                            Debug.Assert(false, "Tilesets are not supposed to be explicitly specified in the pipeline.");
                            break;
                        default:
                            throw new NotSupportedException("Layer not (yet) supported.");
                    }
                }

                LoadTilesetMetaData(Path.GetDirectoryName(filename), map.Tilesets);

                return map;
            }
        }

        private void LoadTilesetMetaData(string contentPath, List<TiledTilesetRaw> tilesets)
        {
            foreach(var tileset in tilesets)
            {
                if (!Path.IsPathRooted(tileset.Source))
                    contentPath = Path.Combine(contentPath, tileset.Source);

                contentPath = contentPath.Replace('/', Path.DirectorySeparatorChar);

                using (var file = new FileStream(contentPath, FileMode.Open, FileAccess.Read, FileShare.None))
                using (var reader = new StreamReader(file))
                {
                    var obj = JObject.Parse(reader.ReadToEnd());

                    tileset.TilesetMetaData.Columns = obj["columns"].ToObject<int>();
                    tileset.TilesetMetaData.ImageSource = obj["image"].ToObject<string>();
                    tileset.TilesetMetaData.ImageHeight = obj["imageheight"].ToObject<int>();
                    tileset.TilesetMetaData.ImageWidth = obj["imagewidth"].ToObject<int>();
                    tileset.TilesetMetaData.Margin = obj["margin"].ToObject<int>();
                    tileset.TilesetMetaData.Name = obj["name"].ToObject<string>();
                    tileset.TilesetMetaData.Spacing = obj["spacing"].ToObject<int>();
                    tileset.TilesetMetaData.TileCount = obj["tilecount"].ToObject<int>();
                    tileset.TilesetMetaData.TileHeight = obj["tileheight"].ToObject<int>();
                    tileset.TilesetMetaData.TileWidth = obj["tilewidth"].ToObject<int>();
                    tileset.TilesetMetaData.Type = TiledType.Tileset;
                }
            }
        }
    }
}