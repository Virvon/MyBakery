using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Virvon.MyBakery.Gameplay
{
    public class PlayerCharacter : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<string, UniTask<PlayerCharacter>>
        { 
        }
    }
}