using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Grid.Framework.GUIs;

namespace Grid.Framework
{
    class TestScene : Scene
    {
        Button b;
        protected override void LoadContent()
        {
            base.LoadContent();
            GUIManager.DefaultFont = LoadContent<SpriteFont>("default");
            b = new Button(100, 100, 100, 100, "test");
            guiManagerComponent.GUIs.Add(b);

        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            if (b.IsMouseClicking)
                Debug.DisplayLine("MouseClicking");
        }
    }
}
