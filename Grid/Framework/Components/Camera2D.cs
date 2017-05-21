using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.Components
{
    [SingleComponent]
    public class Camera2D : Camera
    {
        private float _zoom = 1;
        public float Zoom { get => _zoom; set { _zoom = (float)Math.Max(value, 0.1); } }
        public float Rotation { get; set; } = 0f;
        public Vector2 Position { get; set; } = new Vector2();

        public override Matrix GetTransform(GraphicsDevice device)
            => Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                                        Matrix.CreateRotationZ(Rotation) *
                                        Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                        Matrix.CreateTranslation(new Vector3((float)device.Viewport.Width * 0.5f, device.Viewport.Height * 0.5f, 0));

        public Vector2 GetRay(Vector2 arg)
        {
            return (Position + arg) * Zoom;
        }
    }
}
