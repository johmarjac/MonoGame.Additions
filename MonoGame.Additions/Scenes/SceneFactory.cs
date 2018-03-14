using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoGame.Additions.Scenes
{
    public class SceneFactory
    {
        public SceneFactory(Game game)
        {
            Game = game;
            scenes = new List<Scene>();
        }

        public void AddScene<TScene>() where TScene : Scene, new()
        {
            var scene = new TScene()
            {
                Game = Game
            };

            scenes.Add(scene);
        }

        public TScene FindScene<TScene>() where TScene : Scene
        {
            return
                scenes.OfType<TScene>()
                .FirstOrDefault();
        }

        public IEnumerable<TScene> FindScenes<TScene>(Func<TScene, bool> predicate) where TScene : Scene
        {
            return
                scenes.OfType<TScene>()
                .Where(predicate);
        }

        public TScene FindScene<TScene>(Func<TScene, bool> predicate) where TScene : Scene
        {
            return
                scenes.OfType<TScene>()
                .FirstOrDefault(predicate);
        }

        public void SetScene<TScene>() where TScene : Scene
        {
            var scene = FindScene<TScene>();

            if (scene != null)
            {
                CurrentScene?.Dispose();

                CurrentScene = scene;
                CurrentScene.Initialize();
                CurrentScene.LoadContent();
            }
        }

        public void SetScene<TScene>(Func<TScene, bool> predicate) where TScene : Scene
        {
            var scene = FindScene(predicate);

            if (scene != null)
            {
                CurrentScene = scene;
                CurrentScene.Initialize();
                CurrentScene.LoadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            CurrentScene?.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            CurrentScene?.Draw(gameTime);
        }

        public Scene CurrentScene { get; protected set; }

        public IEnumerable<Scene> Scenes => scenes;
        private readonly List<Scene> scenes;

        protected Game Game { get; }
    }
}