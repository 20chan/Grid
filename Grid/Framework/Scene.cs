using System;
using System.Collections.Generic;
using Grid.Framework.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grid.Framework
{
    public class Scene : Game
    {
        public static Scene CurrentScene;

        public Color BackColor { get; set; } = Color.CornflowerBlue;

        private GameObject _mainCam;
        public GameObject MainCamera { get => _mainCam; set { _mainCam = value; mainCameraComponent = value.GetComponent<Camera>(); } }
        protected Camera mainCameraComponent;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<GameObject> _gameObjects;

        public Scene()
        {
            _gameObjects = new List<GameObject>();
            _graphics = new GraphicsDeviceManager(this);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var mainCam = new GameObject("Camera");
            MainCamera.AddComponent<Camera>();

            MainCamera = mainCam;

            Camera.Current = MainCamera;

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            _gameObjects.ForEach(o => o.Update());
            _gameObjects.ForEach(o => o.LateUpdate());
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackColor);

            _spriteBatch.Begin(transformMatrix: mainCameraComponent.GetTransform(GraphicsDevice));
            foreach (var obj in _gameObjects)
            {
                var comp = obj.GetComponent<Renderable2D>();
                if (comp == null) continue;
                _spriteBatch.Draw(comp.Texture, comp.Position, null, Color.White, comp.Rotation, comp.Origin, comp.Scale, SpriteEffects.None, 0);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Instantiate(GameObject gameObject)
            => _gameObjects.Add(gameObject);

        public void Destroy(GameObject gameObject)
            => _gameObjects.Remove(gameObject);
    }
}
