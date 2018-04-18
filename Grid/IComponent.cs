namespace Grid
{
    public interface IComponent
    {
        string Name { get; set; }

        void Initialize();

        void Start();
    }
}
