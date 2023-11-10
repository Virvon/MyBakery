using UnityEngine;

namespace Virvon.MyBackery.Items
{
    public class Stack : MonoBehaviour
    {
        public void Add(Stackable stackable)
        {
            stackable.transform.position = transform.position;
            stackable.transform.parent = transform;
        }
    }
}