using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Additions;
using MonoGame.Additions.Adapters;
using MonoGame.Additions.Scenes;
using PlatformerGame.Scenes;

namespace PlatformerGame
{
    public class PlatformerGame : Game
    {
        GraphicsDeviceManager graphics;
        
        public PlatformerGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        
        protected override void Initialize()
        {
            Services.AddService(new Camera2D(new WindowViewportAdapter(Window, GraphicsDevice)));

            Services.AddService(new SceneFactory(this));

            Services.GetService<SceneFactory>().AddScene<InGame>();
            Services.GetService<SceneFactory>().SetScene<InGame>();
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            Services.AddService(new SpriteBatch(GraphicsDevice));
        }
        
        protected override void UnloadContent()
        {

        }
        
        protected override void Update(GameTime gameTime)
        {
            Services.GetService<SceneFactory>().Update(gameTime);
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Services.GetService<SceneFactory>().Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}