using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Grid.Framework.GUIs;

namespace Grid.Framework
{
    class TestScene : Scene
    {
        MenuStrip menu;
        protected override void LoadContent()
        {
            base.LoadContent();
            GUIManager.DefaultFont = LoadContent<SpriteFont>("default");
            menu = new MenuStrip();
            menu.Items.Add(new MenuStripItem("Test 1"));
            menu.Items.Add(new MenuStripItem("Test 2"));
            menu.Items.Add(new MenuStripItem("Test 3"));
            guiManagerComponent.GUIs.Add(menu);

        }
        
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (IsRightMouseDown)
                menu.IsShown = true;
        }
    }
}
