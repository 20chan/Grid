using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Grid.Framework.GUIs;
using Grid.Framework;

using System.Windows.Forms;
namespace Grid.Tests
{
    class TestScene : Scene
    {
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _spriteBatch.Begin();
            GUI.DrawEllipse(_spriteBatch,
                new Vector2(500, 500),
                new Vector2(200, 100),
                Mouse.GetState().Position.ToVector2(),
                10f,
                Color.Black,
                100);
            _spriteBatch.End();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Debug.Display("dfisdjfo");
        }
    }
}
