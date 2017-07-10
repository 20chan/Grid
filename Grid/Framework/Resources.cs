using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework
{
    public static class Resources
    {
        public static Texture2D Dummy;
        public static SpriteFont Font;

        public static void LoadAll()
        {
            Dummy = new Texture2D(Scene.CurrentScene.GraphicsDevice, 1, 1);
            Dummy.SetData(new[] { Color.White });

            Font = LoadContent<SpriteFont>("defaultFont");
        }

        private static T LoadContent<T>(string name)
            => Scene.LoadContent<T>($"Grid/{name}");
    }
}
