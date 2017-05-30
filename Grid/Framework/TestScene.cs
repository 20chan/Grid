using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Framework
{
    class TestScene : Scene
    {
        protected override void LoadContent()
        {
            base.LoadContent();

            GameObject gui = new GameObject("gui");
            gui.AddComponent<GUITestComponent>();
            Instantiate(gui);
        }
    }
}
