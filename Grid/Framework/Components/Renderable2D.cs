using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.Components
{
    [SingleComponent]
    public class Renderable2D : Component
    {
        public Texture2D Texture { get; set; }
        public Vector2 Origin { get; set; } = new Vector2();
    }
}
