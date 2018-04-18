using Microsoft.Xna.Framework.Graphics;

namespace Grid
{
    public abstract class RenderableComponent : Component, IComponentRenderable
    {
        public bool Visible { get; private set; }

        public RenderableComponent(Entity parent) : base(parent)
        {

        }

        public abstract void Render(SpriteBatch sb);
    }
}
