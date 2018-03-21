using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Additions.Adapters;
using MonoGame.Additions.Animations;
using MonoGame.Additions.Entities.Components;
using MonoGame.Additions.Primitives;
using MonoGame.Additions.Tiled;
using System.Linq;

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
        SpriteSheetAnimations explosion;
        SpriteSheetAnimationsRenderer animationRenderer;

        TransformComponent transform;

        Circle filledCircle;

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
            transform = new TransformComponent();

            filledCircle = PrimitiveFactory.CreateCircle(200, Color.Black);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            map = Content.Load<TiledMap>("Levels/test");
            alienGreenAnimations = Content.Load<SpriteSheetAnimations>("SpriteSheetAnimations/alienGreen");
            explosion = Content.Load<SpriteSheetAnimations>("SpriteSheetAnimations/explosion");
            
            for (int i = 0; i < 74; i++)
            {
                explosion.Animations[0].Frames.Add(new SpriteSheetAnimationFrame()
                {
                    Duration = 50,
                    Index = i
                });
            }
            explosion.Play("explosion");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        Vector2 target;
        Vector2 velocity;

        protected override void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            target = mouseState.Position.ToVector2();

            float ease = 0.1f;
            velocity = new Vector2((target.X - transform.Position.X) * ease, (target.Y - transform.Position.Y) * ease);

            transform.Position += velocity;

            if (velocity.X < 0)
                alienGreenAnimations.SpriteEffects = SpriteEffects.FlipHorizontally;
            else
                alienGreenAnimations.SpriteEffects = SpriteEffects.None;

            if (velocity.Length() > 1f)
                alienGreenAnimations.Play("player_movement");
            else
                alienGreenAnimations.Play("player_stand");

            animationRenderer.Update(explosion, gameTime);
            animationRenderer.Update(alienGreenAnimations, gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            var transformMatrix = camera.GetViewMatrix();

            var alienTransform = transform.TransformMatrix;



            mapRenderer.Draw(map, ref transformMatrix);
            animationRenderer.Draw(explosion, ref transformMatrix);
            //animationRenderer.Draw(alienGreenAnimations, ref alienTransform);
            spriteBatch.DrawCircle(filledCircle, ref alienTransform);

            base.Draw(gameTime);
        }
    }
}
