using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Grid
{
    public class Entity
    {
        private List<IComponent> _comps;
        private List<IComponentUpdateable> _updateableComps;
        private List<IComponentRenderable> _renderableComps;

        private List<IComponent> _tempComps;
        private List<IComponentUpdateable> _tempUpdateableComps;
        private List<IComponentRenderable> _tempRenderableComps;

        private bool _isInitialized = false;

        public Entity()
        {
            _comps = new List<IComponent>();
            _updateableComps = new List<IComponentUpdateable>();
            _renderableComps = new List<IComponentRenderable>();
            _tempComps = new List<IComponent>();
            _tempUpdateableComps = new List<IComponentUpdateable>();
            _tempRenderableComps = new List<IComponentRenderable>();
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
            var updateable = comp as IComponentUpdateable;
            var renderable = comp as IComponentRenderable;

            if (updateable != null)
            {
                _updateableComps.Add(updateable);
            }

            if (renderable != null)
            {
                _renderableComps.Add(renderable);
            }

            if (_isInitialized)
            {
                comp.Initialize();
                comp.Start();
            }
        }

        public T GetComponent<T>() where T : UpdateableComponent
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
                var updateable = comp as IComponentUpdateable;
                var renderable = comp as IComponentRenderable;

                if (updateable != null)
                {
                    _updateableComps.Remove(updateable);
                }

                if (renderable != null)
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
