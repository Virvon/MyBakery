using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.MyBakery.Sources.Infrustructure.AssetMenegment
{
    public class PrefabFactoryAsync<TComponent> : IFactory<string, UniTask<TComponent>>
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        public PrefabFactoryAsync(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public async UniTask<TComponent> Create(string assetKey)
        {
            GameObject prefab = await _assetProvider.Load<GameObject>(assetKey);
            GameObject newObject = _instantiator.InstantiatePrefab(prefab);
            return newObject.GetComponent<TComponent>();
        }
    }
}
