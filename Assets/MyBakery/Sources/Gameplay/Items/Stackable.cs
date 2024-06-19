using UnityEngine;

namespace Virvon.MyBakery.Items
{
    public class Stackable : MonoBehaviour
    {
        [SerializeField] private ItemType _type;

        public ItemType Type => _type;
    }
}