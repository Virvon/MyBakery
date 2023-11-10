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
                SetCollectible(collectible);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out ICollectible collectible))
                RemoveCollectible();
        }

        protected abstract void ShowInfo();

        protected abstract void SetCollectible(ICollectible collectible);

        protected abstract void RemoveCollectible();
    }

}
