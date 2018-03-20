using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Grid.Framework;
using Grid.Framework.Components;

namespace Grid.Framework.Components
{
    public class Movable2DCamera : Component
    {
        public float Speed { get; set; } = 5f;
        public float ZoomRate { get; set; } = 0.05f;
        public float RotateSpeed { get; set; } = 0.03f;

        private int _previousScroll = 0;
        public override void LateUpdate()
        {
            var cam = gameObject.GetComponent<Camera2D>();
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                cam.MoveAbsolutely(new Vector2(0, -1) * Speed);
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                cam.MoveAbsolutely(new Vector2(0, 1) * Speed);
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                cam.MoveAbsolutely(new Vector2(-1, 0) * Speed);
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                cam.MoveAbsolutely(new Vector2(1, 0) * Speed);

            var scroll = Mouse.GetState().ScrollWheelValue;
            if (scroll - _previousScroll > 0)
                cam.Zoom /= (1 - ZoomRate);
            if (scroll - _previousScroll < 0)
                cam.Zoom *= (1 - ZoomRate);

            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                cam.Rotation -= RotateSpeed;
            if (Keyboard.GetState().IsKeyDown(Keys.E))
                cam.Rotation += RotateSpeed;

            _previousScroll = scroll;
            base.Update();
        }
    }
}
