using ClashRoyaleClone.Scripts.Game.Abstractions;
using UnityEngine;

namespace ClashRoyaleClone.Scripts.Game
{
    public class Health : CharacterCharacteristic, IAttackable
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Amount -= 1;
            }
        }
    }
}
