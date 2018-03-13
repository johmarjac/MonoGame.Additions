using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Additions.Adapters;
using MonoGame.Additions.Animations;
using MonoGame.Additions.Tiled;

namespace MonoGame.Additions.Tests
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Camera2D camera;
        TiledMap map;
        TiledMapRenderer mapRenderer;

         SpriteSheetAnimations alienGreenAnimations;
         SpriteSheetAnimationsRenderer animationRenderer;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 640;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        
        protected override void Initialize()
        {
            camera = new Camera2D(new WindowViewportAdapter(Window, GraphicsDevice));
            mapRenderer = new TiledMapRenderer(GraphicsDevice);
            animationRenderer = new SpriteSheetAnimationsRenderer(GraphicsDevice);

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            map = Content.Load<TiledMap>("Levels/test");
            alienGreenAnimations = Content.Load<SpriteSheetAnimations>("SpriteSheetAnimations/alienGreen");
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.D))
            {
                //WASD = new Vector2(1f, WASD.Y);
                alienGreenAnimations.Play("player_movement");
                alienGreenAnimations.SpriteEffects = SpriteEffects.None;
            }
            else if (state.IsKeyDown(Keys.A))
            {
                alienGreenAnimations.Play("player_movement");
                alienGreenAnimations.SpriteEffects = SpriteEffects.FlipHorizontally;
                //WASD = new Vector2(-1f, WASD.Y);
            }
            else
                alienGreenAnimations.Play("player_stand");
            
            animationRenderer.Update(alienGreenAnimations, gameTime);
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var transformMatrix = camera.GetViewMatrix();

            mapRenderer.Draw(map, ref transformMatrix);
            animationRenderer.Draw(alienGreenAnimations, ref transformMatrix);

            base.Draw(gameTime);
        }
    }
}
