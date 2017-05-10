using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Grid.Framework;
using Grid.Framework.Components;

namespace Grid.Grid
{
    [SingleComponent]
    public class Block : Component
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle Rect
        {
            get => new Rectangle(X, Y, Width, Height);
            set { X = value.X; Y = value.Y; Width = value.Width; Height = value.Height; }
        }

        public Block(int x = -1, int y = -1, int width = -1 , int height = -1)
        {
            X = x; Y = y; Width = width; Height = height;
        }
    }
}
