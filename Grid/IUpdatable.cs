namespace Grid
{
    public interface IUpdatable : IComponent
    {
        bool Enabled { get; }
        void Update();
    }
}
