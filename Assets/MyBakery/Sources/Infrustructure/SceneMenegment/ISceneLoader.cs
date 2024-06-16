using Cysharp.Threading.Tasks;

namespace Assets.MyBakery.Sources.Infrustructure.SceneMenegment
{
    public interface ISceneLoader
    {
        UniTask Load(string scene);
    }
}