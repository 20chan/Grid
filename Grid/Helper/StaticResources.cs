using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Helper
{
    internal static class StaticResources
    {
        internal static Texture2D Dummy;
        static StaticResources()
        {
            Dummy = new Texture2D(Scene.CurrentGD, 1, 1);
            Dummy.SetData(new[] { Color.White });
        }
    }
}
