using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
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

            btn = new Button(10, 10, 300, 200, "yeah");
            CurrentScene.GUIManager.GetComponent<GUIManager>().GUIs.Add(btn);

            GameObject panel = new GameObject("Panel");
            panel.AddComponent<World>().SetSize(30, 30);
            Instantiate(panel);

            MainCamera.AddComponent<MovableCamera>();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (btn.IsMouseDown)
                btn.X += 10;
        }
    }
}
