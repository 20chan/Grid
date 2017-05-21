using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Grid.Framework;
using Grid.Framework.Components;

namespace Grid
{
    class MovableCamera : Component
    {
        public float Speed { get; set; } = 5f;
        public float ZoomRate { get; set; } = 0.05f;
        public float RotateSpeed { get; set; } = 0.03f;
        public override void LateUpdate()
        {
            var cam = GameObject.GetComponent<Camera2D>();
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                cam.Position += new Vector2(0, -1) * Speed;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                cam.Position += new Vector2(0, 1) * Speed;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                cam.Position += new Vector2(-1, 0) * Speed;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                cam.Position += new Vector2(1, 0) * Speed;
            if (Keyboard.GetState().IsKeyDown(Keys.OemPlus))
                cam.Zoom /= (1 - ZoomRate);
            if (Keyboard.GetState().IsKeyDown(Keys.OemMinus))
                cam.Zoom *= (1 - ZoomRate);
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                cam.Rotation -= RotateSpeed;
            if (Keyboard.GetState().IsKeyDown(Keys.E))
                cam.Rotation += RotateSpeed;
            base.Update();
        }
    }
}
