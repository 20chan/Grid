using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.Components
{
    [SingleComponent]
    public class SpriteAnimator : Renderable
    {
        public Vector2 Origin { get; set; } = new Vector2();
        public Texture2D[] Textures { get; set; }

        private Animation _currentAnim;
        private int _currentFrame = 0;
        private int _currentFrameIndex = 0;

        public override void Update()
        {
            base.Update();
            if (_currentAnim.IsStopped) return;
            
            if (_currentFrame++ == _currentAnim.Interval)
            {
                if (++_currentFrameIndex >= _currentAnim.FrameCount && _currentAnim.IsRepeatable)
                    _currentFrameIndex = 0;
                _currentFrame = 0;
            }
        }

        public void StartAnimation(Animation anim)
        {
            if (_currentAnim != null)
            _currentAnim.IsEnabled = false;
            anim.IsEnabled = true;
            _currentAnim = anim;
            _currentFrame = 0;
            _currentFrameIndex = 0;
            Resume();
        }

        public void Stop()
            => _currentAnim.IsStopped = true;

        public void Resume()
            => _currentAnim.IsStopped = false;

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(
                Textures[_currentAnim.Indices[_currentFrameIndex]],
                gameObject.Position,
                null,
                Color.White,
                gameObject.Rotation,
                Origin,
                gameObject.Scale,
                SpriteEffects.None,
                0);
        }
    }
}
