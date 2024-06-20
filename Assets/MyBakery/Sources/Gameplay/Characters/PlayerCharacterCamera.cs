using Cinemachine;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Virvon.MyBakery.Gameplay.Characters
{
    public class PlayerCharacterCamera : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        [Inject]
        private void Construct(PlayerCharacter playerCharacter) =>
            _virtualCamera.Follow = playerCharacter.transform;

        public class Factory : PlaceholderFactory<string, UniTask<PlayerCharacterCamera>>
        {
        }
    }
}