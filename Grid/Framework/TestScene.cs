using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Grid.Framework.GUIs;

namespace Grid.Framework
{
    class TestScene : Scene
    {
        ActivatableButton button;
        protected override void LoadContent()
        {
            base.LoadContent();
            button = new ActivatableButton(300, 100, 200, 70, "Click me")
            {
                BackColor = Color.HotPink,
                ActivatedColor = Color.DeepPink,
                ActivatedText = "Oh you made it.."
            };
            guiManagerComponent.GUIs.Add(button);
        }
        
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Debug.DisplayLine($"Button Activated : {button.Activated}");
        }
    }
}
