using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Framework
{
    public abstract class Component
    {
        public virtual void Start() { }
        public virtual void Update() { }
    }
}
