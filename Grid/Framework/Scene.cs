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

        protected GraphicsDeviceManager _graphics;
        protected SpriteBatch _spriteBatch;

        private List<GameObject> _gameObjects;
        private List<Component> _notStartedQueue;
        private List<GameObject> _destroyGameObjectQueue;
        private List<Component> _destroyComponentQueue;

        public Scene()
        {
            _gameObjects = new List<GameObject>();
            _graphics = new GraphicsDeviceManager(this);

            _notStartedQueue = new List<Component>();
            _destroyGameObjectQueue = new List<GameObject>();
            _destroyComponentQueue = new List<Component>();
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            CurrentScene = this;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var mainCam = new GameObject("Camera");
            mainCam.AddComponent<Camera>();

            MainCamera = mainCam;

            Camera.Current = MainCamera;
            Instantiate(mainCam);

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            while (_destroyComponentQueue.Count > 0)
            {
                _destroyComponentQueue[0].GameObject.DestroyComponentImmediate(_destroyComponentQueue[0]);
                _destroyComponentQueue.RemoveAt(0);
            }
            while (_destroyGameObjectQueue.Count > 0)
            {
                _destroyGameObjectQueue[0].OnDestroy();
                _destroyGameObjectQueue.RemoveAt(0);
            }
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
                _spriteBatch.Draw(comp.Texture, comp.GameObject.Position, null, Color.White, comp.GameObject.Rotation, comp.Origin, comp.GameObject.Scale, SpriteEffects.None, 0);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Instantiate(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
            AddStartQueue(gameObject);
        }

        public void Destroy(GameObject gameObject)
            => _destroyGameObjectQueue.Add(gameObject);

        public void Destroy(Component component)
            => _destroyComponentQueue.Add(component);
        

        public GameObject FindGameObjectByName(string name)
            => _gameObjects.Find(g => g.Name == name);

        public GameObject FindGameObjectByTag(string tag)
            => _gameObjects.Find(g => g.Tag == tag);

        public GameObject[] FindGameObjectsByTag(string tag)
            => _gameObjects.FindAll(g => g.Tag == tag).ToArray();

        public void AddStartQueue(Component comp)
            => _notStartedQueue.Add(comp);

        public void AddStartQueue(GameObject obj)
            => _notStartedQueue.AddRange(obj.GetAllComponents());
    }
}
