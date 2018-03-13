using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using MonoGame.Additions.Tiled;
using Newtonsoft.Json;
using System;

namespace MonoGame.Additions.ContentPipeline.Tiled
{
    [ContentTypeWriter]
    public class TiledMapWriter : ContentTypeWriter<TiledMap>
    {
        protected override void Write(ContentWriter output, TiledMap value)
        {
            //output.Write(JsonConvert.SerializeObject(value));

            output.Write(value.Version);
            output.Write(value.TiledVersion);
            output.Write(value.Width);
            output.Write(value.Height);
            output.Write(value.TileWidth);
            output.Write(value.TileHeight);
            output.Write((int)value.Type);
            output.Write((int)value.Orientation);
            output.Write((int)value.RenderOrder);
            output.Write(value.NextObjectId);
            output.Write(value.Infinite);

            output.Write(value.Tilesets.Count);
            foreach(var tileset in value.Tilesets)
            {
                output.Write(tileset.Columns);
                output.Write(tileset.ImageSource);
                output.Write(tileset.ImageWidth);
                output.Write(tileset.ImageHeight);
                output.Write(tileset.Margin);
                output.Write(tileset.Spacing);
                output.Write(tileset.Name);
                output.Write(tileset.TileCount);
                output.Write(tileset.TileHeight);
                output.Write(tileset.TileWidth);
                output.Write((int)tileset.Type);
            }

            output.Write(value.Layers.Count);
            foreach(var layer in value.Layers)
            {
                output.Write((int)layer.Type);
                output.Write(layer.Name);
                output.Write(layer.Opacity);
                output.Write(layer.Visible);
                output.Write(layer.X);
                output.Write(layer.Y);

                switch(layer.Type)
                {
                    case TiledType.TileLayer:
                        var tileLayer = (TiledMapTileLayer)layer;
                        output.Write(tileLayer.Data.Length);
                        foreach (var d in tileLayer.Data)
                            output.Write(d);

                        output.Write(tileLayer.Width);
                        output.Write(tileLayer.Height);
                        break;
                    case TiledType.ObjectLayer:
                        var objectLayer = (TiledMapObjectLayer)layer;
                        output.Write((int)objectLayer.DrawOrder);
                        break;
                    default:
                        throw new NotSupportedException("Not (yet) supported.");
                }
            }
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return "MonoGame.Additions.Tiled.TiledMap, MonoGame.Additions.Tiled";
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "MonoGame.Additions.Tiled.TiledMapReader, MonoGame.Additions.Tiled";
        }
    }
}