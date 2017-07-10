using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework
{
    [SingleComponent]
    public class GUIManager : Component
    {
        public List<GUI> GUIs { get; private set; }
        public GUIManager()
        {
            GUIs = new List<GUI>();
        }

        public void Draw(SpriteBatch sb)
        {
            GUIs.ForEach(g => g.Draw(sb));
        }

        public void HandleEvent()
        {
            GUIs.ForEach(g => g.HandleEvent());
        }
    }
}
