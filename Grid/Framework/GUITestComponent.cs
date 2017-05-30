using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Grid.Framework;
using Grid.Framework.Components;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework
{
    class GUITestComponent : Renderable
    {
        public override void Start()
        {
            base.Start();
            OnCamera = false;
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Begin();
            //GUI.DrawLine(sb, new Point(600, 300), Mouse.GetState().Position, 50, Color.Blue);
            GUI.DrawPoint(sb, Mouse.GetState().Position.ToVector2(), 50, Color.Black);
            sb.End();
            base.Draw(sb);
        }
    }
}
