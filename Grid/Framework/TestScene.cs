using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework
{
    class TestScene : Scene
    {
        protected override void LoadContent()
        {
            base.LoadContent();
            GUIManager.DefaultFont = LoadContent<SpriteFont>("default");
            GameObject gui = new GameObject("gui");
            gui.AddComponent<GUITestComponent>();
            Instantiate(gui);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Debug.WriteLine($"{ScreenBound}");
        }
    }
}
