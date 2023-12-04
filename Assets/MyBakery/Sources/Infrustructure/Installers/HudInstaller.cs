using UnityEngine;
using Zenject;

namespace Virvon.MyBakery.Infrustrucure
{
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
}
