using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Grid.Framework;
using Grid.Framework.Components;
using Grid.Framework.GUIs;

namespace Grid.Grid
{
    public class Editor : Scene
    {
        Button btn;
        protected override void LoadContent()
        {
            base.LoadContent();

            GUIManager.DefaultFont = LoadContent<SpriteFont>("default");

            btn = new Button(10, 10, 300, 200, "yeah") {
                Border = 2,
                Color = Color.GreenYellow,
                BorderColor = Color.HotPink
            };
            CurrentScene.GuiManager.GetComponent<GUIManager>().GUIs.Add(btn);

            GameObject panel = new GameObject("Panel");
            panel.AddComponent<World>().SetSize(30, 30);
            Instantiate(panel);

            MainCamera.AddComponent<MovableCamera>();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (btn.IsMouseClicking)
            {
                // btn.X += 10;
                btn.TextRotation += 0.1f;
            }
        }
    }
}
