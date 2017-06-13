using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.GUIs
{
    public class Button : Clickable
    {
        private int _border = 1;
        public int Border { get => _border; set { _border = Math.Max(0, value); } }
        public Color BorderColor { get; set; } = Color.Black;
        public Color Color { get; set; } = Color.White;

        public Alignment TextAlignment { get; set; } = 0;
        public Color TextColor { get; set; } = Color.Black;
        public SpriteFont Font { get; set; }
        public float TextRotation { get; set; } = 0f;
        public string Text { get; set; }
        
        public Button(int x, int y, int width, int height, string text)
        {
            X = x; Y = y; Width = width; Height = height;
            Text = text;
            Font = GUIManager.DefaultFont;
        }
        
        public override void Draw(SpriteBatch sb)
        {
            GUI.FillRectangle(sb, new Rectangle(X - Border, Y - Border, Width + Border * 2, Height + Border * 2), BorderColor);
            GUI.FillRectangle(sb, new Rectangle(X, Y, Width, Height), Color);
            DrawString(sb, Font, Text, TextAlignment, new Rectangle((int)X, (int)Y, (int)Width, (int)Height), TextColor, TextRotation);
            base.Draw(sb);
        }
    }
}
