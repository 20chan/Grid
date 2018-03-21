using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Grid.Framework;
using Grid.Framework.Components;

namespace Grid
{
    internal class Game1 : Scene
    {
        public Game1()
        {
            // Resolution of new surface is too high ;(
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight= 1080;
            _graphics.ApplyChanges();
        }
        
        protected override void LoadContent()
        {
            base.LoadContent();

            GameObject obj = new GameObject("nam");
            var render = obj.AddComponent<SpriteAnimator>();
            render.Textures = new[] {
                Content.Load<Texture2D>("anim/ideal"),
                Content.Load<Texture2D>("anim/left-1"),
                Content.Load<Texture2D>("anim/left-2"),
                Content.Load<Texture2D>("anim/right-1"),
                Content.Load<Texture2D>("anim/right-2"),
                Content.Load<Texture2D>("anim/down-1"),
                Content.Load<Texture2D>("anim/down-2"),
                Content.Load<Texture2D>("anim/up-1"),
                Content.Load<Texture2D>("anim/up-2"),
            };
            obj.AddComponent<Movable>();
            Instantiate(obj);

            MainCamera.AddComponent<Movable2DCamera>();
        }
    }

    class Movable : Component
    {
        public float Speed = 5f;
        public Animation Ideal, Left, Right, Up, Down;

        public override void Start()
        {
            var animator = gameObject.GetComponent<SpriteAnimator>();
            Ideal = new Animation(animator, new[] { 0 });
            Left = new Animation(animator, new[] { 1, 2 });
            Right = new Animation(animator, new[] { 3, 4 });
            Down = new Animation(animator, new[] { 5, 6 });
            Up = new Animation(animator, new[] { 7, 8 });
            Ideal.Start();
            base.Start();
        }
        
        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                gameObject.Transform.Position += new Vector2(0, -1) * Speed;
                if (!Up.IsEnabled)
                    Up.Start();
            }
            else if (Up.IsEnabled)
                Ideal.Start();
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                gameObject.Transform.Position += new Vector2(0, 1) * Speed;
                if (!Down.IsEnabled)
                    Down.Start();
            }
            else if (Down.IsEnabled)
                Ideal.Start();
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                gameObject.Transform.Position += new Vector2(-1, 0) * Speed;
                if (!Left.IsEnabled)
                    Left.Start();
            }
            else if (Left.IsEnabled)
                Ideal.Start();
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                gameObject.Transform.Position += new Vector2(1, 0) * Speed;
                if (!Right.IsEnabled)
                    Right.Start();
            }
            else if (Right.IsEnabled)
                Ideal.Start();

            //if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            //    Destroy(gameObject);
            base.Update();
        }
    }
}
