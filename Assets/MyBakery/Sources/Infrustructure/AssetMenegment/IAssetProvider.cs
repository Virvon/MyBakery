﻿
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

namespace Assets.MyBakery.Sources.Infrustructure.AssetMenegment
{
    public interface IAssetProvider
    {
        UniTask<TAsset> Load<TAsset>(string key) where TAsset : class;
        UniTask InitializeAsync();
        UniTask WarmupAssetsByLable(string label);
    }
}