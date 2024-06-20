namespace Virvon.MyBakery.Gameplay.Characters
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update();
    }
}