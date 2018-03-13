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
            if (existingInstance != null) return existingInstance;

            var map = new TiledMap();
            map.Version = input.ReadInt32();
            map.TiledVersion = input.ReadString();
            map.Width = input.ReadInt32();
            map.Height = input.ReadInt32();
            map.TileWidth = input.ReadInt32();
            map.TileHeight = input.ReadInt32();
            map.Type = (TiledType)input.ReadInt32();
            map.Orientation = (TiledMapOrientation)input.ReadInt32();
            map.RenderOrder = (TiledMapRenderOrder)input.ReadInt32();
            map.NextObjectId = input.ReadInt32();
            map.Infinite = input.ReadBoolean();

            var tilesetCount = input.ReadInt32();
            for(int i = 0; i < tilesetCount; i++)
            {
                var tileset = new TiledTileset();
                tileset.Columns = input.ReadInt32();
                tileset.ImageSource = input.ReadString();
                tileset.ImageWidth = input.ReadInt32();
                tileset.ImageHeight = input.ReadInt32();
                tileset.Margin = input.ReadInt32();
                tileset.Spacing = input.ReadInt32();
                tileset.Name = input.ReadString();
                tileset.TileCount = input.ReadInt32();
                tileset.TileHeight = input.ReadInt32();
                tileset.TileWidth = input.ReadInt32();
                tileset.Type = (TiledType)input.ReadInt32();

                map.Tilesets.Add(tileset);
            }

            var layerCount = input.ReadInt32();
            for(int i = 0; i < layerCount; i++)
            {
                var type = (TiledType)input.ReadInt32();
                var name = input.ReadString();
                var opacity = input.ReadSingle();
                var visible = input.ReadBoolean();
                var x = input.ReadInt32();
                var y = input.ReadInt32();
                
                switch(type)
                {
                    case TiledType.TileLayer:
                        var tileLayer = new TiledMapTileLayer();
                        tileLayer.Type = type;
                        tileLayer.Name = name;
                        tileLayer.Opacity = opacity;
                        tileLayer.Visible = visible;
                        tileLayer.X = x;
                        tileLayer.Y = y;

                        tileLayer.Data = new int[input.ReadInt32()];
                        for (int j = 0; j < tileLayer.Data.Length; j++)
                            tileLayer.Data[j] = input.ReadInt32();

                        tileLayer.Width = input.ReadInt32();
                        tileLayer.Height = input.ReadInt32();

                        map.Layers.Add(tileLayer);
                        break;
                    case TiledType.ObjectLayer:
                        var objectLayer = new TiledMapObjectLayer();
                        objectLayer.Type = type;
                        objectLayer.Name = name;
                        objectLayer.Opacity = opacity;
                        objectLayer.Visible = visible;
                        objectLayer.X = x;
                        objectLayer.Y = y;

                        objectLayer.DrawOrder = (TiledMapObjectLayerDrawOrder)input.ReadInt32();

                        map.Layers.Add(objectLayer);
                        break;
                }
            }

            LoadTilesetImages(input.ContentManager, map);

            return map;
        }

        private void LoadTilesetImages(ContentManager content, TiledMap map)
        {
            foreach(var set in map.Tilesets)
            {
                var path = Path.GetDirectoryName(set.ImageSource);
                if (!Path.IsPathRooted(path))
                    path = Path.Combine(content.RootDirectory, path);

                var filename = Path.GetFileNameWithoutExtension(set.ImageSource);

                set.Image = content.Load<Texture2D>(path + "\\" + filename);
            }
        }
    }
}