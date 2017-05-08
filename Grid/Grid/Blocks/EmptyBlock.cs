using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Grid.Framework.Components;
using Grid.Framework;

namespace Grid.Grid.Blocks
{
    public class EmptyBlock : Block
    {
        public EmptyBlock(int x, int y) : base(x, y, 1, 1)
        {

        }
    }
}
