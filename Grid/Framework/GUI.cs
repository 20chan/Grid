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

        private static Texture2D _dummyTexture;
        public static Texture2D DummyTexture
        {
            get
            {
                if (_dummyTexture == null)
                {
                    _dummyTexture = new Texture2D(Scene.CurrentScene.GraphicsDevice, 1, 1);
                    _dummyTexture.SetData(new[] { Color.White });
                }
                return _dummyTexture;
            }
        }

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

        public static void DrawVertices(SpriteBatch sb, Vector2 position, Vector2[] vertices, float border, Color color)
        {
            for (int i = 0; i < vertices.Length - 1; i++)
            {
                DrawLine(sb, vertices[i] + position, vertices[i + 1] + position, border, color);
            }
            DrawLine(sb, vertices.Last() + position, vertices.First() + position, border, color);
        }

        public static void DrawLine(SpriteBatch sb, Vector2 p1, Vector2 p2, float border, Color color)
        {
            float angle = (float)Math.Atan2(p2.Y - p1.Y, p2.X - p1.X);
            float length = Vector2.Distance(p1, p2);
            var scale = new Vector2(length, border);
            var _angle = angle + MathHelper.ToRadians(90);
            var _x = Math.Cos(_angle) * 1;
            var _y = Math.Sin(_angle) * 1;
            var _p1 = p1 - new Vector2((float)_x, (float)_y) * border * 0.5f;
            Debug.WriteLine($"({_angle})");
            sb.Draw(DummyTexture, _p1, null, color, angle, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        public static void DrawLine(SpriteBatch sb, Point p1, Point p2, float border, Color color)
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

        private static Vector2[] circleVertices(float radius, int sides)
        {
            // https://github.com/craftworkgames/MonoGame.Extended/blob/develop/Source/MonoGame.Extended/ShapeExtensions.cs#L271
            const double max = 2.0 * Math.PI;
            var points = new Vector2[sides];
            var step = max / sides;
            var theta = 0.0;

            for (var i = 0; i < sides; i++)
            {
                points[i] = new Vector2((float)(radius * Math.Cos(theta)), (float)(radius * Math.Sin(theta)));
                theta += step;
            }

            return points;
        }

        public static void DrawCircle(SpriteBatch sb, Point center, float radius, float border, Color color, int sides)
            => DrawCircle(sb, center.ToVector2(), radius, border, color, sides);

        public static void DrawCircle(SpriteBatch sb, Vector2 center, float radius, float border, Color color, int sides)
            => DrawVertices(sb, center, circleVertices(radius, sides), border, color);

        public static void DrawPoint(SpriteBatch sb, Vector2 point, float border, Color color)
            => sb.Draw(DummyTexture, point - new Vector2(border * 0.5f), null, color, 0f, new Vector2(), Vector2.One * border, SpriteEffects.None, 0);
    }

    [Flags]
    public enum Alignment { Center = 0, Left = 1, Right = 2, Top = 4, Bottom = 8 }
}
