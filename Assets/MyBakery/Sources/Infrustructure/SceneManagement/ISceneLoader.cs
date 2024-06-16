using Cysharp.Threading.Tasks;

namespace Virvon.MyBakery.Infrustructure.AssetManagement
{
    public interface ISceneLoader
    {
        UniTask Load(string scene);
    }
}