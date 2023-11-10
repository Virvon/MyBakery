using UnityEngine;

namespace Virvon.MyBackery.Equipment
{
    internal abstract class Equipment : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICollectible collectible))
            {
                ShowInfo();
                TakeCollectible(collectible);
            }
        }

        protected abstract void ShowInfo();

        protected abstract void TakeCollectible(ICollectible collectible);
    }

}
