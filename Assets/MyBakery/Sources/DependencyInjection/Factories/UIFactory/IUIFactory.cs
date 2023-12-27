namespace Virvon.MyBakery.DependencyInjection.Factories
{
    public interface IUIFactory
    {
        void Load();
        void CreateCanvas();
        void CreateHud();
    }
}