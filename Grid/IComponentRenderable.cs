using Microsoft.Xna.Framework.Graphics;

namespace Grid
{
    public interface IComponentRenderable
    {
        bool Visible { get; }
        void Render(SpriteBatch sb);
    }
}
