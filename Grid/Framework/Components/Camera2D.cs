using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Grid.Framework.Components
{
    [SingleComponent]
    public class Camera2D : Camera
    {
        private float _zoom = 1;
        public float Zoom { get => _zoom; set { _zoom = (float)Math.Max(value, 0.1); } }
        public float Rotation { get; set; } = 0f;
        public Vector2 Position { get; set; } = new Vector2();
        public Rectangle Bounds { get; }
        public Vector2 CursorPosition { get; private set; }

        public override Matrix GetTransform()
            => Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                                        Matrix.CreateRotationZ(Rotation) *
                                        Matrix.CreateScale(new Vector3(Zoom, Zoom, 1))
            * Matrix.CreateTranslation(new Vector3(Bounds.Width * 0.5f, Bounds.Height * 0.5f, 0));

        public Camera2D()
        {
            Bounds = Scene.CurrentScene.GraphicsDevice.Viewport.Bounds;
        }

        public void MoveAbsolutely(Vector2 direction)
        {
            Position += Vector2.Transform(direction, Matrix.CreateRotationX(Rotation));
        }

        public override Vector2 GetRay(Vector2 arg)
        {
            return Vector2.Transform(arg, Matrix.Invert(GetTransform()));
        }

        public override void Update()
        {
            base.Update();
            CursorPosition = GetRay(Mouse.GetState().Position.ToVector2());
        }
    }
}
