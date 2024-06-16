using UnityEngine;
using Zenject;

namespace Virvon.MyBakery.Infrustructure.States
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<StatesFactory>().AsSingle();
            Container.Bind<GameStateMachine>().AsSingle();

            Debug.Log("Install bindings to game state machine installer");
        }
    }
}