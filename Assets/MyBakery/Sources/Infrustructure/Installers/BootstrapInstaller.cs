using UnityEngine;
using Virvon.Infrustructure;
using Virvon.MyBackery.Services;
using Zenject;

internal class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private GameObject _loadingPanelPrefab;

    public override void InstallBindings()
    {
        BindSceneLoader();
        BindFactories();
        BindGame();
        BindLoadingPanel();
        BindInputService();
    }

    private void BindInputService()
    {
        Container
            .Bind<IInputService>()
            .To<InputService>()
            .AsSingle()
            .NonLazy();
    }

    private void BindLoadingPanel()
    {
        LoadingPanel loadingPanel = Container
                    .InstantiatePrefabForComponent<LoadingPanel>(_loadingPanelPrefab);

        Container
            .Bind<LoadingPanel>()
            .FromInstance(loadingPanel)
            .AsSingle();
    }

    private void BindFactories()
    {
        Container
            .Bind<IClientFactory>()
            .To<ClientFactory>()
            .AsSingle()
            .NonLazy();
    }

    private void BindGame()
    {
        Container
            .Bind<Game>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }

    private void BindSceneLoader()
    {
        Container
            .Bind<SceneLoader>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }
}
    //позже удалить ссылку на TMPro.dll если он еще не удален
