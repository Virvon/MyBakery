using Cysharp.Threading.Tasks;

namespace Virvon.MyBakery.Infrustructure
{
    public interface IGameplayFactory
    {
        UniTask CreateHud();
    }
}