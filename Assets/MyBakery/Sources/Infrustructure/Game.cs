using Virvon.MyBackery.Services;

namespace Virvon.Infrustructure
{
    public class Game
    {
        public static IInputService InputService { get; private set; }

        public Game()
        {
            InputService = new InputService();
        }
    }
}