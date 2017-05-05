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
            base.LoadContent();

            GameObject obj = new GameObject("square");
            var render = obj.AddComponent<Renderable2D>();
            render.Texture = Content.Load<Texture2D>("square");
            obj.Scale = new Vector2(0.1f, 0.1f);
            obj.AddComponent<Movable>();
            Instantiate(obj);

            MainCamera.AddComponent<MovableCamera>();
        }
    }

    class Movable : Component
    {
        public float Speed = 5f;
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

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                Destroy(GameObject);
            base.Update();
        }
    }

    class MovableCamera : Component
    {
        public float Speed = 1f;
        public override void LateUpdate()
        {
            var cam = GameObject.GetComponent<Camera>();
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                cam.Position += new Vector2(0, -1) * Speed;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                cam.Position += new Vector2(0, 1) * Speed;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                cam.Position += new Vector2(-1, 0) * Speed;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                cam.Position += new Vector2(1, 0) * Speed;
            if (Keyboard.GetState().IsKeyDown(Keys.OemPlus))
                cam.Zoom *= 0.9f;
            if (Keyboard.GetState().IsKeyDown(Keys.OemMinus))
                cam.Zoom *= 1.1f;
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                cam.Rotation -= 0.1f;
            if (Keyboard.GetState().IsKeyDown(Keys.E))
                cam.Rotation += 0.1f;
            base.Update();
        }
    }
}
