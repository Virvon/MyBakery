using UnityEngine;
using Zenject;
using Virvon.Infrustructure;
using Virvon.MyBackery.Services;

internal class LocationInstaller : MonoInstaller
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private GameObject _playerPrefab;

    public override void InstallBindings()
    {
        BindPlayer();
    }

    private void BindPlayer()
    {
        PL player = Container
                    .InstantiatePrefabForComponent<PL>(_playerPrefab, _startPoint);

        Container
            .Bind<PL>()
            .FromInstance(player)
            .AsSingle();
    }
}
