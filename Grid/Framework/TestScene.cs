using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Grid.Framework.GUIs;

namespace Grid.Framework
{
    class TestScene : Scene
    {
        Slider slider;
        protected override void LoadContent()
        {
            base.LoadContent();
            slider = new Slider(100, 100, 500, 20, 0, 10) { DrawMode = Slider.SliderBarDrawMode.Material};
            guiManagerComponent.GUIs.Add(slider);
        }
        
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Debug.DisplayLine($"Slider Value : {slider.Value}");
            
        }
    }
}
