using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.Components
{
    [SingleComponent]
    public class Renderable2DAnimation : Renderable
    {
        public Vector2 Origin { get; set; } = new Vector2();
        public Texture2D[] Textures { get; private set; }
        public int FrameCount => Textures.Length;
        public int Interval = 1;

        public bool IsStopped { get; private set; }
        public bool IsRepeatable { get; set; }

        private int _currentFrame = 0;
        private int _currentFrameIndex = 0;
        
        public override void Update()
        {
            base.Update();
            if (IsStopped) return;
            
            _currentFrame++;
            if (_currentFrame == Interval)
            {
                if (_currentFrameIndex++ > FrameCount && IsRepeatable)
                    _currentFrameIndex = 0;
                _currentFrame = 0;
            }
        }

        public void Stop()
            => IsStopped = true;

        public void Resume()
            => IsStopped = false;

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(Textures[_currentFrameIndex], GameObject.Position, null, Color.White, GameObject.Rotation, Origin, GameObject.Scale, SpriteEffects.None, 0);
        }
    }
}
