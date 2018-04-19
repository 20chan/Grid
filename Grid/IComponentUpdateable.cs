namespace Grid
{
    public interface IComponentUpdateable
    {
        bool Enabled { get; }
        void Update();
    }
}
