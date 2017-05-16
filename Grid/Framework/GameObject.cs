using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Grid.Framework
{
    public class GameObject
    {
        public bool Enabled { get; set; } = true;

        public GameObject Parent { get; set; }
        public List<GameObject> Childs { get; private set; }

        public bool Destroyed { get; private set; } = false;
        public string Name { get; set; }
        public string Tag { get; set; }
        public Transform Transform { get; private set; }
        public Vector2 Position { get => Transform.Position; set => Transform.Position = value; }
        public Vector2 Scale { get => Transform.Scale; set => Transform.Scale = value; }
        public float Rotation { get => Transform.Rotation; set => Transform.Rotation = value; }

        public Vector2 AbsolutePosition => Transform.AbsolutePosition;
        public Vector2 AbsoluteScale => Transform.AbsoluteScale;
        public float AbsoluteRotation => Transform.AbsoluteRotation;
        
        private List<Component> _components;

        public GameObject(string name, GameObject parent = null)
        {
            Childs = new List<GameObject>();
            Name = name;
            Parent = parent;
            Parent?.Childs.Add(this);
            _components = new List<Component>();
            Transform = new Transform(this);
        }

        public void Start() { }

        public void Update()
            => _components.FindAll(c => c.Enabled).ForEach(c => c.Update());
        
        public void LateUpdate()
            => _components.FindAll(c => c.Enabled).ForEach(c => c.LateUpdate());

        public void OnDestroy()
        {
            _components.ForEach(c => c.GameObject = null);
            _components.Clear();
            Destroyed = true;
        }

        public T AddComponent<T>() where T : Component, new()
        {
            if (Attribute.GetCustomAttribute(typeof(T), typeof(SingleComponent)) != null)
                if (_components.Any(c => c is T))
                    throw new ArgumentException("SingleComponent can't be duplicated");

            T component = new T()
            {
                GameObject = this
            };
            _components.Add(component);
            Scene.CurrentScene.AddStartQueue(component);
            return component;
        }

        internal void DestroyComponentImmediate(Component comp)
        {
            _components.Remove(comp);
            comp.GameObject = null;
        }

        public Component[] GetAllComponents()
            => _components.ToArray();

        public T GetComponent<T>() where T : Component
            => _components.FirstOrDefault(c => c is T) as T;

        public T[] GetComponents<T>() where T : Component
            => _components.FindAll(c => c is T).ToArray() as T[];

        public void RemoveComponents<T>() where T : Component
            => _components.RemoveAll(c => c is T);

        public static GameObject Find(string name)
            => Scene.CurrentScene.FindGameObjectByName(name);

        public static GameObject FindWithTag(string tag)
            => Scene.CurrentScene.FindGameObjectByTag(tag);

        public static GameObject[] FindGameObjectsByTag(string tag)
            => Scene.CurrentScene.FindGameObjectsByTag(tag);
    }
}
