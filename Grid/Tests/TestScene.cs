using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Grid.Framework.GUIs;
using Grid.Framework;

namespace Grid.Tests
{
    class TestScene : Scene
    {
        string buf = "";
        protected override void LoadContent()
        {
            base.LoadContent();
            var form = new Form1();
            form.TextEvented += Form_TextEvented;
            form.Show();
        }

        private void Form_TextEvented(string obj)
        {
            buf = obj;
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            _spriteBatch.Begin();
            GUI.DrawString(_spriteBatch, Resources.Font, buf, Alignment.Left | Alignment.Top, new Rectangle(0, 0, 500, 300), Color.Black, 0);
            _spriteBatch.End();
        }
    }
}
