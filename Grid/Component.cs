namespace Grid
{
    public abstract class Component : IComponent
    {
        public Entity Parent { get; private set; }

        public string Name { get; set; }

        public Component(Entity parent)
        {
            Parent = parent;
        }

        public abstract void Initialize();

        public abstract void Start();
    }
}
