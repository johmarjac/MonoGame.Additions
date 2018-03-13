using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Additions.Adapters;
using MonoGame.Additions.Animations;
using MonoGame.Additions.Graphics;
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

         SpriteSheetAnimation animation;
         SpriteSheetAnimationRenderer animationRenderer;
        
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
            animationRenderer = new SpriteSheetAnimationRenderer(GraphicsDevice);

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            map = Content.Load<TiledMap>("Levels/test");
            animation = Content.Load<SpriteSheetAnimation>("SpriteSheetAnimations/alienGreen_movement");
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            var WASD = default(Vector2);

            if (state.IsKeyDown(Keys.W))
                WASD = new Vector2(WASD.X, -1f);

            

            if (state.IsKeyDown(Keys.S))
                WASD = new Vector2(WASD.X, 1f);

            if (state.IsKeyDown(Keys.D))
            {
                //WASD = new Vector2(1f, WASD.Y);
                animation.SpriteEffects = SpriteEffects.None;
                animation.Play();
            }
            else if (state.IsKeyDown(Keys.A))
            {
                //WASD = new Vector2(-1f, WASD.Y);
                animation.SpriteEffects = SpriteEffects.FlipHorizontally;
                animation.Play();
            }
            else
                animation.Pause();

            camera.Move(WASD * gameTime.ElapsedGameTime.Milliseconds);

            animationRenderer.Update(animation, gameTime);
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var transformMatrix = camera.GetViewMatrix();

            mapRenderer.Draw(map, ref transformMatrix);
            animationRenderer.Draw(animation, ref transformMatrix);

            base.Draw(gameTime);
        }
    }
}
