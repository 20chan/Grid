using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework.Components
{
    [SingleComponent]
    public abstract class Renderable : Component
    {
        /// <summary>
        /// OnCamera가 true이면 Scene에서 MainCamera 위에 투영됩니다. false라면 직접 SpriteBatch.Begin()~End()를 호출해야 합니다.
        /// </summary>
        public bool OnCamera { get; set; } = true;
        public abstract void Draw(SpriteBatch sb);
    }
}
