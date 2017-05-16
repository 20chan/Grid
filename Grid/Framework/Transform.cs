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
        public GameObject GameObject { get; set; }
        public Vector2 AbsolutePosition
        {
            get
            {
                if (GameObject.Parent == null) return Position;

                var length = Position.Length();
                var abs = new Vector2((float)Math.Sin(Math.Atan2(Position.Y, Position.X) + GameObject.Parent.AbsoluteRotation) * length,
                    -(float)Math.Cos(Math.Atan2(Position.Y, Position.X) + GameObject.Parent.AbsoluteRotation) * length);

                return GameObject.Parent.AbsolutePosition + GameObject.Parent.AbsoluteScale * abs;
            }
        }
        public Vector2 AbsoluteScale
        {
            get
            {
                if (GameObject.Parent == null) return Scale;
                else return GameObject.Parent.Scale * Scale;
            }
        }
        public float AbsoluteRotation
        {
            get
            {
                if (GameObject.Parent == null) return Rotation;
                else return GameObject.Parent.Rotation + Rotation;
            }
        }

        /// <summary>
        /// Relative Position
        /// </summary>
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public float Rotation { get; set; }

        public Transform(GameObject gameObject)
        {
            GameObject = gameObject;

            Position = new Vector2();
            Scale = new Vector2(1, 1);
            Rotation = 0;
        }
    }
}
