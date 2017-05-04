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
        }

        public T AddComponent<T>() where T : Component, new()
        {
            if (Attribute.GetCustomAttribute(typeof(T), typeof(SingleComponent)) != null)
            {
                if (_components.Any(c => c is T))
                    throw new ArgumentException("SingleComponent can't be duplicated");
            }

            T component = new T();
            _components.Add(component);
            return component;
        }

        public T GetComponent<T>() where T : Component
            => _components.First(c => c is T) as T;

        public T[] GetComponents<T>() where T : Component
            => _components.FindAll(c => c is T).ToArray() as T[];
    }
}
