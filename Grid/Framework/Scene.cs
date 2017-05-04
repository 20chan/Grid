using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Grid.Framework
{
    public class Scene : Game
    {
        public static Scene CurrentScene;

        private List<GameObject> _gameObjects;

        public Scene()
        {
            _gameObjects = new List<GameObject>();
        }

        public void Instantiate(GameObject gameObject)
            => _gameObjects.Add(gameObject);

        public void Destroy(GameObject gameObject)
            => _gameObjects.Remove(gameObject);
    }
}
