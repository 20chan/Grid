using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Grid.Framework;
using Grid.Framework.Components;
using Grid.Framework.GUIs;

namespace Grid.Grid
{
    public class Editor : Scene
    {
        Button fastBtn, slowBtn;
        Texture2D hosTexture;
        protected override void InitSize()
        {
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            hosTexture = LoadContent<Texture2D>("hos");

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
            MainCamera.AddComponent<Movable2DCamera>();
        }

        float speed = 0.05f;
        bool mouseDown = false;
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(Mouse.GetState().LeftButton == ButtonState.Pressed && !mouseDown && !IsAnyGUIUseMouse)
            {
                mouseDown = true;
                GameObject o = new GameObject("hos") { Tag = "hos" };
                o.Position = (mainCameraComponent as Camera2D).CursorPosition;
                o.AddComponent<Renderable2D>().Texture = hosTexture;
                Instantiate(o);
            }
            if (Mouse.GetState().LeftButton == ButtonState.Released) mouseDown = false;
            if (fastBtn.IsMouseClicking)
            {
                speed += 0.001f;
            }
            if (slowBtn.IsMouseClicking)
            {
                speed -= 0.001f;
            }
            foreach (var g in GameObject.FindGameObjectsByTag("hos")) g.Rotation += speed;
            Window.Title = Mouse.GetState().Position.ToString();
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
