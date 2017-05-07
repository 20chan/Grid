using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Grid.Framework;
using Grid.Framework.Components;

namespace Grid.Grid
{
    public class Editor : Scene
    {
        protected override void LoadContent()
        {
            base.LoadContent();

            GameObject panel = new GameObject("Panel");
            panel.AddComponent<World>().SetSize(30, 30);
            Instantiate(panel);

            MainCamera.AddComponent<MovableCamera>();
        }
    }
}
