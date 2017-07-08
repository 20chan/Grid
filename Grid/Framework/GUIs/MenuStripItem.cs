using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.GUIs
{
    public class MenuStripItem : GUI
    {
        public static SpriteFont Font;
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                _minimalSize = MeasureFontSize(Font, _text).ToPoint();
            }
        }
        public Alignment TextAlignment { get; set; } = Alignment.Center;
        public Color ForeColor { get; set; } = Color.Black;
        public Color BackColor { get; set; } = Color.Snow;
        public Color FocusedBackColor { get; set; } = Color.SkyBlue;
        public bool Focused { get; internal set; } = false;
        private Point _minimalSize;
        public Point MinimalSize => _minimalSize;

        public MenuStripItem(string text)
        {
            Text = text;
        }
    }
}
