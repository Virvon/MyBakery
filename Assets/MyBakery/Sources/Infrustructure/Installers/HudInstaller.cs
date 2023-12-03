using UnityEngine;
using Zenject;

internal class HudInstaller : MonoInstaller
{
    [SerializeField] private GameObject _hud;

    public override void InstallBindings()
    {
        BindHud();
    }

    private void BindHud()
    {
        Container
            .InstantiatePrefab(_hud);
    }
}
