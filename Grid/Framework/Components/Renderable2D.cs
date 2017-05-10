using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.Components
{
    [SingleComponent]
    public class Renderable2D : Renderable
    {
        public Texture2D Texture { get; set; }
        public Vector2 Origin { get; set; } = new Vector2();

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, GameObject.Position, null, Color.White, GameObject.Rotation, Origin, GameObject.Scale, SpriteEffects.None, 0);
        }
    }
}
