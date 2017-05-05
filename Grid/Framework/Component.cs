using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Framework
{
    public abstract class Component
    {
        public GameObject GameObject { get; set; }
        
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void LateUpdate() { }

        public virtual void OnDestroy() { }

        public static void Instantiate(GameObject gameObject) => Scene.CurrentScene.Instantiate(gameObject);

        public void Destroy(GameObject gameObject)
            => Scene.CurrentScene.Destroy(gameObject);

        public void Destroy(Component comp)
            => Scene.CurrentScene.Destroy(comp);
    }

    public class SingleComponent : Attribute { }
}
