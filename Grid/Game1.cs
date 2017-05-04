using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Grid.Framework;
using Grid.Framework.Components;

namespace Grid
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Scene
    {
        public Game1()
        {
            Content.RootDirectory = "Content";
        }
        
        protected override void LoadContent()
        {
            GameObject obj = new GameObject("square");
            var render = obj.AddComponent<Renderable2D>();
            render.Texture = Content.Load<Texture2D>("square");
            obj.Scale = new Vector2(0.1f, 0.1f);
            obj.AddComponent<Movable>();
            Instantiate(obj);

            base.LoadContent();
        }
    }

    class Movable : Component
    {
        public float Speed = 1f;
        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                GameObject.Transform.Position += new Vector2(0, -1) * Speed;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                GameObject.Transform.Position += new Vector2(0, 1) * Speed;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                GameObject.Transform.Position += new Vector2(-1, 0) * Speed;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                GameObject.Transform.Position += new Vector2(1, 0) * Speed;
            base.Update();
        }
    }
}
