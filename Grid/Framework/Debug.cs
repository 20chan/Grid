using System.Text;
using Grid.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Grid.Framework
{
    public class Debug : Renderable
    {
        private SpriteFont _font;
        public SpriteFont Font { get => _font ?? GUIManager.DefaultFont; set => _font = value; }
        public Color Color { get; set; } = Color.White;
        private StringBuilder _buffer;
        private string _out;

        public static void Write(object o)
        {
            Scene.CurrentScene.Debugger._buffer.Append(o);
        }

        public static void WriteLine(string s)
        {
            Scene.CurrentScene.Debugger._buffer.AppendLine(s);
        }

        public Debug()
        {
            _buffer = new StringBuilder();
            OnCamera = false;
        }

        public override void Update()
        { 
            base.Update();
            _out = _buffer.ToString();
            _buffer.Clear();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            sb.Begin();
            GUI.DrawString(sb, Font, _out, Alignment.Right | Alignment.Top, (Camera.Current as Camera2D).Bounds, Color, 0);
            sb.End();
        }
    }
}
