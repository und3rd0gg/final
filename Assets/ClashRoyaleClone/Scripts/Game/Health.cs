using UnityEngine;

public class Health : CharacterCharacteristic
{
    public void ApplyDamage(int damage)
    {
        Amount -= damage;
    }
}