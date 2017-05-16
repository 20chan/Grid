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
        Button fastBtn, slowBtn;
        protected override void LoadContent()
        {
            base.LoadContent();

            GUIManager.DefaultFont = LoadContent<SpriteFont>("default");

            fastBtn = new Button(10, 10, 100, 100, "FASTER")
            {
                Border = 2,
            };
            slowBtn = new Button(120, 10, 100, 100, "SLOWER")
            {
                Border = 2
            };
            CurrentScene.GuiManager.GetComponent<GUIManager>().GUIs.Add(fastBtn);
            CurrentScene.GuiManager.GetComponent<GUIManager>().GUIs.Add(slowBtn);

            /*GameObject panel = new GameObject("Panel");
            panel.AddComponent<World>().SetSize(30, 30);
            Instantiate(panel);*/

            GameObject hos = new GameObject("hos");
            hos.Position = new Vector2(10, 10);
            hos.AddComponent<Renderable2D>().Texture = LoadContent<Texture2D>("hos");
            Instantiate(hos);

            MainCamera.AddComponent<MovableCamera>();
        }

        float speed = 0.05f;
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (fastBtn.IsMouseDown)
                speed += 0.05f;
            if (slowBtn.IsMouseDown)
                speed -= 0.05f;
            GameObject.Find("hos").Rotation += speed;
        }
    }
}
