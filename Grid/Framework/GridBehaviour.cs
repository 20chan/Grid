using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Framework
{
    public class GridBehaviour
    {
        public virtual void Start() { }
        public virtual void Update() { }

        public void Instantiate(GameObject gameObject) => Scene.CurrentScene.Instantiate(gameObject);
        public void Destroy(object obj) => throw new NotImplementedException();
    }
}
