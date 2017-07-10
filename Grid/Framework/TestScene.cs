using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Grid.Framework.GUIs;

namespace Grid.Framework
{
    class TestScene : Scene
    {
        Slider slider;
        Button button;
        protected override void LoadContent()
        {
            base.LoadContent();
            slider = new Slider(100, 250, 500, 20, 0, 10) { DrawMode = Slider.SliderBarDrawMode.Default};
            button = new Button(10, 10, 200, 60, "Change mode");
            guiManagerComponent.GUIs.Add(button);
            guiManagerComponent.GUIs.Add(slider);
        }
        
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Debug.DisplayLine($"Slider Value : {slider.Value}");

            if (button.IsMouseDown)
                slider.DrawMode = slider.DrawMode == Slider.SliderBarDrawMode.Default ? Slider.SliderBarDrawMode.Material : Slider.SliderBarDrawMode.Default;
        }
    }
}
