using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Framework
{
    public class GameObject
    {
        public string Name { get; set; }

        private List<Component> _components;

        public GameObject(string name)
        {
            Name = name;
            _components = new List<Component>();
        }

        public void Start()
            => _components.ForEach(c => c.Start());

        public void Update()
            => _components.ForEach(c => c.Update());

        public void LateUpdate()
            => _components.ForEach(c => c.LateUpdate());

        public T AddComponent<T>() where T : Component, new()
        {
            if (Attribute.GetCustomAttribute(typeof(T), typeof(SingleComponent)) != null)
                if (_components.Any(c => c is T))
                    throw new ArgumentException("SingleComponent can't be duplicated");
            
            T component = new T();
            _components.Add(component);
            return component;
        }

        public T GetComponent<T>() where T : Component
            => _components.First(c => c is T) as T;

        public T[] GetComponents<T>() where T : Component
            => _components.FindAll(c => c is T).ToArray() as T[];

        public void RemoveComponent(Component comp)
            => _components.Remove(comp);

        public void RemoveComponents<T>() where T : Component
            => _components.RemoveAll(c => c is T);
        
    }
}
