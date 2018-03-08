using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonoGame.Additions.Tiled;
using System.IO;
using System.Xml.Serialization;

namespace MonoGame.Additions.Tests.Host
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TiledMapLoad()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TiledMap));

            var map = (TiledMap)serializer.Deserialize(new StreamReader(new FileStream(@"D:\Desktop\test.tmx", FileMode.Open)));
        }
    }
}