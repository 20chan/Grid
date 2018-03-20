using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.Components
{
    public class Animation
    {
        public SpriteAnimator Animator { get; }

        public int FrameCount => Indices.Length;
        public int Interval = 1;
        public bool IsEnabled { get; internal set; } = false;
        public bool IsStopped { get; set; }
        public bool IsRepeatable { get; set; }

        public int[] Indices;

        public Animation(SpriteAnimator animator, int[] indices, bool repeatable = true)
        {
            Animator = animator;
            Indices = indices;
            IsRepeatable = repeatable;
        }

        public void Start()
        {
            Animator.StartAnimation(this);
        }
    }
}
