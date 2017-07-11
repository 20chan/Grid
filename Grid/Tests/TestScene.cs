using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Grid.Framework.GUIs;
using Grid.Framework;

namespace Grid.Tests
{
    class TestScene : Scene
    {
        protected override void LoadContent()
        {
            base.LoadContent();

            Button btn = new Button(10, 10, 150, 80, "");
            AddGUI(btn);

            ListBoxItem item = new ListBoxItem();
            AddGUI(item);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
