using Assets.MyBakery.Sources.Infrustructure;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.MyBakery.Sources.UI.LoadingCurtain
{
    public class LoadingCurtainProxy : ILoadingCurtain
    {
        private readonly LoadingCurtain.Factory _factory;

        private ILoadingCurtain _implementation;

        public LoadingCurtainProxy(LoadingCurtain.Factory factory)
        {
            Debug.Log("Construct loading curtain proxy");

            _factory = factory;
        }

        public async UniTask InitializeAsync()
        {
            _implementation = await _factory.Create(InfrasructureAssetPath.Curtain);
        }

        public void Show() =>
            _implementation.Show();

        public void Hide() =>
            _implementation.Hide();
    }
}
