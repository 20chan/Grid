using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.GUIs
{
    public class ImageButton : Button
    {
        public Texture2D Image { get; set; }

        public ImageButton(int x, int y, Texture2D texture) : this(x, y, texture.Width, texture.Height, texture)
        { }

        public ImageButton(int x, int y, int width, int height, Texture2D texture) : base(x, y, width, height, string.Empty)
        {
            Image = texture;
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            sb.Draw(Image, Bounds, Color.White);
        }
    }
}
