using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonoGame.Additions.Entities;

namespace MonoGame.Additions.Tests.Host
{
    [TestClass]
    public class ECSTests
    {
        [TestMethod]
        public void TestEntityEvents()
        {
            using (var game = new TestGame())
            {
                game.Run(Microsoft.Xna.Framework.GameRunBehavior.Asynchronous);

                var ecs = new EntityComponentSystem(game);
                
            }
        }
    }
}