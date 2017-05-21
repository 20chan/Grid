using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.Components
{
    public abstract class Camera : Component
    {
        public static Camera Current;
        public abstract Matrix GetTransform(GraphicsDevice device);
    }
}
