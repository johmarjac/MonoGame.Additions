using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Additions.Scenes;

namespace PlatformerGame
{
    public class PlatformerGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SceneFactory SceneFactory => Services.GetService<SceneFactory>();
        
        public PlatformerGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            Services.AddService(new SceneFactory(this));
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
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