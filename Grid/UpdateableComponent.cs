namespace Grid
{
    public abstract class UpdateableComponent : Component, IComponentUpdateable
    {
        public bool Enabled { get; private set; }

        public UpdateableComponent(Entity parent) : base(parent)
        {

        }

        public abstract void Update();
    }
}
