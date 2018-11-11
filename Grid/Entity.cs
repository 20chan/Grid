using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Grid
{
    public sealed class Entity
    {
        public string Name { get; private set; }
        public Vector2 Position { get; set; }
        private Entity _parent;
        private List<Entity> _children;

        private List<IComponent> _comps;
        private List<IUpdatable> _updateableComps;
        private List<IRenderable> _renderableComps;

        private List<IComponent> _tempComps;
        private List<IUpdatable> _tempUpdateableComps;
        private List<IRenderable> _tempRenderableComps;

        private bool _isInitialized = false;

        public Entity(string name)
        {
            _children = new List<Entity>();
            _comps = new List<IComponent>();
            _updateableComps = new List<IUpdatable>();
            _renderableComps = new List<IRenderable>();
            _tempComps = new List<IComponent>();
            _tempUpdateableComps = new List<IUpdatable>();
            _tempRenderableComps = new List<IRenderable>();

            Name = name;
        }

        public void SetParent(Entity parent)
        {
            if (_parent != null)
                _parent._children.Remove(this);
            _parent = parent;
            if (_parent != null)
                _parent._children.Add(this);
        }

        public Entity GetRootParent()
        {
            Entity current = this;
            Entity parent;
            do
            {
                parent = current._parent;
                if (parent == null)
                    return current;
                current = parent;
            }
            while (parent != null);
            return null;
        }

        public void Destroy()
        {
            RemoveAllComponents();

            foreach (var c in _children)
                c.Destroy();
        }

        public void Initialize()
        {
            if (_isInitialized)
                return;

            _tempComps.Clear();
            _tempComps.AddRange(_comps);

            foreach (var comp in _tempComps)
                comp.Initialize();
            foreach (var comp in _tempComps)
                comp.Start();

            _isInitialized = true;
        }

        public void Update()
        {
            _tempUpdateableComps.Clear();
            _tempUpdateableComps.AddRange(_updateableComps);
            for (int i = 0; i < _tempUpdateableComps.Count; i++)
                if (_tempUpdateableComps[i].Enabled)
                    _tempUpdateableComps[i].Update();
        }

        public void Draw(SpriteBatch sb)
        {
            _tempRenderableComps.Clear();
            _tempRenderableComps.AddRange(_renderableComps);
            for (int i = 0; i < _tempRenderableComps.Count; i++)
                if (_tempRenderableComps[i].Visible)
                    _tempRenderableComps[i].Render(sb);
        }

        public void AddComponent(IComponent comp)
        {
            _comps.Add(comp);

            if (comp is IUpdatable updateable)
            {
                _updateableComps.Add(updateable);
            }

            if (comp is IRenderable renderable)
            {
                _renderableComps.Add(renderable);
            }

            if (_isInitialized)
            {
                comp.Initialize();
                comp.Start();
            }
        }

        public T GetComponent<T>() where T : class, IComponent
        {
            foreach (var comp in _comps)
            {
                if (comp is T matched)
                    return matched;
            }
            return null;
        }

        public bool RemoveComponent(IComponent comp)
        {
            if (_comps.Remove(comp))
            {
                if (comp is IUpdatable updateable)
                {
                    _updateableComps.Remove(updateable);
                }

                if (comp is IRenderable renderable)
                {
                    _renderableComps.Remove(renderable);
                }
                return true;
            }
            return false;
        }

        public void RemoveComponents<T>() where T : IComponent
        {
            foreach (var comp in Enumerable.Reverse(_comps))
            {
                if (comp is T matched)
                    RemoveComponent(matched);
            }
        }

        public void RemoveAllComponents()
        {
            // 왜 뒤집어서 빼야 하느냐 ??
            // 그것은 제 자서전에 나와있습니다 ㅎ
            foreach (var comp in Enumerable.Reverse(_comps))
                RemoveComponent(comp);
        }
    }
}
