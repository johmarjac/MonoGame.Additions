using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Additions.Tiled;
using System;
using System.Xml;

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

            var xml = new XmlDocument();
            xml.Load(@".\..\..\..\..\Content\Levels\test.tmx");

            var tiledMapRaw = new TiledMapRaw();
            tiledMapRaw.version = xml.DocumentElement.Attributes["version"].InnerText;
            tiledMapRaw.tiledversion = xml.DocumentElement.Attributes["tiledversion"].InnerText;

            var orientation = xml.DocumentElement.Attributes["orientation"].InnerText;
            if (orientation == "orthogonal")
                tiledMapRaw.orientation = TiledMapOrientation.Orthogonal;
            // else if etc.

            var renderorder = xml.DocumentElement.Attributes["renderorder"].InnerText;
            if (renderorder == "right-down")
                tiledMapRaw.renderorder = TiledMapRenderOrder.RightDown;
            // else if etc.

            tiledMapRaw.width = int.Parse(xml.DocumentElement.Attributes["width"].InnerText);
            tiledMapRaw.height = int.Parse(xml.DocumentElement.Attributes["height"].InnerText);
            tiledMapRaw.tilewidth = int.Parse(xml.DocumentElement.Attributes["tilewidth"].InnerText);
            tiledMapRaw.tileheight = int.Parse(xml.DocumentElement.Attributes["tileheight"].InnerText);
            tiledMapRaw.infinite = xml.DocumentElement.Attributes["infinite"].InnerText == "0" ? false : true;
            tiledMapRaw.nextobjectid = int.Parse(xml.DocumentElement.Attributes["nextobjectid"].InnerText);

            var tilesets = xml.DocumentElement.GetElementsByTagName("tileset");
            tiledMapRaw.tilesets = new TiledTilesetRaw[tilesets.Count];

            for(int i = 0; i < tiledMapRaw.tilesets.Length; i++)
            {
                tiledMapRaw.tilesets[i] = new TiledTilesetRaw();
                tiledMapRaw.tilesets[i].firstgid = int.Parse(tilesets[i].Attributes["firstgid"].InnerText);
                tiledMapRaw.tilesets[i].source = tilesets[i].Attributes["source"].InnerText;
            }

            var layers = xml.DocumentElement.GetElementsByTagName("layer");
            tiledMapRaw.layers = new TiledMapLayerRaw[layers.Count];

            for(int i = 0; i < tiledMapRaw.layers.Length; i++)
            {
                tiledMapRaw.layers[i] = new TiledMapLayerRaw();
                tiledMapRaw.layers[i].name = layers[i].Attributes["name"].InnerText;
                tiledMapRaw.layers[i].width = int.Parse(layers[i].Attributes["width"].InnerText);
                tiledMapRaw.layers[i].height = int.Parse(layers[i].Attributes["height"].InnerText);

                var data = layers[i].ChildNodes.Count != 0 ? layers[i].ChildNodes[0] : null;
                tiledMapRaw.layers[i].data = new TiledMapLayerDataRaw();
                tiledMapRaw.layers[i].data.encoding = data.Attributes["encoding"].InnerText;

                var dataRaw = data.InnerText.Replace("\r\n", "").Split(',');
                tiledMapRaw.layers[i].data.data = new int[dataRaw.Length];

                for (int j = 0; j < dataRaw.Length; j++)
                    tiledMapRaw.layers[i].data.data[j] = int.Parse(dataRaw[j]);
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
