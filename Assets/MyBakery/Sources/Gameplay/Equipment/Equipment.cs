using UnityEngine;

namespace Virvon.MyBakery.Equipment
{
    internal abstract class Equipment : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICollectible collectible))
                SetCollectible(collectible);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out ICollectible collectible))
                RemoveCollectible();
        }

        protected abstract void SetCollectible(ICollectible collectible);

        protected abstract void RemoveCollectible();
    }
}
