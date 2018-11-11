using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grid
{
    public abstract class Scene : Game
    {
        private List<Entity> _gameObjects;
        public static GraphicsDevice CurrentGD;

        public Scene()
        {
            _gameObjects = new List<Entity>();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (var entity in _gameObjects)
                entity.Update();
        }
    }
}
