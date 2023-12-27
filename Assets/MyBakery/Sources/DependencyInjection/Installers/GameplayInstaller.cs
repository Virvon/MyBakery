using System;
using Virvon.MyBakery.Services;
using Zenject;

namespace Virvon.MyBakery.DependencyInjection.Installers
{
    internal class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .To<JoystickInput>()
                .AsSingle()
                .NonLazy();
        }
    }
}