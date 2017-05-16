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
        BasicEffect effect;
        protected override void LoadContent()
        {
            base.LoadContent();
            effect = new BasicEffect(GraphicsDevice);
            effect.VertexColorEnabled = true;
            
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
            hos.Position = new Vector2(0, 0);
            hos.AddComponent<Renderable2D>().Texture = LoadContent<Texture2D>("hos");
            Instantiate(hos);

            for (int i = 0; i < 3; i++)
            {
                GameObject little_hos = new GameObject($"little_hos{i}", hos) { Tag = "little_hos" };
                little_hos.Position = new Vector2(100 * (float)Math.Sin(Math.PI * i / 3 * 2), - 100 * (float)Math.Cos(Math.PI * i / 3 * 2));
                little_hos.AddComponent<Renderable2D>().Texture = LoadContent<Texture2D>("hos");
                little_hos.Scale = new Vector2(0.5f, 0.5f);
                Instantiate(little_hos);
            }
            MainCamera.AddComponent<MovableCamera>();
        }
        
        float speed = 0.05f;
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            var r = GameObject.Find("hos").Rotation;
            if (fastBtn.IsMouseClicking)
            {
                speed += 0.001f;
            }
            if (slowBtn.IsMouseClicking)
            {
                speed -= 0.001f;
            }
            GameObject.Find("hos").Rotation += speed;
            foreach(var g in GameObject.FindGameObjectsByTag("little_hos")) g.Rotation += 0.1f;

            if (Keyboard.GetState().IsKeyDown(Keys.I))
                GameObject.Find("hos").Scale *= 1.1f;
            if (Keyboard.GetState().IsKeyDown(Keys.O))
                GameObject.Find("hos").Scale *= 0.9f;
            Window.Title = Mouse.GetState().Position.ToString();
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            effect.CurrentTechnique.Passes[0].Apply();
            GUI.DrawLine(GraphicsDevice, new Vector2(0, 0), new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y), 0.1f, Color.White);
        }
    }
}
