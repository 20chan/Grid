using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.Components
{
    [SingleComponent]
    public abstract class Renderable : Component
    {
        public abstract void Draw(SpriteBatch sb);
    }
}
