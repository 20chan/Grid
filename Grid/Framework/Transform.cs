using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Grid.Framework
{
    public class Transform
    {
        public Vector2 Position { get; set; } = new Vector2();
        public Vector2 Scale { get; set; } = new Vector2(1, 1);
        public float Rotation { get; set; } = 0;
    }
}
