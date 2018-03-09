using Microsoft.Xna.Framework.Content.Pipeline;
using MonoGame.Additions.Tiled;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

namespace MonoGame.Additions.ContentPipeline
{
    [ContentImporter(".json", DefaultProcessor = "PassThroughProcessor", DisplayName = "MonoGame.Addition - TiledMapImporter")]
    public class TiledMapImporter : ContentImporter<TiledMap>
    {
        public override TiledMap Import(string filename, ContentImporterContext context)
        {
            context.Logger.LogMessage(context.OutputDirectory);
            using (var reader = new StreamReader(filename))
            {
                var jsonSerializer = new JsonSerializer();
                var map = (TiledMap)jsonSerializer.Deserialize(reader, typeof(TiledMap));
                
                LoadTilesets(filename, map, context);

                return map;
            }
        }

        private string GetTilesetFilePath(string mapFilePath, TiledTilesetSource tilesetSource)
        {
            var tilesetLocation = tilesetSource.Source.Replace('/', Path.DirectorySeparatorChar);
            var tilesetFilePath = Path.Combine(Path.GetDirectoryName(mapFilePath), tilesetLocation);
            return tilesetFilePath;
        }

        private void LoadTilesets(string mapFilePath, TiledMap map, ContentImporterContext context)
        {
            Debug.Assert(map != null, "map == null");
            Debug.Assert(map.TilesetSources != null, "map.TilesetSources == null");
            
            foreach(var src in map.TilesetSources)
            {
                using (var reader = new StreamReader(GetTilesetFilePath(mapFilePath, src)))
                {
                    var jsonSerializer = new JsonSerializer();
                    var tileset = (TiledTileset)jsonSerializer.Deserialize(reader, typeof(TiledTileset));
                    map.Tilesets.Add(tileset);
                }
            }
        }
    }
}