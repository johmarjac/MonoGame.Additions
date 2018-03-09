using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.IO;

namespace MonoGame.Additions.Tiled
{
    public class TiledMapReader : ContentTypeReader<TiledMap>
    {
        protected override TiledMap Read(ContentReader input, TiledMap existingInstance)
        {
            var map = JsonConvert.DeserializeObject<TiledMap>(input.ReadString());
            LoadTilesetImages(input, map);
            return map;
        }

        private void LoadTilesetImages(ContentReader input, TiledMap map)
        {
            foreach(var tileset in map.Tilesets)
            {                
                tileset.Image = input.ContentManager.Load<Texture2D>(GetTilesetImagePath(input, tileset));
            }
        }

        private string GetTilesetImagePath(ContentReader input, TiledTileset tileset)
        {
            var imageFileWithoutExtension = Path.GetFileNameWithoutExtension(tileset.ImageSource);
            var imageDirectory = Path.GetDirectoryName(tileset.ImageSource.Replace('/', Path.DirectorySeparatorChar));
            if (!Path.IsPathRooted(imageDirectory))
                imageDirectory = Path.Combine(input.ContentManager.RootDirectory, imageDirectory);

            return Path.Combine(imageDirectory, imageFileWithoutExtension);
        }
    }
}