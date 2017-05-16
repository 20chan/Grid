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
        public Vector2 AbsolutePosition { get; set; } = new Vector2(0, 0);
        public Vector2 AbsoluteScale { get; set; } = new Vector2(1, 1);
        public float AbsoluteRotation { get; set; }

        /// <summary>
        /// Relative Position
        /// </summary>
        public Vector2 Position
        {
            get => GameObject.Parent == null ? AbsolutePosition : GameObject.Parent.Position - AbsolutePosition;
            set => AbsolutePosition = GameObject.Parent == null ? value : GameObject.Parent.Position + value;
        }
        public Vector2 Scale
        {
            get => GameObject.Parent == null ? AbsoluteScale : AbsoluteScale * GameObject.Parent.Scale;
            set => AbsoluteScale = GameObject.Parent == null ? value : value / GameObject.Parent.Scale;
        }
        public float Rotation
        {
            get => GameObject.Parent == null ? AbsoluteRotation : GameObject.Parent.Rotation - AbsoluteRotation;
            set => AbsoluteRotation = GameObject.Parent == null ? value : GameObject.Parent.Rotation + value;
        }

        public Transform(GameObject gameObject)
        {
            GameObject = gameObject;

            AbsolutePosition = new Vector2();
            AbsoluteScale = new Vector2();
            AbsoluteRotation = 0;
        }
    }
}
