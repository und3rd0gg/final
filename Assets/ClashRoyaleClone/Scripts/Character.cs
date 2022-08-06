using UnityEngine;

namespace ClashRoyaleClone.Scripts
{
    public class Character : MonoBehaviour
    {
        public void Initialize(Vector3 position)
        {
            transform.position = position;
        }
    }
}