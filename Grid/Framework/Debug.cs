using System.Text;
using Grid.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace Grid.Framework
{
    public class Debug : Renderable
    {
        private SpriteFont _font;
        public SpriteFont Font { get => _font ?? Resources.Font; set => _font = value; }
        public Color Color { get; set; } = Color.White;
        private StringBuilder _deepBuffer;
        private StringBuilder _buffer;
        private string _out;

        public static void Display(object o)
        {
            Scene.CurrentScene.Debugger._buffer.Append(o);
        }

        public static void DisplayLine(string s)
        {
            Scene.CurrentScene.Debugger._buffer.AppendLine(s);
        }

        public static void Log(string s)
        {
            Scene.CurrentScene.Debugger._deepBuffer.AppendLine(s);
        }

        public static void ClearLog()
        {
            Scene.CurrentScene.Debugger._deepBuffer.Clear();
        }

        public Debug()
        {
            _buffer = new StringBuilder();
            _deepBuffer = new StringBuilder();
            OnCamera = false;
        }

        public override void Update()
        { 
            base.Update();
            _out = _deepBuffer.ToString() + _buffer.ToString();
            _buffer.Clear();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            sb.Begin();
            GUI.DrawString(sb, Font, _out, Alignment.Right | Alignment.Top, (Camera.Current as Camera2D).Bounds, Color, 0);
            GUI.DrawPoint(sb, new Vector2(0,0), 10, Color.Coral );
            GUI.DrawPoint(sb, new Vector2(250,400), 10, Color.Coral);
            GUI.DrawPoint(sb, new Vector2(300, 300), 10, Color.Coral);
            GUI.DrawEllipse(sb, new Vector2(0,0), new Vector2(250, 400), new Vector2(300,300), 1, Color.Coral, 100);
            
            //GUI.DrawArc(sb, new Vector2(350,350), 100, 0 , (float)(2 * Math.PI), 2 , Color.Chocolate, 100);
            sb.End();
        }
    }
}
