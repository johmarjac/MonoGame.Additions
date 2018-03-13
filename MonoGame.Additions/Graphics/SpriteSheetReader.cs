using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace MonoGame.Additions.Graphics
{
    public class SpriteSheetReader : ContentTypeReader<SpriteSheet>
    {
        protected override SpriteSheet Read(ContentReader input, SpriteSheet existingInstance)
        {
            if (existingInstance != null) return existingInstance;

            var sheet = new SpriteSheet()
            {
                ImageSource = input.ReadString(),
                Columns = input.ReadInt32(),
                Rows = input.ReadInt32(),
                SpriteWidth = input.ReadInt32(),
                SpriteHeight = input.ReadInt32()
            };

            LoadImage(input.ContentManager, sheet);

            return sheet;
        }

        private void LoadImage(ContentManager content, SpriteSheet sheet)
        {
            var path = Path.GetDirectoryName(sheet.ImageSource);
            if (!Path.IsPathRooted(path))
                path = Path.Combine(content.RootDirectory, path);

            var filename = Path.GetFileNameWithoutExtension(sheet.ImageSource);

            sheet.Image = content.Load<Texture2D>(path + "\\" + filename);
        }
    }
}