using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework
{
    public class GUI
    {
        public virtual void Draw(SpriteBatch sb) { }
        public virtual void HandleEvent() { }
        
        public static Texture2D DummyTexture;

        public static void DrawString(SpriteBatch sb, SpriteFont font, string text, Alignment align, Rectangle bound, Color color, float rotation)
        {
            Vector2 size = font.MeasureString(text);
            Point pos = bound.Center;
            Vector2 origin = size * 0.5f;

            if (align.HasFlag(Alignment.Left))
                origin.X += bound.Width / 2 - size.X / 2;

            if (align.HasFlag(Alignment.Right))
                origin.X -= bound.Width / 2 - size.X / 2;

            if (align.HasFlag(Alignment.Top))
                origin.Y += bound.Height / 2 - size.Y / 2;

            if (align.HasFlag(Alignment.Bottom))
                origin.Y -= bound.Height / 2 - size.Y / 2;

            sb.DrawString(font, text, new Vector2(pos.X, pos.Y), color, rotation, origin, 1, SpriteEffects.None, 0);
        }
    }

    [Flags]
    public enum Alignment { Center = 0, Left = 1, Right = 2, Top = 4, Bottom = 8 }
}
