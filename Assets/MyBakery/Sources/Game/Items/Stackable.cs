using UnityEngine;

namespace Virvon.MyBackery.Items
{
    public class Stackable : MonoBehaviour
    {
        [SerializeField] private ItemType _type;

        public ItemType Type => _type;
    }
}