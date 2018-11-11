using Microsoft.Xna.Framework.Graphics;

namespace Grid
{
    public interface IRenderable : IComponent
    {
        bool Visible { get; }
        void Render(SpriteBatch sb);
    }
}
