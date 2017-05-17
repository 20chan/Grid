using System.Linq;
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

        private GameObject _guiManager;
        public GameObject GuiManager { get => _guiManager; set { _guiManager = value; guiManagerComponent = value.GetComponent<GUIManager>(); } }
        protected GUIManager guiManagerComponent;

        protected GraphicsDeviceManager _graphics;
        protected SpriteBatch _spriteBatch;

        private List<GameObject> _gameObjects;
        private Queue<GameObject> _notStartedGameobject;
        private Queue<Component> _notStartedQueue;
        private Queue<GameObject> _destroyGameObjectQueue;
        private Queue<Component> _destroyComponentQueue;

        public Scene()
        {
            Content.RootDirectory = "Content";

            _gameObjects = new List<GameObject>();
            _graphics = new GraphicsDeviceManager(this);
            InitSize();

            _notStartedQueue = new Queue<Component>();
            _notStartedGameobject = new Queue<GameObject>();
            _destroyGameObjectQueue = new Queue<GameObject>();
            _destroyComponentQueue = new Queue<Component>();
        }

        protected virtual void InitSize() { }

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
            Instantiate(mainCam);
            Camera.Current = MainCamera;

            var guimanager = new GameObject("GUIManager");
            guimanager.AddComponent<GUIManager>();
            GuiManager = guimanager;
            Instantiate(guimanager);

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            Time.ElapsedGameTime = gameTime.ElapsedGameTime;
            Time.TotalGameTime = gameTime.TotalGameTime;
            while (_destroyComponentQueue.Count > 0)
            {
                var comp = _destroyComponentQueue.Dequeue();
                comp.GameObject.DestroyComponentImmediate(comp);
            }
            while (_destroyGameObjectQueue.Count > 0)
            {
                _destroyGameObjectQueue.Dequeue().OnDestroy();
            }
            while (_notStartedQueue.Count > 0)
            {
                _notStartedQueue.Dequeue().Start();
            }
            while (_notStartedGameobject.Count > 0)
            {
                _notStartedGameobject.Dequeue().Start();
            }
            guiManagerComponent.HandleEvent();
            _gameObjects.FindAll(o => o.Enabled).ForEach(o => o.Update());
            _gameObjects.FindAll(o => o.Enabled).ForEach(o => o.LateUpdate());
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackColor);

            _spriteBatch.Begin(transformMatrix: mainCameraComponent.GetTransform(GraphicsDevice));
            foreach (var obj in _gameObjects)
            {
                if(obj.Enabled)
                    obj.GetComponent<Renderable>()?.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            _spriteBatch.Begin();
            guiManagerComponent.Draw(_spriteBatch); // UI는 카메라와 상관없어야 한다는 전제 하에
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Instantiate(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
            AddStartQueue(gameObject);
        }

        public void Destroy(GameObject gameObject)
            => _destroyGameObjectQueue.Enqueue(gameObject);

        public void Destroy(Component component)
            => _destroyComponentQueue.Enqueue(component);
        
        public GameObject FindGameObjectByName(string name)
            => _gameObjects.Find(g => g.Name == name);

        public GameObject FindGameObjectByTag(string tag)
            => _gameObjects.Find(g => g.Tag == tag);

        public GameObject[] FindGameObjectsByTag(string tag)
            => _gameObjects.FindAll(g => g.Tag == tag).ToArray();

        public void AddStartQueue(Component comp)
            => _notStartedQueue.Enqueue(comp);

        public void AddStartQueue(GameObject obj)
            => _notStartedGameobject.Enqueue(obj);

        public static T LoadContent<T>(string assetName)
            => CurrentScene.Content.Load<T>(assetName);
    }
}
