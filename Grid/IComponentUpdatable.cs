namespace Grid
{
    public interface IComponentUpdatable
    {
        bool Enabled { get; }
        void Update();
    }
}
