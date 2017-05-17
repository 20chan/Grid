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

        public static void DrawLine(SpriteBatch sb, Vector2 p1, Vector2 p2, float border, Color color)
        {
            float angle = (float)Math.Atan2((p2 - p1).Y, (p2 - p1).X);
            sb.Draw(DummyTexture, new Rectangle((int)(p1.X), (int)(p1.Y), (int)((p2 - p1).Length() + border), (int)(border)), null, color, angle, new Vector2(), SpriteEffects.None, 0);
        }

        public static void DrawLine(SpriteBatch sb, Point p1, Point p2, int border, Color color)
            => DrawLine(sb, p1.ToVector2(), p2.ToVector2(), border, color);

        public static void DrawRectangle(SpriteBatch sb, Rectangle rect, int border, Color color)
        {
            sb.Draw(DummyTexture, new Rectangle(rect.X, rect.Y, border, rect.Height + border), color);
            sb.Draw(DummyTexture, new Rectangle(rect.X, rect.Y, rect.Width + border, border), color);
            sb.Draw(DummyTexture, new Rectangle(rect.X + rect.Width, rect.Y, border, rect.Height + border), color);
            sb.Draw(DummyTexture, new Rectangle(rect.X, rect.Y + rect.Height, rect.Width + border, border), color);
        }

        public static void DrawRectangle(SpriteBatch sb, Point p1, Point p2, int border, Color color)
            => DrawRectangle(sb, RectExtended.FromPoints(p1, p2), border, color);

        public static void FillRectangle(SpriteBatch sb, Rectangle rect, Color color)
            => sb.Draw(DummyTexture, rect, color);
        public static void FillRectangle(SpriteBatch sb, Point p1, Point p2, Color color)
            => FillRectangle(sb, RectExtended.FromPoints(p1, p2), color);
    }

    [Flags]
    public enum Alignment { Center = 0, Left = 1, Right = 2, Top = 4, Bottom = 8 }
}
