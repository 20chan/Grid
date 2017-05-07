using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Grid.Framework;
using Grid.Framework.Components;
using Grid.Grid.Blocks;

namespace Grid.Grid
{
    public class World : Component
    {
        public Block[,] Panel { get; private set; }
        public int Width { get; private set; } = -1;
        public int Height { get; private set; } = -1;

        public World()
        {

        }

        public void SetSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override void Start()
        {
            base.Start();

            GameObject.AddComponent<WorldRender>();
        }

        public void InitBlocks()
        {
            Panel = new Block[Width, Height];
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    Panel[i, j] = new EmptyBlock(i, j);
        }

        public override void Update()
        {
            base.Update();
        }

        class WorldRender : Renderable2D
        {
            private World _world;
            public override void Start()
            {
                Texture = new Texture2D(Scene.CurrentScene.GraphicsDevice, 1, 1);
                Texture.SetData<Color>(new Color[] { Color.Black });
                _world = GameObject.GetComponent<World>();
            }
            public override void Draw(SpriteBatch sb)
            {
                int size = 100;
                for (int i = 0; i < _world.Width; i++)
                    sb.Draw(Texture, new Rectangle(i * size, 0, 1, _world.Height * size), Color.Black);
                for (int j = 0; j < _world.Height; j++)
                    sb.Draw(Texture, new Rectangle(0, j * size, _world.Width * size, 1), Color.Black);
            }
        }
    }
}
