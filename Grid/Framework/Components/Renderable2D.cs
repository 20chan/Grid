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
        private Texture2D _texture;
        public Texture2D Texture
        {
            get => _texture;
            set { _texture = value; Origin = new Vector2(value.Width / 2, value.Height / 2); }
        }
        public Vector2 Origin { get; set; }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, gameObject.AbsolutePosition, null, Color.White, gameObject.AbsoluteRotation, Origin, gameObject.AbsoluteScale, SpriteEffects.None, 0);
        }
    }
}
