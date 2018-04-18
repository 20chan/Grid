namespace Grid
{
    public abstract class UpdatableComponent : Component, IComponentUpdatable
    {
        public bool Enabled { get; private set; }

        public UpdatableComponent(Entity parent) : base(parent)
        {

        }

        public abstract void Update();
    }
}
