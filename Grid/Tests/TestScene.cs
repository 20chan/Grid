using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Grid.Framework.GUIs;
using Grid.Framework;

using System.Windows.Forms;
namespace Grid.Tests
{
    class TestScene : Scene
    {
        protected override void LoadContent()
        {
            base.LoadContent();

            TextBox t = new TextBox();
            t.Location = new System.Drawing.Point(40, 40);
            t.Size = new System.Drawing.Size(300, 150);
            t.Multiline = true;

            System.Windows.Forms.Button b = new System.Windows.Forms.Button();
            b.Location = new System.Drawing.Point(380, 40);
            b.Size = new System.Drawing.Size(300, 150);
            b.Click += (s, e) => MessageBox.Show("Pressed!");
            b.Text = "Press me!";

            ListView l = new ListView();
            l.Location = new System.Drawing.Point(40, 200);
            l.View = View.List;
            l.Items.Add("Item 1");
            Control.FromHandle(Window.Handle).Controls.AddRange(new Control[] { b, t, l });
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Debug.Display("dfisdjfo");
        }
    }
}
