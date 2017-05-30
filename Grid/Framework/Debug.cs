using System.Text;
using Grid.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Grid.Framework
{
    public class Debug : Renderable
    {
        private StringBuilder _buffer;
        private string _out;

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
            GUI.DrawString(sb, GUIManager.DefaultFont, _out, Alignment.Right | Alignment.Top, (Camera.Current as Camera2D).Bounds, Color.White, 0);
            sb.End();
        }
    }
}
