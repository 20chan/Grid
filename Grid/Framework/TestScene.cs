using System.Collections.Generic;
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
            var item2 = new MenuStripItem("Test 2");
            item2.SubItems.Add(new MenuStripItem("Test 2-1"));
            item2.SubItems.Add(new MenuStripItem("Test 2-2"));
            var item2_3 = new MenuStripItem("Test 2-3");
            item2_3.SubItems.Add(new MenuStripItem("Test 2-3-1"));
            item2_3.SubItems.Add(new MenuStripItem("Test 2-3-2"));
            item2_3.SubItems.Add(new MenuStripItem("Test 2-3-3"));
            item2_3.SubItems.Add(new MenuStripItem("Test 2-3-4"));
            item2_3.SubItems.Add(new MenuStripItem("Test 2-3-5"));
            item2.SubItems.Add(item2_3);
            item2.SubItems.Add(new MenuStripItem("Test 2-4"));
            menu.Items.Add(item2);
            menu.Items.Add(new MenuStripItem("Test 3"));
            guiManagerComponent.GUIs.Add(menu);

        }
        
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (IsRightMouseDown)
                menu.Show(MousePosition.X, MousePosition.Y);

            if (menu.IsSelected)
                Debug.Log($"You selected {menu.SelectedItem.Text}!");

            if (menu.IsCancled)
                Debug.Log("You cancled!");
        }
    }
}
