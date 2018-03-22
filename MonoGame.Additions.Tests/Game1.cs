using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Additions.Adapters;
using MonoGame.Additions.Collisions;
using MonoGame.Additions.Collisions.Systems;
using MonoGame.Additions.Entities;
using MonoGame.Additions.Entities.Components;
using MonoGame.Additions.Primitives;
using System;

namespace MonoGame.Additions.Tests
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Camera2D camera;
        EntityComponentSystem ecs;
        Random rnd;

        FrameCounter counter;
        SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 640;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            rnd = new Random();
        }

        public Entity CreateCircle(Vector2 position, int radius = 50)
        {
            var entity = ecs.CreateEntity();

            entity.Attach<TransformComponent>()
                .Position = position;

            entity.Attach<PrimitiveComponent>()
                .Primitive = Circle.Create(radius, Color.Red);

            entity.Attach<CircleCollider>()
                .Radius = radius;

            return entity;
        }

        public Entity CreateRectangle(Vector2 position, float width, float height)
        {
            var entity = ecs.CreateEntity();

            entity.Attach<TransformComponent>()
                .Position = position;

            entity.Attach<PrimitiveComponent>()
                .Primitive = Primitives.Rectangle.Create(width, height, Color.White);

            entity.Attach<RectangleCollider>()
                .Size = new Vector2(width, height);

            return entity;
        }

        protected override void Initialize()
        {
            counter = new FrameCounter();
            camera = new Camera2D(new WindowViewportAdapter(Window, GraphicsDevice));
            Services.AddService(camera);
                        
            ecs = new EntityComponentSystem(this);
            ecs.Initialize();
            var c = new CollisionSystem();
            
            base.Initialize();
        }
        
        Entity circle;
        Entity circle2;

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Fonts/default");
            
            circle2 = CreateCircle(Vector2.Zero, 40);
            circle2.Attach<RigidbodyComponent>();

            circle = CreateCircle(new Vector2(200, 200), 40);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            ecs.Update(gameTime);

            var kbdState = Keyboard.GetState();
            var speed = 500;
            
            if (kbdState.IsKeyDown(Keys.D))
                camera.Move(new Vector2(speed, 0) * (float)gameTime.ElapsedGameTime.TotalSeconds);
            else if (kbdState.IsKeyDown(Keys.A))
                camera.Move(new Vector2(-speed, 0) * (float)gameTime.ElapsedGameTime.TotalSeconds);

            if (kbdState.IsKeyDown(Keys.W))
                camera.Move(new Vector2(0, -speed) * (float)gameTime.ElapsedGameTime.TotalSeconds);
            else if (kbdState.IsKeyDown(Keys.S))
                camera.Move(new Vector2(0, speed) * (float)gameTime.ElapsedGameTime.TotalSeconds);

            if (kbdState.IsKeyDown(Keys.Right))
                circle.GetComponent<TransformComponent>().Move(new Vector2(speed, 0) * (float)gameTime.ElapsedGameTime.TotalSeconds);
            else if (kbdState.IsKeyDown(Keys.Left))
                circle.GetComponent<TransformComponent>().Move(new Vector2(-speed, 0) * (float)gameTime.ElapsedGameTime.TotalSeconds);

            if (kbdState.IsKeyDown(Keys.Up))
                circle.GetComponent<TransformComponent>().Move(new Vector2(0, -speed) * (float)gameTime.ElapsedGameTime.TotalSeconds);
            else if (kbdState.IsKeyDown(Keys.Down))
                circle.GetComponent<TransformComponent>().Move(new Vector2(0, speed) * (float)gameTime.ElapsedGameTime.TotalSeconds);

            var circle1Collider = circle.GetComponent<CircleCollider>();
            var circle2Collider = circle2.GetComponent<CircleCollider>();
            
            circle2.GetComponent<RigidbodyComponent>()
                .EaseTo(camera.ScreenToWorld(Mouse.GetState().Position.ToVector2()));

            Window.Title = $"Collision: {circle2Collider.IntersectsWith(circle1Collider)}";

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            counter.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            ecs.Draw(gameTime);

            spriteBatch.Begin();
            spriteBatch.DrawString(font, $"FPS: {counter.AverageFramesPerSecond}", Vector2.Zero, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
