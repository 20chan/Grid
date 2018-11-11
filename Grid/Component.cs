namespace Grid
{
    public abstract class Component : IComponent
    {
        public Entity GameObject { get; private set; }

        public Component(Entity gameObject)
        {
            GameObject = gameObject;
        }

        public virtual void Initialize() { }

        public virtual void Start() { }
    }
}
