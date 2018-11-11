using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using static Grid.Helper.StaticResources;

namespace Grid.Helper
{
    public static class SpriteBatchExtension
    {
        public static void DrawLine(this SpriteBatch sb, Vector2 p1, Vector2 p2, float border, Color color)
        {
            float angle = (float)Math.Atan2(p2.Y - p1.Y, p2.X - p1.X);
            float length = Vector2.Distance(p1, p2);
            var scale = new Vector2(length, border);
            var _angle = angle + MathHelper.ToRadians(90);
            var _x = Math.Cos(_angle) * 1;
            var _y = Math.Sin(_angle) * 1;
            var _p1 = p1 - new Vector2((float)_x, (float)_y) * border * 0.5f;
            sb.Draw(Dummy, _p1, null, color, angle, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
    }
}
