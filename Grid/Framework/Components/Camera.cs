using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.Components
{
    public abstract class Camera : Component
    {
        public static Camera Current;
        public abstract Matrix GetTransform();
        public abstract Vector2 GetRay(Vector2 origin);
    }
}
