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
    }
}
