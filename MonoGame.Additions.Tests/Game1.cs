using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Additions.ContentPipeline.Tiled;
using MonoGame.Additions.Tiled;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace MonoGame.Additions.Tests
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            var obj = JObject.Parse(File.ReadAllText(@".\..\..\..\..\Content\Levels\test.json"));

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

            foreach(var layerObj in obj["layers"])
            {
                switch(layerObj["type"].ToObject<TiledType>())
                {
                    case TiledType.TileLayer:
                        map.Layers.Add(layerObj.ToObject<TiledMapTileLayer>());
                        break;
                    case TiledType.ObjectLayer:
                        map.Layers.Add(layerObj.ToObject<TiledMapObjectLayer>());
                        break;
                    default:
                        throw new NotSupportedException("Layer not (yet) supported.");
                }
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
