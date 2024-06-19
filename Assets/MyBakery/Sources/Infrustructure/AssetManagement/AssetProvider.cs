using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Virvon.MyBakery.Infrustructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _assetRequest;

        public AssetProvider()
        {
            _assetRequest = new();
        }

        public async UniTask InitializeAsync()
        {
            await Addressables.InitializeAsync().ToUniTask();
        }

        public async UniTask<TAsset> Load<TAsset>(string key) where TAsset : class
        {
            AsyncOperationHandle handle;

            if(_assetRequest.TryGetValue(key, out handle) == false)
            {
                handle = Addressables.LoadAssetAsync<TAsset>(key);
                _assetRequest.Add(key, handle);
            }

            await handle.ToUniTask();

            return handle.Result as TAsset;
        }

        public async UniTask WarmupAssetsByLable(string label)
        {
            List<string> assetsList = await GetAssetsListByLabel(label);
            await LoadAll<object>(assetsList);

        }

        private async UniTask<TAsset[]> LoadAll<TAsset>(List<string> keys) where TAsset : class
        {
            List<UniTask<TAsset>> tasks = new (keys.Count);

            foreach (string key in keys)
                tasks.Add(Load<TAsset>(key));

            return await UniTask.WhenAll(tasks);
        }

        private async UniTask<List<string>> GetAssetsListByLabel(string label, Type type = null)
        {
            AsyncOperationHandle<IList<IResourceLocation>> operationHandle = Addressables.LoadResourceLocationsAsync(label, type);
            IList<IResourceLocation> locations = await operationHandle.ToUniTask();

            List<string> assetKeys = new List<string>(locations.Count);

            foreach (IResourceLocation location in locations)
                assetKeys.Add(location.PrimaryKey);

            Addressables.Release(operationHandle);
            return assetKeys;
        }
    }
}
