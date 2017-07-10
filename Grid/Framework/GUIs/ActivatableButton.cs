using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.GUIs
{
    public class ActivatableButton : Button
    {
        private static readonly float _depthRatio = 0.025f;

        public Color ActivatedColor { get; set; }
        public string ActivatedText { get; set; }

        public bool Activated { get; set; }
        public ActivatableButton(int x, int y, int width, int height, string text, bool activated = false) : base(x, y, width, height, text)
        {
            Activated = activated;
            ActivatedColor = BackColor;
            ActivatedText = text;
        }

        public override void HandleEvent()
        {
            base.HandleEvent();

            if (IsMouseUp)
                Activated = !Activated;
        }

        public override void Draw(SpriteBatch sb)
        {
            Rectangle originalBound = Bounds;
            int originalBorder = Border;
            int dx = (int)(Width * _depthRatio), dy = (int)(Height * _depthRatio);
            if (IsMouseClicking)
            {
                X += dx;
                Y += dy;
                Width -= 2 * dx;
                Height -= 2 * dy;
            }
            else if (IsMouseHover)
            {
                X -= dx;
                Y -= dy;
                Width += 2 * dx;
                Height += 2 * dy;
            }

            Color originalColor = BackColor;
            string originalText = Text;
            if (Activated)
            {
                BackColor = ActivatedColor;
                Text = ActivatedText;
            }

            base.Draw(sb);

            Bounds = originalBound;
            Border = originalBorder;
            BackColor = originalColor;
            Text = originalText;
        }
    }
}
