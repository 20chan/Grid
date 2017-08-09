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
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        public class CannotDrawIndependently : Attribute { }

        public int X { get; set; } = -1;
        public int Y { get; set; } = -1;
        public int Width { get; set; } = -1;
        public int Height { get; set; } = -1;

        private bool _canDrawIndependently = true;

        public GUI()
        {
            _canDrawIndependently = GetType().GetCustomAttributes(true).Any(o => o is CannotDrawIndependently);
        }

        public Rectangle Bounds
        {
            get => new Rectangle(X, Y, Width, Height);
            set { X = value.X; Y = value.Y; Width = value.Width; Height = value.Height; }
        }

        public virtual void Draw(SpriteBatch sb)
        {
            if (_canDrawIndependently) throw new NotSupportedException("This GUI cannot be draw independently.");
        }

        public virtual void HandleEvent() { }

        #region Static Functions
        public static Texture2D DummyTexture => Resources.Dummy;

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
            //Debug.WriteLine($"({_angle})");
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

        private static Vector2[] ellipseVertices(float semimajor, float semiminor, float angle, int sides)
        {
            const double max = 2.0 * Math.PI;
            var points = new Vector2[sides];
            var step = max / sides;
            var theta = 0.0;

            for (var i = 0; i < sides; i++)
            {
                Vector2 temp = new Vector2((float)(semimajor * Math.Cos(theta)), (float)(semiminor * Math.Sin(theta)));
                points[i] = new Vector2(temp.X * (float)Math.Cos(angle) - temp.Y * (float)Math.Sin(angle), temp.X * (float)Math.Sin(angle) + temp.Y * (float)Math.Cos(angle));
                theta += step;
            }

            return points;
        }

        public static void DrawCircle(SpriteBatch sb, Point center, float radius, float border, Color color, int sides)
            => DrawCircle(sb, center.ToVector2(), radius, border, color, sides);

        public static void DrawCircle(SpriteBatch sb, Vector2 center, float radius, float border, Color color, int sides)
            => DrawVertices(sb, center, circleVertices(radius, sides), border, color);

        public static void DrawEllipse(SpriteBatch sb, Point focus1, Point focus2, float semimajor, float semiminor, float border, Color color, int sides)
        {
            Vector2 diff = (focus1.ToVector2() - focus2.ToVector2());
            DrawVertices(sb, (focus1.ToVector2() + focus2.ToVector2()) / 2, ellipseVertices(semimajor, semiminor, (float)Math.Atan2(diff.Y, diff.X), sides), border, color);
        }

        public static void DrawEllipse(SpriteBatch sb, Vector2 focus1, Vector2 focus2, float semimajor, float semiminor, float border, Color color, int sides)
        {
            Vector2 diff = (focus1 - focus2);
            DrawVertices(sb, (focus1 + focus2) / 2, ellipseVertices(semimajor, semiminor, (float)Math.Atan2(diff.Y, diff.X), sides), border, color);
        }

        public static void DrawPoint(SpriteBatch sb, Vector2 point, float border, Color color)
            => sb.Draw(DummyTexture, point - new Vector2(border * 0.5f), null, color, 0f, new Vector2(), Vector2.One * border, SpriteEffects.None, 0);

        public static Vector2 MeasureFontSize(SpriteFont font, string text)
        {
            return font.MeasureString(text);
        }
#endregion
    }

    [Flags]
    public enum Alignment { Center = 0, Left = 1, Right = 2, Top = 4, Bottom = 8 }
}
